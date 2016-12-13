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
using UITableViewSample.iOS.Models;
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

            
            #region PropertyChangedを使用する場合
            //vm.PropertyChanged += Vm_PropertyChanged;
            #endregion
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        #region PropertyChangedを使用する場合
        //private void Vm_PropertyChanged(object sender, PropertyChangedEventArgs e)
        //{
        //    GetSpeakersButton.Enabled = !((SpeakersModel)sender).IsBusy;
        //}
        #endregion
    }
}

