using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace UITableViewSample.Models
{
    public class SpeakersModel
    {
        public bool IsBusy { get; set; }
        public List<Speaker> Speakers { get; set; } = new List<Speaker>();

        public SpeakersModel()
        {
        }


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
    }
}
