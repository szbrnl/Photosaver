using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSaver
{
    public class ImageCollection
    {

        public List<Image> Images
        {
            get => images;
        }



        private List<Image> images;

        public ImageCollection(string[] imagePaths)
        {
            images = new List<Image>();

            foreach (string imagePath in imagePaths)
            {
                Image img = new Image(imagePath);
                if(img.isValidImage()) images.Add(img);
            }
        }
    }
}
