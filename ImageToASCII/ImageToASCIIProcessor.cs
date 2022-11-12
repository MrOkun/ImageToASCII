using FastBitmapLib;
using OkunGraphicLibrary.Algorithm;
using OkunGraphicLibrary.Base;
using System.Drawing;
using System.Text;

namespace ImageToASCII
{
    public class ImageToASCIIProcessor
    {
        public string Process(Bitmap bitmap, string palette)
        {
            var colorConversion = new ColorConversion();
            bitmap = colorConversion.Averge(bitmap);

            FastBitmap fBitmap = new FastBitmap((Bitmap)bitmap.Fix());

            Console.WriteLine($"Image size is {fBitmap.Width}, {fBitmap.Height}");

            fBitmap.Lock();

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < fBitmap.Height; i++)
            {
                sb.Append('\n');

                for (int j = 0; j < fBitmap.Width; j++)
                {
                    Color color = fBitmap.GetPixel(j, i);

                    int grayColorCoef = (int)Math.Round((double)(color.R + color.G + color.B) / 3, 0);

                    int index = (int)Math.Round((decimal)palette.Length / 300 * grayColorCoef, 0);

                    sb.Append(palette[index]);
                    sb.Append(palette[index]);
                }
            }

            fBitmap.Unlock();

            return sb.ToString();
        }
    }
}