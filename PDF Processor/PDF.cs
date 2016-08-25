using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ghostscript.NET;
using Ghostscript.NET.Rasterizer;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace PDF_Processor
{
    public class Pdf
    {
       public static void ToImages(string path)
        {
            using( var processor = new GhostscriptRasterizer())
            {
                processor.Open(path);
                int PageCount = processor.PageCount - 1;
                // Creates folder with the same name as the pdf file
                string ImageFolder = Path.GetDirectoryName(path) + @"\" + Path.GetFileNameWithoutExtension(path);
                // Folder and files with the same name will be overwritten
                Directory.CreateDirectory(ImageFolder);
                for (int i = 1; i <= PageCount; i++)
                {
                    using (Image img = processor.GetPage(300, 300, i))
                    {
                        string SaveDir = ImageFolder + @"\page " + i.ToString() + ".jpg";
                        img.Save(SaveDir, ImageFormat.Jpeg);
                    }
                }
            }          
        }      
    }
}
