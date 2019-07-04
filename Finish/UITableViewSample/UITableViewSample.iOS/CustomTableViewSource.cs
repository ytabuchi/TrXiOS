using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using UITableViewSample.Models;

namespace UITableViewSample.iOS
{
    public class CustomTableViewSource : UITableViewSource
    {
        private ViewController parentViewController;
        private List<Speaker> Items { get; set; } = new List<Speaker>();

        public CustomTableViewSource(ViewController parentViewController, List<Speaker> items)
        {
            this.parentViewController = parentViewController;
            this.Items = items;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = (CustomTableViewCell)tableView.DequeueReusableCell(nameof(CustomTableViewCell), indexPath);
            var item = Items[indexPath.Row];
            cell.Update(item);

            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return Items.Count;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            parentViewController.PerformSegue("DetailSegue", indexPath);
        }

        public Speaker GetSpeaker(int id)
        {
            return Items[id];
        }
    }
}

