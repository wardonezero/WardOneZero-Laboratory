using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.PixelFormats;
using System.Globalization;

namespace WardOneZeroLaboratory.Client.Services;

public class ImageService
{
    public Image DecodeBase64ToImage(string imageBase64)
    {
        byte[] imageBytes = Convert.FromBase64String(imageBase64);
        return Image.Load(imageBytes);
    }

    public List<string> GetPixelsHexColor(Image bitmap)
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
    }

    public List<string> ChangeImageColor(List<string> pixels)
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
    }

    public Image PixelsToBitmap(List<string> pixels, int width, int height)
    {
        Image<Rgba32> image = new(width, height);
        int pixelIndex = 0;
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                string hex = pixels[pixelIndex++];
                byte r = byte.Parse(hex.AsSpan(0, 2), NumberStyles.HexNumber);
                byte g = byte.Parse(hex.AsSpan(2, 2), NumberStyles.HexNumber);
                byte b = byte.Parse(hex.AsSpan(4, 2), NumberStyles.HexNumber);
                image[x, y] = new Rgba32(r, g, b);
            }
        }
        return image;
    }

    public string BitmapToBase64(Image bitmap)
    {
        return bitmap.ToBase64String(PngFormat.Instance);
    }
}

