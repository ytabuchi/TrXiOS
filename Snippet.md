### コードスニペット

Webサイトまたはmarkdownプレビューとして表示している場合は、それぞれの枠内をコピー＆ペーストしてください。
メモ帳などのテキストエディタで開いている場合は、```csharp と ``` の間の行をコピー＆ペーストしてください。

順次コードを張り付けていく部分もスニペットを用意していますが、その後の完成形も用意してありますので、適宜ご利用ください。

```csharp
public string Id { get; set; }
public string Name { get; set; }
public string Description { get; set; }
public string Website { get; set; }
public string Title { get; set; }
public string Avatar { get; set; }
```


```csharp
public bool IsBusy { get; set; }
public ObservableCollection<Speaker> Speakers { get; set; } = new ObservableCollection<Speaker>();
```

```csharp
public async Task GetSpeakersAsync()
{
  if(IsBusy)
    return;
}
```

```csharp
Exception error = null;
try
{
  IsBusy = true;
}
catch (Exception ex)
{
  error = ex;
}
finally
{
  IsBusy = false;
}
```

```csharp
using(var client = new HttpClient())
{
  // サーバーから json を取得します
  var json = await client.GetStringAsync("http://demo4404797.mockable.io/speakers");
}
```

```csharp
var items = JsonConvert.DeserializeObject<ObservableCollection<Speaker>>(json);
```

```csharp
Speakers.Clear();
foreach (var item in items)
  Speakers.Add(item);
```

```csharp
System.Diagnostics.Debug.WriteLine("Error: " + ex);
error = ex;
```


#### `GetSpeakersAsync`完成形

```csharp
public async Task GetSpeakersAsync()
{
    if (IsBusy)
        return;

    Exception error = null;
    try
    {
        IsBusy = true;

        using (var client = new HttpClient())
        {
            // サーバーから json を取得します
            var json = await client.GetStringAsync("http://demo4404797.mockable.io/speakers");
            var items = JsonConvert.DeserializeObject<ObservableCollection<Speaker>>(json);

            Speakers.Clear();
            foreach (var item in items)
                Speakers.Add(item);
        }
    }
    catch (Exception ex)
    {
        System.Diagnostics.Debug.WriteLine("Error: " + ex);
        error = ex;
    }
    finally
    {
        IsBusy = false;
    }
}
```

```csharp
var vm = new UITableViewSample.Models.SpeakersModel();
```

```csharp
GetSpeakersButton.TouchUpInside += async (sender, e) =>
{
    // vmのGetSpeakersメソッドを実行します。
    await vm.GetSpeakersAsync();
};
```

```csharp
protected string[] tableItems;
protected string cellIdentifier = "TableCell";

public TableSource(string[] tableitems)
{
    this.tableItems = tableitems;
}
```

```csharp
public class TableSource : UITableViewSource
```

```csharp
return tableItems.Length;
```

```csharp
UITableViewCell cell = tableView.DequeueReusableCell(cellIdentifier);
string item = tableItems[indexPath.Row];

// 再利用できるセルがなければ新規作成する。
if (cell == null)
    cell = new UITableViewCell(UITableViewCellStyle.Default, cellIdentifier);

cell.TextLabel.Text = item;

return cell;
```

#### `TableSource`完成形

```csharp
public class TableSource : UITableViewSource
{
    protected string[] tableItems;
    protected string cellIdentifier = "TableCell";

    public TableSource(string[] tableitems)
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
```


```csharp
public void Update(TableItem item)
{
    NameLabel.Text = item.Name;
    TitleLabel.Text = item.Title;
    AvatorImage.Image = item.Image;

    // ImageViewに枠線を追加。
    AvatorImage.Layer.CornerRadius = AvatorImage.Bounds.Height / 2;
    AvatorImage.Layer.BorderWidth = 2;
    AvatorImage.Layer.BorderColor = UIColor.FromRGB(0x34, 0x98, 0xdb).CGColor;
    AvatorImage.ClipsToBounds = true;
}
```

#### `CustomTableViewCell `完成形

