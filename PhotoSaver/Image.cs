using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSaver
{
    public class Image
    {
        private string imagePath;
        private string name;

        public bool isValidImage()
        {
            Bitmap bmp = new Bitmap(imagePath);
            if (bmp.Height > bmp.Width) return false;
            if (bmp.Height < 500 || bmp.Width < 500) return false;

            bmp.Dispose();

            return true;
        }

        public string ImagePath
        {
            get => imagePath;
        }

        public Image(string path)
        {
            imagePath = path;
            
            
        }
    }
}
