using System;
using Foundation;
using UIKit;

namespace UITableViewCoded.Views
{
    [Register(nameof(SecondViewController))]
    public partial class SecondViewController : UIViewController
    {
        
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Title = "SecondView";
            InitializeUI();
        }
    }
}
