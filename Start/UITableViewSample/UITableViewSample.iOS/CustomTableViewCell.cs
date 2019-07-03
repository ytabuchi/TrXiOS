using System;

using Foundation;
using UIKit;

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

        
    }
}
