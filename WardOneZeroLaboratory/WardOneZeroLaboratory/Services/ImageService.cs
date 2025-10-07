using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System.Globalization;

namespace WardOneZeroLaboratory.Services;

public static class ImageService
{
    public static Task<List<string>> GetPixelsHexColorAsync(Image bitmap)
    {
        return Task.Run(() =>
        {
            Image<Rgba32> image = bitmap.CloneAs<Rgba32>();
            List<string> hexColors = [];
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    Rgba32 pixelColor = image[x, y];
                    string hexColor = $"{pixelColor.R:X2}{pixelColor.G:X2}{pixelColor.B:X2}";
                    hexColors.Add(hexColor);
                }
            }
            return hexColors;
        });
    }

    public static Task<List<string>> ChangeImageColorAsync(List<string> pixels)
    {
        return Task.Run(() =>
        {
            List<string> newPixels = new(pixels.Count);
            foreach (string pixel in pixels)
            {
                char r = pixel[0];
                char g = pixel[2];
                char b = pixel[4];
                newPixels.Add($"{r}{r}{g}{g}{b}{b}");
            }
            return newPixels;
        });
    }

    public static Task<Image> PixelsToBitmapAsync(List<string> pixels, int width, int height)
    {
        return Task.Run<Image>(() =>
        {
            Image<Rgba32> image = new(width, height);
            int pixelIndex = 0;
            for (int w = 0; w < width; w++)
            {
                for (int h = 0; h < height; h++)
                {
                    string hex = pixels[pixelIndex++];
                    byte r = byte.Parse(hex.AsSpan(0, 2), NumberStyles.HexNumber);
                    byte g = byte.Parse(hex.AsSpan(2, 2), NumberStyles.HexNumber);
                    byte b = byte.Parse(hex.AsSpan(4, 2), NumberStyles.HexNumber);
                    image[w, h] = new Rgba32(r, g, b);
                }
            }
            return image;
        });
    }

    public static async Task<string> BitmapToBase64Async(Image bitmap)
    {
        using MemoryStream stream = new();
        await bitmap.SaveAsPngAsync(stream);
        return Convert.ToBase64String(stream.ToArray());
    }
}

