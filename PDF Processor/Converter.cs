using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDF_Processor
{
    public class Converter
    {
        public static string Dir = string.Empty;
        public static string DirDest = string.Empty;

        public static void Convert()
        {
            // Get values from UI
            MainWindow.UI.Dispatcher.Invoke((Action)(() =>
            {
                MainWindow.UI.LogBox.Text += "Starting pdf processor.\n\n";
                MainWindow.UI.LogBox.Text += "Processing...";
                Dir = MainWindow.UI.SourceF.Text;
                DirDest = MainWindow.UI.DestF.Text;
            }));

            //Process all images in folder and subfolders
            ProcessDirectory(Dir);

            //Log status
            MainWindow.UI.Dispatcher.Invoke((Action)(() =>
            {
                MainWindow.UI.LogBox.Text += "Finished.\n";
            }));
        }

        public static void ProcessDirectory(string Dir)
        {
            string[] fileEntries = Directory.GetFiles(Dir);
            foreach (string fileName in fileEntries)
            {
                if (Path.GetExtension(fileName) == ".pdf" || Path.GetExtension(fileName) == ".PDF")
                {
                    Pdf.ToImages(fileName);
                }
                
            }
            // Recursion for subdirectories
            string[] subdirectoryEntries = Directory.GetDirectories(Dir);
            foreach (string subdirectory in subdirectoryEntries)
            {
                ProcessDirectory(subdirectory);
            }
        }
    }
}
