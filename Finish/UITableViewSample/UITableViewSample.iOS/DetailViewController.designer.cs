// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace UITableViewSample.iOS
{
    [Register ("DetailViewController")]
    partial class DetailViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView Avator { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextView Description { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel Name { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (Avator != null) {
                Avator.Dispose ();
                Avator = null;
            }

            if (Description != null) {
                Description.Dispose ();
                Description = null;
            }

            if (Name != null) {
                Name.Dispose ();
                Name = null;
            }
        }
    }
}