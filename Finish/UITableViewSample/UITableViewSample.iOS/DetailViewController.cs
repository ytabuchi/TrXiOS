using Foundation;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using UIKit;
using UITableViewSample.Models;

namespace UITableViewSample.iOS
{
    public partial class DetailViewController : UIViewController
    {
        Speaker speaker;

        public DetailViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
        }

        public override async void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            Avatar.Image = await Helpers.ImageManager.LoadImageAsync(speaker.Avatar);
            Name.Text = speaker.Name;
            Title.Text = speaker.Title;
            Description.Text = speaker.Description;
            Description.SizeToFit();
        }

        public void SetSpeaker(Speaker speaker)
        {
            this.speaker = speaker;
        }
    }
}