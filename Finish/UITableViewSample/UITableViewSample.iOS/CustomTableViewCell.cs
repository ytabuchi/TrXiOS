using System;
using System.Net.Http;
using System.Threading.Tasks;
using Foundation;
using UIKit;
using UITableViewSample.Models;

namespace UITableViewSample.iOS
{
    public partial class CustomTableViewCell : UITableViewCell
    {
        public static readonly NSString Key = new NSString("CustomTableViewCell");
        public static readonly UINib Nib;

        static CustomTableViewCell()
        {
            Nib = UINib.FromName("CustomTableViewCell", NSBundle.MainBundle);
        }

        protected CustomTableViewCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        /// <summary>
        /// データを流し込むためのUpdateメソッド
        /// </summary>
        /// <param name="speaker"></param>
        public async void Update(Speaker speaker)
        {
            NameLabel.Text = speaker.Name;
            TitleLabel.Text = speaker.Title;
            AvatorImage.Image = await LoadImage(speaker.Avatar);

            AvatorImage.Layer.CornerRadius = AvatorImage.Bounds.Height / 2;
            AvatorImage.Layer.BorderWidth = 2;
            AvatorImage.Layer.BorderColor = UIColor.FromRGB(0x34, 0x98, 0xdb).CGColor;
            AvatorImage.ClipsToBounds = true;
        }

        private async Task<UIImage> LoadImage(string imageUrl)
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
