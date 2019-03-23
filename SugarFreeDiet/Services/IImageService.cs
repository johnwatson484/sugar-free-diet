using System.Web;

namespace SugarFreeDiet.Services
{
    public interface IImageService
    {
        byte[] GetImageFromFile(HttpPostedFileBase file);
        byte[] GetThumbnail(byte[] originalImage);
    }
}