```csharp
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

    /// <summary>
    /// データを流し込むためのUpdateメソッド
    /// </summary>
    /// <param name="item"></param>
    public void Update(TableItem item)
    {
        NameLabel.Text = item.Name;
        TitleLabel.Text = item.Title;
        AvatorImage.Image = item.Image;

        AvatorImage.Layer.CornerRadius = AvatorImage.Bounds.Height / 2;
        AvatorImage.Layer.BorderWidth = 2;
        AvatorImage.Layer.BorderColor = UIColor.FromRGB(0x34, 0x98, 0xdb).CGColor;
        AvatorImage.ClipsToBounds = true;
    }
}
```


```csharp
public class CustomTableViewSource : UITableViewSource
```

```csharp
var cell = (CustomTableViewCell)tableView.DequeueReusableCell(nameof(CustomTableViewCell), indexPath);
var item = Items[indexPath.Row];
cell.Update(item);
return cell;
```

```csharp
return Items.Count;
```

#### `CustomTableViewSource`完成形

```csharp
public class CustomTableViewSource : UITableViewSource
{
    private List<TableItem> Items { get; set; } = new List<TableItem>();

    public CustomTableViewSource(List<TableItem> items)
    {
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
}
```


```csharp
CustomTableView.RowHeight = 70;
CustomTableView.RegisterNibForCellReuse(CustomTableViewCell.Nib, nameof(CustomTableViewCell));
```

```csharp
// ボタンを利用不可、グルグルを表示にします。
GetSpeakersButton.Enabled = false;
SVProgressHUD.Show();

// vmのGetSpeakersメソッドを実行します。
await vm.GetSpeakersAsync();

// Name、Title、UIImageのプロパティを持つTableItemのListにデータを移し替えます。
// 移し替える前にImageUrlをUIImageに変換して格納します。
var tableItems = new List<TableItem>();
foreach (var x in vm.Speakers)
{
    var image = await this.LoadImage(x.Avatar);
    tableItems.Add(new TableItem(x.Name, x.Title, image));
}

// TableViewのSourceをCustomTableViewSourceでnewします。
CustomTableView.Source = new CustomTableViewSource(tableItems);
CustomTableView.ReloadData();

// グルグルを非表示、ボタンを利用可にします。
SVProgressHUD.Dismiss();
GetSpeakersButton.Enabled = true;
```

### `ViewController`完成形
```csharp
public partial class ViewController : UIViewController
{
    public ViewController(IntPtr handle) : base(handle)
    {
    }

    public override void ViewDidLoad()
    {
        base.ViewDidLoad();

        var vm = new UITableViewSample.Models.SpeakersModel();

        CustomTableView.RowHeight = 70;
        CustomTableView.RegisterNibForCellReuse(CustomTableViewCell.Nib, nameof(CustomTableViewCell));

        GetSpeakersButton.TouchUpInside += async (sender, e) =>
        {
            // ボタンを利用不可、グルグルを表示にします。
            GetSpeakersButton.Enabled = false;
            SVProgressHUD.Show();

            // vmのGetSpeakersメソッドを実行します。
            await vm.GetSpeakersAsync();

            // Name、Title、UIImageのプロパティを持つTableItemのListにデータを移し替えます。
            // 移し替える前にImageUrlをUIImageに変換して格納します。
            var tableItems = new List<TableItem>();
            foreach (var x in vm.Speakers)
            {
                var image = await this.LoadImage(x.Avatar);
                tableItems.Add(new TableItem(x.Name, x.Title, image));
            }

            // TableViewのSourceをCustomTableViewSourceでnewします。
            CustomTableView.Source = new CustomTableViewSource(tableItems);
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

    private async Task<UIImage> LoadImage(string imageUrl)
    {
        using (var client = new HttpClient())
        {
            // imageUrlからバイト配列を取得します。
            byte[] contents = await client.GetByteArrayAsync(imageUrl);
            // バイト配列のデータからUIImageを生成します。
            return UIImage.LoadFromData(NSData.FromArray(contents));
        }
    }
}
```