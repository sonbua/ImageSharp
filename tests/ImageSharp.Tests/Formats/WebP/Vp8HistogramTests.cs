// Copyright (c) Six Labors.
// Licensed under the Six Labors Split License.

using SixLabors.ImageSharp.Formats.Webp.Lossy;
using SixLabors.ImageSharp.Tests.TestUtilities;

namespace SixLabors.ImageSharp.Tests.Formats.Webp;

[Trait("Format", "Webp")]
public class Vp8HistogramTests
{
    public static IEnumerable<object[]> Data
    {
        get
        {
            var result = new List<object[]>();
            result.Add(new object[]
            {
                new byte[]
                {
                    16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 19, 16, 128, 128, 128, 128, 128, 128,
                    128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16,
                    16, 16, 16, 19, 16, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128,
                    128, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 19, 16, 128, 128, 128, 128, 128,
                    128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16,
                    16, 16, 16, 16, 19, 16, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128,
                    128, 128, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 19, 16, 128, 128, 128, 128,
                    128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 16, 16, 16, 16, 16, 16, 16, 16, 16,
                    16, 16, 16, 16, 16, 19, 16, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128,
                    128, 128, 128, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 19, 16, 128, 128, 128,
                    128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 16, 16, 16, 16, 16, 16, 16, 16,
                    16, 16, 16, 16, 16, 16, 19, 16, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128,
                    128, 128, 128, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 19, 16, 204, 204, 204,
                    204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 16, 16, 16, 16, 16, 16, 16, 16,
                    16, 16, 16, 16, 16, 16, 19, 16, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204,
                    204, 204, 204, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 19, 16, 204, 204, 204,
                    204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 16, 16, 16, 16, 16, 16, 16, 16,
                    16, 16, 16, 16, 16, 16, 19, 16, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204,
                    204, 204, 204, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 19, 16, 204, 204, 204,
                    204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 16, 16, 16, 16, 16, 16, 16, 16,
                    16, 16, 16, 16, 16, 16, 19, 16, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204,
                    204, 204, 204, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 24, 16, 204, 204, 204,
                    204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 16, 16, 16, 16, 16, 16, 16, 16,
                    16, 16, 16, 16, 16, 16, 16, 16, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204,
                    204, 204, 204
                },
                new byte[]
                {
                    128, 128, 128, 128, 129, 129, 129, 129, 127, 127, 127, 127, 129, 129, 129, 129, 128, 127, 127,
                    127, 127, 127, 127, 127, 127, 127, 127, 127, 127, 127, 127, 127, 128, 128, 128, 128, 129, 129,
                    129, 129, 127, 127, 127, 127, 129, 129, 129, 129, 129, 128, 127, 127, 128, 127, 127, 127, 127,
                    127, 127, 127, 127, 127, 127, 127, 128, 128, 128, 128, 129, 129, 129, 129, 127, 127, 127, 127,
                    129, 129, 129, 129, 129, 129, 128, 127, 129, 127, 127, 127, 127, 127, 127, 127, 127, 127, 127,
                    127, 128, 128, 128, 128, 129, 129, 129, 129, 127, 127, 127, 127, 129, 129, 129, 129, 129, 129,
                    129, 128, 129, 128, 127, 127, 127, 127, 127, 127, 127, 127, 127, 127, 128, 128, 127, 127, 129,
                    129, 129, 129, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204,
                    204, 204, 204, 204, 204, 204, 204, 204, 129, 129, 128, 128, 129, 129, 129, 129, 204, 204, 204,
                    204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204,
                    204, 204, 129, 129, 129, 129, 129, 129, 129, 129, 204, 204, 204, 204, 204, 204, 204, 204, 204,
                    204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 129, 129, 129, 129,
                    129, 129, 129, 129, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204,
                    204, 204, 204, 204, 204, 204, 204, 204, 204
                }
            });
            return result;
        }
    }

