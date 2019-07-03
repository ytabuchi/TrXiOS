using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Foundation;
using UIKit;
using SVProgressHUDBinding;
using UITableViewSample.Models;

namespace UITableViewSample.iOS
{
    public partial class ViewController : UIViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var vm = new SpeakersModel();

            CustomTableView.RowHeight = 70;
            CustomTableView.RegisterNibForCellReuse(CustomTableViewCell.Nib, nameof(CustomTableViewCell));

            GetSpeakersButton.TouchUpInside += async (sender, e) =>
            {
                // ボタンを利用不可、グルグルを表示にします。
                GetSpeakersButton.Enabled = false;
                SVProgressHUD.Show();

                await vm.GetSpeakersAsync();

                // TableViewのSourceをCustomTableViewSourceでnewします。
                CustomTableView.Source = new CustomTableViewSource(vm.Speakers);
                CustomTableView.ReloadData();

                // グルグルを非表示、ボタンを利用可にします。
                SVProgressHUD.Dismiss();
                GetSpeakersButton.Enabled = true;
            };
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

