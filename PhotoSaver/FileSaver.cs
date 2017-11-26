using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using PhotoSaver.ViewModels;
using System.IO;
using System.Windows;

namespace PhotoSaver
{
    public static class FileSaver
    {
        public static void SavePhotos(List<ImageViewModel> images, string path)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.ShowDialog();
            path = dialog.FileName;    

            int number = 0;  
            foreach (var imageViewModel in images)
            {
                Bitmap bmp = new Bitmap(imageViewModel.ImagePath);
                bmp.Save(path+$"_{number}.jpg");

                bmp.Dispose();
                number++;
            }
        }
    }
}
