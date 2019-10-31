using System;
using CoreGraphics;
using UIKit;

namespace UITableViewCoded.Views
{
    public partial class SpeakersViewController
    {
        UIButton getSpeakersButton;
        UITableView speakersTable;

        void InitializeUI()
        {
            View.ContentMode = UIViewContentMode.ScaleToFill;
            View.LayoutMargins = new UIEdgeInsets(0, 16, 0, 16);
            View.Frame = new CGRect(0, 0, 375, 667);
            View.BackgroundColor = UIColor.White;
            View.AutoresizingMask = UIViewAutoresizing.FlexibleWidth
                                    | UIViewAutoresizing.FlexibleHeight;


            getSpeakersButton = new UIButton(UIButtonType.RoundedRect)
            {
                Frame = new CGRect(0, 0, 375, 30),
                Opaque = false,
                ContentMode = UIViewContentMode.ScaleToFill,
                HorizontalAlignment = UIControlContentHorizontalAlignment.Center,
                VerticalAlignment = UIControlContentVerticalAlignment.Center,
                LineBreakMode = UILineBreakMode.MiddleTruncation,
                TranslatesAutoresizingMaskIntoConstraints = false,
                Font = UIFont.SystemFontOfSize(15f),

            };
            getSpeakersButton.SetTitle("Get speakers", UIControlState.Normal);
            getSpeakersButton.TouchUpInside += (s, e) => getSpeakersAsync();
            View.AddSubview(getSpeakersButton);

            var tableViewCell = new UITableViewCell
            {
                SelectionStyle = UITableViewCellSelectionStyle.Default,
                
            };

            speakersTable = new UITableView(new CGRect(0, 40, 375, 400), UITableViewStyle.Plain)
            {
                Opaque = false,
                ContentMode = UIViewContentMode.ScaleToFill, // 表示を Constrains に合うようにスケールする（？）
                TranslatesAutoresizingMaskIntoConstraints = false,
                AlwaysBounceVertical = true,
            };
            View.AddSubview(speakersTable);

            getSpeakersButton.TopAnchor.ConstraintEqualTo(View.SafeAreaLayoutGuide.TopAnchor, 10f).Active = true;
            getSpeakersButton.LeftAnchor.ConstraintEqualTo(View.LayoutMarginsGuide.LeftAnchor).Active = true;
            getSpeakersButton.RightAnchor.ConstraintEqualTo(View.LayoutMarginsGuide.RightAnchor).Active = true;

            speakersTable.TopAnchor.ConstraintEqualTo(getSpeakersButton.BottomAnchor, 10f).Active = true;
            speakersTable.LeftAnchor.ConstraintEqualTo(View.LeftAnchor).Active = true;
            speakersTable.RightAnchor.ConstraintEqualTo(View.RightAnchor).Active = true;
            speakersTable.BottomAnchor.ConstraintEqualTo(View.BottomAnchor).Active = true;

        }
    }
}