    private static void RunCollectHistogramTest()
    {
        // arrange
        var histogram = new Vp8Histogram();

        byte[] reference =
        {
            154, 154, 151, 151, 149, 148, 151, 157, 163, 163, 154, 132, 102, 98, 104, 108, 107, 104, 104, 103,
            101, 106, 123, 119, 170, 171, 172, 171, 168, 175, 171, 173, 151, 151, 149, 150, 147, 147, 146, 159,
            164, 165, 154, 129, 92, 90, 101, 105, 104, 103, 104, 101, 100, 105, 123, 117, 172, 172, 172, 168,
            170, 177, 170, 175, 151, 149, 150, 150, 147, 147, 156, 161, 161, 161, 151, 126, 93, 90, 102, 107,
            104, 103, 104, 101, 104, 104, 122, 117, 172, 172, 170, 168, 170, 177, 172, 175, 150, 149, 152, 151,
            148, 151, 160, 159, 157, 157, 148, 133, 96, 90, 103, 107, 104, 104, 101, 100, 102, 102, 121, 117,
            170, 170, 169, 171, 171, 179, 173, 175, 149, 151, 152, 151, 148, 154, 162, 157, 154, 154, 151, 132,
            92, 89, 101, 108, 104, 102, 101, 101, 103, 103, 123, 118, 171, 168, 177, 173, 171, 178, 172, 176,
            152, 152, 152, 151, 154, 162, 161, 155, 149, 157, 156, 129, 92, 87, 101, 107, 102, 100, 107, 100,
            101, 102, 123, 118, 170, 175, 182, 172, 171, 179, 173, 175, 152, 151, 154, 155, 160, 162, 161, 153,
            150, 156, 153, 129, 92, 91, 102, 106, 100, 109, 115, 99, 101, 102, 124, 120, 171, 179, 178, 172,
            171, 181, 171, 173, 154, 154, 154, 162, 160, 158, 156, 152, 153, 157, 151, 128, 86, 86, 102, 105,
            102, 122, 114, 99, 101, 102, 125, 120, 178, 173, 177, 172, 171, 180, 172, 173, 154, 152, 158, 163,
            150, 148, 148, 156, 151, 158, 152, 129, 87, 87, 101, 105, 204, 204, 204, 204, 204, 204, 204, 204,
            204, 204, 204, 204, 204, 204, 204, 204, 154, 151, 165, 156, 141, 137, 146, 158, 152, 159, 152, 133,
            90, 88, 99, 106, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204,
            154, 160, 164, 150, 126, 127, 149, 159, 155, 161, 153, 131, 84, 86, 97, 103, 204, 204, 204, 204,
            204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 157, 167, 157, 137, 102, 128, 155, 161,
            157, 159, 154, 134, 84, 82, 97, 102, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204,
            204, 204, 204, 204, 163, 163, 150, 113, 78, 132, 156, 162, 159, 160, 154, 132, 83, 78, 91, 97, 204,
            204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 163, 157, 137, 80, 78,
            131, 154, 163, 157, 159, 149, 131, 82, 77, 94, 100, 204, 204, 204, 204, 204, 204, 204, 204, 204,
            204, 204, 204, 204, 204, 204, 204, 159, 151, 108, 72, 88, 132, 156, 162, 159, 157, 151, 130, 79, 78,
            95, 102, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 204, 151, 130,
            82, 82, 89, 134, 154, 161, 161, 157, 152, 129, 81, 77, 95, 102, 204, 204, 204, 204, 204, 204, 204,
            204, 204, 204, 204, 204, 204, 204, 204, 204
        };
        byte[] pred =
        {
            128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 129, 129, 129, 129,
            129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 128, 128, 128, 128, 128, 128, 128, 128,
            128, 128, 128, 128, 128, 128, 128, 128, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129,
            129, 129, 129, 129, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128,
            129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 128, 128, 128, 128,
            128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 129, 129, 129, 129, 129, 129, 129, 129,
            129, 129, 129, 129, 129, 129, 129, 129, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128,
            128, 128, 128, 128, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129,
            128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 129, 129, 129, 129,
            129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 128, 128, 128, 128, 128, 128, 128, 128,
            128, 128, 128, 128, 128, 128, 128, 128, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129,
            129, 129, 129, 129, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128,
            129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 128, 128, 128, 128,
            128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 129, 129, 129, 129, 129, 129, 129, 129,
            129, 129, 129, 129, 129, 129, 129, 129, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128,
            128, 128, 128, 128, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129,
            128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 129, 129, 129, 129,
            129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 128, 128, 128, 128, 128, 128, 128, 128,
            128, 128, 128, 128, 128, 128, 128, 128, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129,
            129, 129, 129, 129, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128,
            129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 128, 128, 128, 128,
            128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 129, 129, 129, 129, 129, 129, 129, 129,
            129, 129, 129, 129, 129, 129, 129, 129, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128,
            128, 128, 128, 128, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129,
            128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 129, 129, 129, 129,
            129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 127, 127, 127, 127, 127, 127, 127, 127,
            127, 127, 127, 127, 127, 127, 127, 127, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129,
            129, 129, 129, 129, 127, 127, 127, 127, 127, 127, 127, 127, 127, 127, 127, 127, 127, 127, 127, 127,
            129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 127, 127, 127, 127,
            127, 127, 127, 127, 127, 127, 127, 127, 127, 127, 127, 127, 129, 129, 129, 129, 129, 129, 129, 129,
            129, 129, 129, 129, 129, 129, 129, 129, 127, 127, 127, 127, 127, 127, 127, 127, 127, 127, 127, 127,
            127, 127, 127, 127, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129,
            127, 127, 127, 127, 127, 127, 127, 127, 127, 127, 127, 127, 127, 127, 127, 127, 129, 129, 129, 129,
            129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 127, 127, 127, 127, 127, 127, 127, 127,
            127, 127, 127, 127, 127, 127, 127, 127, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129,
            129, 129, 129, 129, 127, 127, 127, 127, 127, 127, 127, 127, 127, 127, 127, 127, 127, 127, 127, 127,
            129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 127, 127, 127, 127,
            127, 127, 127, 127, 127, 127, 127, 127, 127, 127, 127, 127, 129, 129, 129, 129, 129, 129, 129, 129,
            129, 129, 129, 129, 129, 129, 129, 129, 127, 127, 127, 127, 127, 127, 127, 127, 127, 127, 127, 127,
            127, 127, 127, 127, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129,
            127, 127, 127, 127, 127, 127, 127, 127, 127, 127, 127, 127, 127, 127, 127, 127, 129, 129, 129, 129,
            129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 127, 127, 127, 127, 127, 127, 127, 127,
            127, 127, 127, 127, 127, 127, 127, 127, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129,
            129, 129, 129, 129, 127, 127, 127, 127, 127, 127, 127, 127, 127, 127, 127, 127, 127, 127, 127, 127,
            129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 127, 127, 127, 127,
            127, 127, 127, 127, 127, 127, 127, 127, 127, 127, 127, 127, 129, 129, 129, 129, 129, 129, 129, 129,
            129, 129, 129, 129, 129, 129, 129, 129, 127, 127, 127, 127, 127, 127, 127, 127, 127, 127, 127, 127,
            127, 127, 127, 127, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129,
            127, 127, 127, 127, 127, 127, 127, 127, 127, 127, 127, 127, 127, 127, 127, 127, 129, 129, 129, 129,
            129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 127, 127, 127, 127, 127, 127, 127, 127,
            127, 127, 127, 127, 127, 127, 127, 127, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129,
            129, 129, 129, 129
        };
        int expectedAlpha = 146;

        // act
        histogram.CollectHistogram(reference, pred, 0, 10);
        int actualAlpha = histogram.GetAlpha();

        // assert
        Assert.Equal(expectedAlpha, actualAlpha);
    }

