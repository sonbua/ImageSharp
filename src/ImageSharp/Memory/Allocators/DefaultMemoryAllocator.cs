using System;
using System.Buffers;
using System.Runtime.CompilerServices;
using SixLabors.ImageSharp.Memory.Internals;

namespace SixLabors.ImageSharp.Memory
{
    internal sealed class DefaultMemoryAllocator : MemoryAllocator
    {
        private readonly int sharedArrayPoolThresholdInBytes;
        private readonly int maxCapacityOfPoolBuffersInBytes;
        private readonly int poolCapacity;

        private UniformByteArrayPool pool;
        private readonly UnmanagedMemoryAllocator unmnagedAllocator;

        public DefaultMemoryAllocator(
            int maxContiguousPoolBufferInBytes,
            int maxPoolSizeInBytes,
            int maxContiguousUnmanagedBufferInBytes)
            : this(
                1024 * 1024,
                maxContiguousPoolBufferInBytes,
                maxPoolSizeInBytes,
                maxContiguousUnmanagedBufferInBytes)
        {
        }

        // Internal constructor allowing to change the shared array pool threshold for testing purposes.
        internal DefaultMemoryAllocator(
            int sharedArrayPoolThresholdInBytes,
            int maxCapacityOfPoolBuffersInBytes,
            int maxPoolSizeInBytes,
            int maxCapacityOfUnmanagedBuffers)
        {
            this.sharedArrayPoolThresholdInBytes = sharedArrayPoolThresholdInBytes;
            this.maxCapacityOfPoolBuffersInBytes = maxCapacityOfPoolBuffersInBytes;
            this.poolCapacity = maxPoolSizeInBytes / maxCapacityOfPoolBuffersInBytes;
            this.pool = new UniformByteArrayPool(maxCapacityOfPoolBuffersInBytes, this.poolCapacity);
            this.unmnagedAllocator = new UnmanagedMemoryAllocator(maxCapacityOfUnmanagedBuffers);
        }

        /// <inheritdoc />
        protected internal override int GetBufferCapacityInBytes() =>
            throw new InvalidOperationException("Should be never invoked.");

        /// <inheritdoc />
        public override IMemoryOwner<T> Allocate<T>(
            int length,
            AllocationOptions options = AllocationOptions.None)
        {
            Guard.MustBeGreaterThanOrEqualTo(length, 0, nameof(length));
            int lengthInBytes = length * Unsafe.SizeOf<T>();

            if (lengthInBytes <= this.sharedArrayPoolThresholdInBytes)
            {
                var buffer = new SharedArrayPoolBuffer<T>(length);
                if (options == AllocationOptions.Clean)
                {
                    buffer.GetSpan().Clear();
                }

                return buffer;
            }

            if (lengthInBytes <= this.maxCapacityOfPoolBuffersInBytes)
            {
                byte[] array = this.pool.Rent(options);
                if (array != null)
                {
                    return new UniformByteArrayPool.FinalizableBuffer<T>(array, length, this.pool);
                }
            }

            return this.unmnagedAllocator.Allocate<T>(length, options);
        }

        /// <inheritdoc />
        public override IManagedByteBuffer AllocateManagedByteBuffer(
            int length,
            AllocationOptions options = AllocationOptions.None)
        {
            SharedArrayPoolByteBuffer buffer = new SharedArrayPoolByteBuffer(length);
            if (options == AllocationOptions.Clean)
            {
                buffer.GetSpan().Clear();
            }

            return buffer;
        }

        /// <inheritdoc />
        public override void ReleaseRetainedResources()
        {
            // TODO: ReleaseRetainedResources() is not thread-safe now, we should consider making it thread-safe.
            this.pool.Release();
            this.pool = new UniformByteArrayPool(this.maxCapacityOfPoolBuffersInBytes, this.poolCapacity);
        }

        internal override MemoryGroup<T> AllocateGroup<T>(long totalLength, int bufferAlignment, AllocationOptions options = AllocationOptions.None)
        {
            if (totalLength < this.sharedArrayPoolThresholdInBytes)
            {
                var buffer = new SharedArrayPoolBuffer<T>((int)totalLength);
                if (options == AllocationOptions.Clean)
                {
                    buffer.Memory.Span.Clear();
                }

                return MemoryGroup<T>.CreateContiguous(buffer);
            }

            if (totalLength < this.maxCapacityOfPoolBuffersInBytes)
            {
                // Optimized path renting single array from the pool
                byte[] array = this.pool.Rent(options);
                var buffer = new UniformByteArrayPool.FinalizableBuffer<T>(array, (int)totalLength, this.pool);
                return MemoryGroup<T>.CreateContiguous(buffer);
            }

            // Attempt to rent the whole group from the pool, allocate a group of unmanaged buffers if the attempt fails:
            var poolGroup = MemoryGroup<T>.Allocate(this.pool, totalLength, bufferAlignment, options);
            return poolGroup ?? MemoryGroup<T>.Allocate(this.unmnagedAllocator, totalLength, bufferAlignment, options);
        }
    }
}