using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;

namespace SugarFreeDiet.Services
{
    public class ImageService : IImageService
    {
        public byte[] GetImageFromFile(HttpPostedFileBase file)
        {
            var image = new byte[file.ContentLength];
            file.InputStream.Read(image, 0, image.Length);
            return image;
        }

        public byte[] GetThumbnail(byte[] originalImage)
        {
            Image image;

            using (var ms = new MemoryStream(originalImage))
            {
                image = Image.FromStream(ms);
            }

            int imgHeight = 200;
            int imgWidth = 300;

            if (image.Width < image.Height)
            {
                //portrait image                  
                var imgRatio = (float)imgHeight / (float)image.Height;
                imgWidth = Convert.ToInt32(image.Height * imgRatio);
            }
            else if (image.Height < image.Width)
            {
                //landscape image
                var imgRatio = (float)imgWidth / (float)image.Width;
                imgHeight = Convert.ToInt32(image.Height * imgRatio);
            }

            Image thumb = image.GetThumbnailImage(imgWidth, imgHeight, () => false, IntPtr.Zero);

            using (MemoryStream ms = new MemoryStream())
            {
                thumb.Save(ms, ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }
    }
}