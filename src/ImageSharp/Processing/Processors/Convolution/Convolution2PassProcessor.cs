﻿// Copyright (c) Six Labors and contributors.
// Licensed under the Apache License, Version 2.0.

using System;
using System.Numerics;
using System.Threading.Tasks;
using SixLabors.ImageSharp.Advanced;
using SixLabors.ImageSharp.Helpers;
using SixLabors.ImageSharp.Memory;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.Primitives;

namespace SixLabors.ImageSharp.Processing.Processors
{
    /// <summary>
    /// Defines a sampler that uses two one-dimensional matrices to perform two-pass convolution against an image.
    /// </summary>
    /// <typeparam name="TPixel">The pixel format.</typeparam>
    internal class Convolution2PassProcessor<TPixel> : ImageProcessor<TPixel>
        where TPixel : struct, IPixel<TPixel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Convolution2PassProcessor{TPixel}"/> class.
        /// </summary>
        /// <param name="kernelX">The horizontal gradient operator.</param>
        /// <param name="kernelY">The vertical gradient operator.</param>
        public Convolution2PassProcessor(Fast2DArray<float> kernelX, Fast2DArray<float> kernelY)
        {
            this.KernelX = kernelX;
            this.KernelY = kernelY;
        }

        /// <summary>
        /// Gets the horizontal gradient operator.
        /// </summary>
        public Fast2DArray<float> KernelX { get; }

        /// <summary>
        /// Gets the vertical gradient operator.
        /// </summary>
        public Fast2DArray<float> KernelY { get; }

        /// <inheritdoc/>
        protected override void OnApply(ImageFrame<TPixel> source, Rectangle sourceRectangle, Configuration configuration)
        {
            int width = source.Width;
            int height = source.Height;
            ParallelOptions parallelOptions = configuration.ParallelOptions;

            using (var firstPassPixels = new PixelAccessor<TPixel>(configuration.MemoryManager, width, height))
            using (PixelAccessor<TPixel> sourcePixels = source.Lock())
            {
                this.ApplyConvolution(firstPassPixels, sourcePixels, source.Bounds(), this.KernelX, parallelOptions);
                this.ApplyConvolution(sourcePixels, firstPassPixels, sourceRectangle, this.KernelY, parallelOptions);
            }
        }

        /// <summary>
        /// Applies the process to the specified portion of the specified <see cref="ImageFrame{TPixel}"/> at the specified location
        /// and with the specified size.
        /// </summary>
        /// <param name="targetPixels">The target pixels to apply the process to.</param>
        /// <param name="sourcePixels">The source pixels. Cannot be null.</param>
        /// <param name="sourceRectangle">
        /// The <see cref="Rectangle"/> structure that specifies the portion of the image object to draw.
        /// </param>
        /// <param name="kernel">The kernel operator.</param>
        /// <param name="parallelOptions">The parellel options</param>
        private void ApplyConvolution(
            PixelAccessor<TPixel> targetPixels,
            PixelAccessor<TPixel> sourcePixels,
            Rectangle sourceRectangle,
            Fast2DArray<float> kernel,
            ParallelOptions parallelOptions)
        {
            int kernelHeight = kernel.Height;
            int kernelWidth = kernel.Width;
            int radiusY = kernelHeight >> 1;
            int radiusX = kernelWidth >> 1;

            int startY = sourceRectangle.Y;
            int endY = sourceRectangle.Bottom;
            int startX = sourceRectangle.X;
            int endX = sourceRectangle.Right;
            int maxY = endY - 1;
            int maxX = endX - 1;

            Parallel.For(
                startY,
                endY,
                parallelOptions,
                y =>
                {
                    Span<TPixel> targetRow = targetPixels.GetRowSpan(y);

                    for (int x = startX; x < endX; x++)
                    {
                        var destination = default(Vector4);

                        // Apply each matrix multiplier to the color components for each pixel.
                        for (int fy = 0; fy < kernelHeight; fy++)
                        {
                            int fyr = fy - radiusY;
                            int offsetY = y + fyr;

                            offsetY = offsetY.Clamp(0, maxY);
                            Span<TPixel> row = sourcePixels.GetRowSpan(offsetY);

                            for (int fx = 0; fx < kernelWidth; fx++)
                            {
                                int fxr = fx - radiusX;
                                int offsetX = x + fxr;

                                offsetX = offsetX.Clamp(0, maxX);

                                Vector4 currentColor = row[offsetX].ToVector4().Premultiply();
                                destination += kernel[fy, fx] * currentColor;
                            }
                        }

                        ref TPixel pixel = ref targetRow[x];
                        pixel.PackFromVector4(destination.UnPremultiply());
                    }
                });
        }
    }
}