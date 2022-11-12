using System.Drawing;
using System.Text;
using FastBitmapLib;
using OkunGraphicLibrary.Algorithm;
using OkunGraphicLibrary.Base;
using ImageToASCII;

namespace ASCIIGenerator
{
    internal class Program
    {
        private static string palette = "$@B%8&WM#*oahkbdpqwmZO0QLCJUYXzcvunxrjft/\\|()1{}[]?-_+~<>i!lI;:,\" ^`'. ";

        static void Main(string[] args)
        {
            Bitmap bitmap = (Bitmap)Bitmap.FromFile("img.png");

            var imageToASCIIProcessor = new ImageToASCIIProcessor();

            var ascii = imageToASCIIProcessor.Process(bitmap, palette);

            using (StreamWriter sw = new("output.txt"))
            {
                sw.Write(ascii);
            }

            Console.WriteLine(ascii);
        }
    }
}