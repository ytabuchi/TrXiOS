using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

using UIKit;
using Foundation;
using CoreGraphics;

namespace UITableViewCoded.Views
{
    [Register(nameof(SimpleViewController))]
    public partial class SimpleViewController : UIViewController
    {
        public SimpleViewController()
            : base()
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            InitializeUI();
        }

        private void UpdateTime()
        {
            timeLabel.Text = $"Time: {DateTime.Now.ToString("HH:mm:ss")}";
        }

        private void Navigate()
        {
            var speakerController = new SpeakersViewController();
            ShowViewController(speakerController, null);
        }
    }
}
