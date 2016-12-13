using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using UITableViewSample.iOS.Models;

namespace UITableViewSample.iOS
{
    public class CustomTableViewSource
    {
        private List<TableItem> Items { get; set; } = new List<TableItem>();

        public CustomTableViewSource(List<TableItem> items)
        {
            this.Items = items;
        }

    }
}

