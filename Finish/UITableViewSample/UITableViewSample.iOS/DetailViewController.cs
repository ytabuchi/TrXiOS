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

            Avator.Image = await Helpers.ImageManager.LoadImageAsync(speaker.Avatar);
            Name.Text = speaker.Name;
            Description.Text = speaker.Description;
        }

        public void SetSpeaker(Speaker speaker)
        {
            this.speaker = speaker;
        }
    }
}