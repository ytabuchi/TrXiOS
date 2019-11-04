using System;
using CoreGraphics;
using UIKit;

namespace UITableViewCoded.Views
{
    public partial class SimpleViewController
    {
        // UI エレメントのフィールド
        UILabel timeLabel { get; set; }
        UIButton updateButton { get; set; }
        UIButton navigateButton { get; set; }

        void InitializeUI()
        {
            // View の設定。
            View.ContentMode = UIViewContentMode.ScaleToFill;
            View.Frame = new CGRect(0, 0, 375, 667);
            View.BackgroundColor = UIColor.White;
            View.AutoresizingMask = UIViewAutoresizing.FlexibleWidth
                | UIViewAutoresizing.FlexibleHeight;

            timeLabel = new UILabel
            {
                Frame = new CGRect(0, 0, 343, 21),
                UserInteractionEnabled = false,
                ContentMode = UIViewContentMode.Left,
                Text = "Time: ",
                TextAlignment = UITextAlignment.Left,
                LineBreakMode = UILineBreakMode.TailTruncation,
                Lines = 0,
                BaselineAdjustment = UIBaselineAdjustment.AlignBaselines,
                AdjustsFontSizeToFitWidth = false,
                TranslatesAutoresizingMaskIntoConstraints = false,
                //BackgroundColor = UIColor.FromRGBA(0.8f, 0.8f, 0.8f, 1.0f), // Default の場合はなしでも OK
                Font = UIFont.SystemFontOfSize(17f),
            };
            timeLabel.SetContentHuggingPriority(251f, UILayoutConstraintAxis.Horizontal);
            timeLabel.SetContentHuggingPriority(251f, UILayoutConstraintAxis.Horizontal);
            View.AddSubview(timeLabel);

            updateButton = new UIButton(UIButtonType.RoundedRect)
            {
                Frame = new CGRect(0, 0, 343, 30),
                Opaque = false,
                ContentMode = UIViewContentMode.ScaleToFill,
                HorizontalAlignment = UIControlContentHorizontalAlignment.Center,
                VerticalAlignment = UIControlContentVerticalAlignment.Center,
                LineBreakMode = UILineBreakMode.MiddleTruncation,
                TranslatesAutoresizingMaskIntoConstraints = false,
                Font = UIFont.SystemFontOfSize(15f),
            };
            updateButton.SetTitle("Update time", UIControlState.Normal);
            updateButton.TouchUpInside += (s, e) => UpdateTime();
            View.AddSubview(updateButton);

            navigateButton = new UIButton(UIButtonType.RoundedRect)
            {
                Frame = new CGRect(0, 0, 343, 30),
                Opaque = false,
                ContentMode = UIViewContentMode.ScaleToFill,
                HorizontalAlignment = UIControlContentHorizontalAlignment.Center,
                VerticalAlignment = UIControlContentVerticalAlignment.Center,
                LineBreakMode = UILineBreakMode.MiddleTruncation,
                TranslatesAutoresizingMaskIntoConstraints = false,
                Font = UIFont.SystemFontOfSize(15f),
            };
            navigateButton.SetTitle("Next Page", UIControlState.Normal);
            navigateButton.TouchUpInside += (s, e) => Navigate();
            View.AddSubview(navigateButton);

            // 元のフィールドにアンカーを追加していくやり方
            // NowLabel の Constraints
            timeLabel.TopAnchor.ConstraintEqualTo(View.SafeAreaLayoutGuide.TopAnchor, 10f).Active = true;
            timeLabel.LeftAnchor.ConstraintEqualTo(View.LayoutMarginsGuide.LeftAnchor).Active = true;
            timeLabel.RightAnchor.ConstraintEqualTo(View.LayoutMarginsGuide.RightAnchor).Active = true;
            // UpdateButton の Constraints
            updateButton.TopAnchor.ConstraintEqualTo(timeLabel.BottomAnchor, 10f).Active = true;
            updateButton.LeftAnchor.ConstraintEqualTo(View.LayoutMarginsGuide.LeftAnchor).Active = true;
            updateButton.RightAnchor.ConstraintEqualTo(View.LayoutMarginsGuide.RightAnchor).Active = true;

            // 1st View, 2nd View を指定して Constraint を追加するやり方。（Storyboard のコードではこの書き方になっている。順番に注意。
            // NavigateButton の Constraints
            View.AddConstraint(NSLayoutConstraint.Create(navigateButton, NSLayoutAttribute.Top, NSLayoutRelation.Equal, updateButton, NSLayoutAttribute.Bottom, 1.0f, 15f));
            View.AddConstraint(NSLayoutConstraint.Create(navigateButton, NSLayoutAttribute.Leading, NSLayoutRelation.Equal, View.SafeAreaLayoutGuide, NSLayoutAttribute.Leading, 1.0f, 16f));
            View.AddConstraint(NSLayoutConstraint.Create(View.SafeAreaLayoutGuide, NSLayoutAttribute.Trailing, NSLayoutRelation.Equal, navigateButton, NSLayoutAttribute.Trailing, 1.0f, 16f));
        }
    }
}
