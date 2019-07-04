using System;
using System.Net.Http;
using System.Threading.Tasks;
using Foundation;
using UIKit;

namespace UITableViewSample.iOS.Helpers
{
    public static class ImageManager
    {
        public static async Task<UIImage> LoadImageAsync(string imageUrl)
        {
            if (string.IsNullOrEmpty(imageUrl))
                return UIImage.FromBundle("DefaultAvator");

            var httpClient = new HttpClient();
            byte[] contents = await httpClient.GetByteArrayAsync(imageUrl);

            // load from bytes
            return UIImage.LoadFromData(NSData.FromArray(contents));
        }
    }
}
