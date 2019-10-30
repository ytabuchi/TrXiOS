using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

using UIKit;
using Foundation;
using CoreGraphics;

namespace UITableViewCoded.Views
{
    [Register("SimpleViewController")]
    public class SimpleViewController : UIViewController
    {
        // ここにUIエレメントを割り当てるフィールドを追加
        UILabel NowLabel { get; set; }
        UIButton UpdateButton { get; set; }

        // UI 作成
        private void InitUI()
        {
            View.ContentMode = UIViewContentMode.ScaleToFill;
            View.Frame = new CGRect(0, 0, 375, 667);
            View.BackgroundColor = UIColor.FromRGBA(1f, 1f, 1f, 1f);
            View.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight;

            NowLabel = new UILabel
            {
                Frame = new CGRect(16, 40, 343, 21),
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
                //TextColor = UIColor.FromRGBA(0.0f, 0.0f, 0.0f, 1.0f), // Default の場合はなしでも OK
            };
            NowLabel.SetContentHuggingPriority(251f, UILayoutConstraintAxis.Horizontal);
            NowLabel.SetContentHuggingPriority(251f, UILayoutConstraintAxis.Horizontal);
            View.AddSubview(NowLabel);

            UpdateButton = new UIButton
            {
                Frame = new CGRect(16, 71, 343, 30),
                Opaque = false,
                ContentMode = UIViewContentMode.ScaleToFill,
                HorizontalAlignment = UIControlContentHorizontalAlignment.Center,
                VerticalAlignment = UIControlContentVerticalAlignment.Center,
                LineBreakMode = UILineBreakMode.MiddleTruncation,
                TranslatesAutoresizingMaskIntoConstraints = false,
                BackgroundColor = UIColor.FromRGBA(0.8f, 0.8f, 0.8f, 0.5f),
            };
            UpdateButton.SetTitleColor(UIColor.FromRGBA(0.3f, 0.3f, 1.0f, 1.0f), UIControlState.Normal);
            UpdateButton.SetTitle("Update time", UIControlState.Normal);
            UpdateButton.Layer.CornerRadius = 4f;
            UpdateButton.TouchUpInside += (s, e) => UpdateTime();
            View.AddSubview(UpdateButton);

            // NowLabel の Constraints
            View.AddConstraint(NSLayoutConstraint.Create(NowLabel, NSLayoutAttribute.Top, NSLayoutRelation.Equal, View.SafeAreaLayoutGuide, NSLayoutAttribute.Top, 1.0f, 40f));
            View.AddConstraint(NSLayoutConstraint.Create(NowLabel, NSLayoutAttribute.Leading, NSLayoutRelation.Equal, View.SafeAreaLayoutGuide, NSLayoutAttribute.Leading, 1.0f, 16f));
            View.AddConstraint(NSLayoutConstraint.Create(View.SafeAreaLayoutGuide, NSLayoutAttribute.Trailing, NSLayoutRelation.Equal, NowLabel, NSLayoutAttribute.Trailing, 1.0f, 16f));
            // UpdateButton の Constraints
            View.AddConstraint(NSLayoutConstraint.Create(UpdateButton, NSLayoutAttribute.Top, NSLayoutRelation.Equal, NowLabel, NSLayoutAttribute.Bottom, 1.0f, 15f));
            View.AddConstraint(NSLayoutConstraint.Create(UpdateButton, NSLayoutAttribute.Leading, NSLayoutRelation.Equal, View.SafeAreaLayoutGuide, NSLayoutAttribute.Leading, 1.0f, 16f));
            View.AddConstraint(NSLayoutConstraint.Create(View.SafeAreaLayoutGuide, NSLayoutAttribute.Trailing, NSLayoutRelation.Equal, UpdateButton, NSLayoutAttribute.Trailing, 1.0f, 16f));
        }


        public SimpleViewController()
            : base()
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            View.BackgroundColor = UIColor.FromRGBA(1.0f, 1.0f, 1.0f, 1f);
            
            InitUI();
        }

        private void UpdateTime()
        {
            NowLabel.Text = $"Time: {DateTime.Now.ToString("HH:mm:ss")}";
        }
    }
}
