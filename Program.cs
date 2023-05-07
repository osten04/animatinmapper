#pragma warning disable CA1416 // Validate platform compatibility
#pragma warning disable CS8604 // Possible null reference argument.
using System.Drawing;
using System.Drawing.Imaging;

namespace Pixelart
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            Bitmap Map;

            while (true)
            {
                Console.Write("Map Name : ");  
                try
                {
                    Map = new(Image.FromFile(Console.ReadLine()));

                    break;
                }
                catch (Exception e) { Console.WriteLine(e.Message); }
            }

            Bitmap Texture;

            while (true)
            {
                Console.Write("Texture Name : ");
                try
                {
                    Texture = new(Image.FromFile(Console.ReadLine()));
                    break;
                }
                catch (Exception e) { Console.WriteLine(e.Message); }
            }

            Dictionary<Color, Color> Colormap = new();

            for (int y = 0; y < Map.Height; y++)
            {
                for (int x = 0; x < Map.Width; x++)
                {
                    if(Texture.GetPixel(x,y).A != 0)
                    {
                        try
                        {
                            Colormap.Add(Map.GetPixel(x, y), Texture.GetPixel(x, y));
                        }
                        catch (ArgumentException) { }
                    }
                }
            }

            String AnimationPath;

            while (true)
            {
                Console.Write("Animation Name : ");
                try
                {
                    AnimationPath = Console.ReadLine();
                    break;
                }
                catch (Exception e) { Console.WriteLine(e.Message); }
            }
            for (int i = 0; i < Directory.GetFiles(AnimationPath).Length; i++)
            {
                Bitmap final = new(Map.Width, Map.Height);

                Bitmap Animation = new(Image.FromFile(Directory.GetFiles(AnimationPath)[i]));

                for (int y = 0; y < Map.Height; y++)
                {
                    for (int x = 0; x < Map.Width; x++)
                    {
                        if (Animation.GetPixel(x, y).A != 0)
                        {
                            final.SetPixel(x, y, Colormap[Animation.GetPixel(x, y)]);
                        }
                    }
                }

                final.Save(i + ".png", ImageFormat.Png);
            }
        }
    }
}