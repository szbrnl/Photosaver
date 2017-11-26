using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSaver.ViewModels;

namespace PhotoSaver
{
    public static class FileSaver
    {
        public static void SavePhotos(List<ImageViewModel> images, string path)
        {
            path = "C:\\Nowyfolderhehe\\";

            int number = 0;
            Directory.CreateDirectory(path);

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
