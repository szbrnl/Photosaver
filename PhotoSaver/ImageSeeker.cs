using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSaver
{
    public class ImageSeeker
    {
        public static string[] GetImagesFromAppData()
        {
            string path = new FileInfo(Environment.ExpandEnvironmentVariables("%AppData%") +
                                       "\\..\\Local\\Packages\\Microsoft.Windows.ContentDeliveryManager_cw5n1h2txyewy\\LocalState\\Assets")
                .FullName;

            string[] fileEntries = Directory.GetFiles(path);

            return fileEntries;
        }
    }
}
