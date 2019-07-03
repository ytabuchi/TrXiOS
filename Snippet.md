## コードスニペット

Webサイトまたはmarkdownプレビューとして表示している場合は、それぞれの枠内をコピー＆ペーストしてください。
メモ帳などのテキストエディタで開いている場合は、` ```csharp` と ` ``` ` の間の行をコピー＆ペーストしてください。

順次コードを張り付けていく部分もスニペットを用意していますが、その後の完成形も用意してありますので、適宜ご利用ください。

### `UITableViewSample/Models/Speaker.cs`

```csharp
public string Id { get; set; }
public string Name { get; set; }
public string Description { get; set; }
public string Website { get; set; }
public string Title { get; set; }
public string Avatar { get; set; }
```

### `UITableViewSample/Models/SpeakersModel.cs`

```csharp
public bool IsBusy { get; set; }
public List<Speaker> Speakers { get; set; } = new List<Speaker>();
```

```csharp
public async Task GetSpeakersAsync()
{
  if(IsBusy)
    return;
}
```

```csharp
try
{
  IsBusy = true;
}
catch (Exception ex)
{
  
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
  var json = await client.GetStringAsync("https://demo4404797.mockable.io/speakers");
}
```

```csharp
var items = JsonConvert.DeserializeObject<List<Speaker>>(json);
```

```csharp
Speakers.Clear();
foreach (var item in items)
  Speakers.Add(item);
```

```csharp
System.Diagnostics.Debug.WriteLine("Error: " + ex);
```


#### `GetSpeakersAsync` 完成形

```csharp
public async Task GetSpeakersAsync()
{
    if (IsBusy)
        return;

    try
    {
        IsBusy = true;

        using (var client = new HttpClient())
        {
            // サーバーから json を取得します
            var json = await client.GetStringAsync("https://demo4404797.mockable.io/speakers");
            var items = JsonConvert.DeserializeObject<List<Speaker>>(json);

            Speakers.Clear();
            foreach (var item in items)
                Speakers.Add(item);
        }
    }
    catch (Exception ex)
    {
        System.Diagnostics.Debug.WriteLine("Error: " + ex);
    }
    finally
    {
        IsBusy = false;
    }
}
```

### `UITableViewSample.iOS/TableSource.cs`

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
UITableViewCell cell = tableView.DequeueReusableCell(cellIdentifier);
string item = tableItems[indexPath.Row];

// 再利用できるセルがなければ新規作成する。
if (cell == null)
    cell = new UITableViewCell(UITableViewCellStyle.Default, cellIdentifier);

cell.TextLabel.Text = item;

return cell;
```

```csharp
return tableItems.Length;
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


### `UITableViewSample.iOS/ViewController.cs`

```csharp
var vm = new SpeakersModel();
```



```csharp
GetSpeakersButton.TouchUpInside += async (sender, e) =>
{
    await vm.GetSpeakersAsync();
};
```

```csharp
var items = vm.Speakers.Select(x => x.Name).ToArray();
CustomTableView.Source = new TableSource(items);
CustomTableView.ReloadData();
```

### `TouchUpInside` メソッド完成形

```csharp
GetSpeakersButton.TouchUpInside += async (sender, e) =>
{
    await vm.GetSpeakersAsync();

    var items = vm.Speakers.Select(x => x.Name).ToArray();
    CustomTableView.Source = new TableSource(items);
    CustomTableView.ReloadData();
};
```

### `UITableViewSample.iOS/CustomTableViewCell.cs`

```csharp
/// <summary>
/// データを流し込むためのUpdateメソッド
/// </summary>
/// <param name="speaker"></param>
public async void Update(Speaker speaker)
{
    NameLabel.Text = speaker.Name;
    TitleLabel.Text = speaker.Title;
    AvatorImage.Image = await LoadImage(speaker.Avatar);

    AvatorImage.Layer.CornerRadius = AvatorImage.Bounds.Height / 2;
    AvatorImage.Layer.BorderWidth = 2;
    AvatorImage.Layer.BorderColor = UIColor.FromRGB(0x34, 0x98, 0xdb).CGColor;
    AvatorImage.ClipsToBounds = true;
}

private async Task<UIImage> LoadImage(string imageUrl)
{
    if (string.IsNullOrEmpty(imageUrl))
        return UIImage.FromBundle("DefaultAvator");

    var httpClient = new HttpClient();
    byte[] contents = await httpClient.GetByteArrayAsync(imageUrl);

    // load from bytes
    return UIImage.LoadFromData(NSData.FromArray(contents));
}
```


