using System;
using System.Linq;
using System.Threading.Tasks;
using Foundation;
using UIKit;
using UITableViewCoded.Services;

namespace UITableViewCoded.Views
{
    [Register(nameof(SpeakersViewController))]
    public partial class SpeakersViewController : UIViewController
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Title = "Speakers";
            InitializeUI();

            //var items = new string[]
            //{
            //    "item 1",
            //    "item 2",
            //    "item 3",
            //    "item 4",
            //    "item 5",
            //};

            //speakersTable.Source = new PlainTableSource(items);
            //speakersTable.ReloadData();

        }

        private async void getSpeakersAsync()
        {
            var speakerService = new SpeakerService();
            var speakers = await speakerService.GetSpeakersAsync();

            speakersTable.Source = new PlainTableSource(speakers.Select(x => x.Name).ToArray());
            speakersTable.ReloadData();
        }
    }
}