    [Fact]
    public void RunCollectHistogramTest_Works() => RunCollectHistogramTest();

    [Fact]
    public void GetAlpha_WithEmptyHistogram_Works()
    {
        // arrange
        var histogram = new Vp8Histogram();

        // act
        int alpha = histogram.GetAlpha();

        // assert
        Assert.Equal(0, alpha);
    }

    [Theory]
    [MemberData(nameof(Data))]
    public void GetAlpha_Works(byte[] reference, byte[] pred)
    {
        // arrange
        var histogram = new Vp8Histogram();
        histogram.CollectHistogram(reference, pred, 0, 1);

        // act
        int alpha = histogram.GetAlpha();

        // assert
        Assert.Equal(1054, alpha);
    }

    [Theory]
    [MemberData(nameof(Data))]
    public void Merge_Works(byte[] reference, byte[] pred)
    {
        // arrange
        var histogram1 = new Vp8Histogram();
        histogram1.CollectHistogram(reference, pred, 0, 1);
        var histogram2 = new Vp8Histogram();
        histogram1.Merge(histogram2);

        // act
        int alpha = histogram2.GetAlpha();

        // assert
        Assert.Equal(1054, alpha);
    }

    [Fact]
    public void CollectHistogramTest_WithHardwareIntrinsics_Works() => FeatureTestRunner.RunWithHwIntrinsicsFeature(RunCollectHistogramTest, HwIntrinsics.AllowAll);

    [Fact]
    public void CollectHistogramTest_WithoutHardwareIntrinsics_Works() => FeatureTestRunner.RunWithHwIntrinsicsFeature(RunCollectHistogramTest, HwIntrinsics.DisableHWIntrinsic);
}
