using System;
using Foundation;
using UIKit;

namespace UITableViewCoded.Views
{
    public class PlainTableSource : UITableViewSource
    {
        protected string[] tableItems;
        protected string cellIdentifier = "TableCell";

        public PlainTableSource(string[] tableitems)
        {
            this.tableItems = tableitems;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            UITableViewCell cell = tableView.DequeueReusableCell(cellIdentifier);
            string item = tableItems[indexPath.Row];

            // 再利用できるセルがなければ新規作成する。
            if (cell == null)
                cell = new UITableViewCell(UITableViewCellStyle.Default, cellIdentifier);

            cell.TextLabel.Text = item;

            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return tableItems.Length;
        }
    }
}