#### `CustomTableViewCell` 完成形

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
    /// <param name="speaker"></param>
    public async void Update(Speaker speaker)
    {
        NameLabel.Text = speaker.Name;
        TitleLabel.Text = speaker.Title;
        AvatorImage.Image = await LoadImage(speaker.Avatar);

        AvatorImage.Layer.CornerRadius = AvatorImage.Bounds.Height / 2;
        AvatorImage.Layer.BorderWidth = 2;
        AvatorImage.Layer.BorderColor = UIColor.FromRGB(0x34, 0x98, 0xdb).CGColor;
        AvatorImage.ClipsToBounds = true;
    }

    private async Task<UIImage> LoadImage(string imageUrl)
    {
        if (string.IsNullOrEmpty(imageUrl))
            return UIImage.FromBundle("DefaultAvator");

        var httpClient = new HttpClient();
        byte[] contents = await httpClient.GetByteArrayAsync(imageUrl);

        // load from bytes
        return UIImage.LoadFromData(NSData.FromArray(contents));
    }
 }
}
```

### `UITableViewSample.iOS/CustomTableViewSource.cs`



```csharp
public class CustomTableViewSource : UITableViewSource
```

```csharp
private List<Speaker> Items { get; set; } = new List<Speaker> ();

public CustomTableViewSource (List<Speaker> items)
{
    this.Items = items;
}
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
    private List<Speaker> Items { get; set; } = new List<Speaker>();

    public CustomTableViewSource(List<Speaker> items)
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


### `UITableViewSample.iOS/ViewController.cs`


```csharp
CustomTableView.RowHeight = 70;
CustomTableView.RegisterNibForCellReuse(CustomTableViewCell.Nib, nameof(CustomTableViewCell));
```

```csharp
// ボタンを利用不可、グルグルを表示にします。
GetSpeakersButton.Enabled = false;
SVProgressHUD.Show();

await vm.GetSpeakersAsync();

// TableViewのSourceをCustomTableViewSourceでnewします。
CustomTableView.Source = new CustomTableViewSource(vm.Speakers);
CustomTableView.ReloadData();

// グルグルを非表示、ボタンを利用可にします。
SVProgressHUD.Dismiss();
GetSpeakersButton.Enabled = true;
```


### `ViewController` 完成形

```csharp
public partial class ViewController : UIViewController
{
    public ViewController(IntPtr handle) : base(handle)
    {
    }

    public override void ViewDidLoad()
    {
        base.ViewDidLoad();

        var vm = new SpeakersModel();

        CustomTableView.RowHeight = 70;
        CustomTableView.RegisterNibForCellReuse(CustomTableViewCell.Nib, nameof(CustomTableViewCell));

        GetSpeakersButton.TouchUpInside += async (sender, e) =>
        {
            // ボタンを利用不可、グルグルを表示にします。
            GetSpeakersButton.Enabled = false;
            SVProgressHUD.Show();

            await vm.GetSpeakersAsync();

            // TableViewのSourceをCustomTableViewSourceでnewします。
            CustomTableView.Source = new CustomTableViewSource(vm.Speakers);
            CustomTableView.ReloadData();

            // グルグルを非表示、ボタンを利用可にします。
            SVProgressHUD.Dismiss();
            GetSpeakersButton.Enabled = true;
        };

        #region PropertyChangedを使用する場合
        //vm.PropertyChanged += Vm_PropertyChanged;
        #endregion
    }

    public override void DidReceiveMemoryWarning()
    {
        base.DidReceiveMemoryWarning();
        // Release any cached data, images, etc that aren't in use.
    }
}
```


