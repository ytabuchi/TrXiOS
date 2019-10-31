using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UITableViewCoded.Models;

namespace UITableViewCoded.Services
{
    public class SpeakerService : ISpeakerService
    {
        static HttpClient client = new HttpClient();

        public async Task<List<Speaker>> GetSpeakersAsync()
        {
            try
            {
                // サーバーから json を取得します
                var json = await client.GetStringAsync("https://demo8598876.mockable.io/speakers");
                var speakers = JsonConvert.DeserializeObject<List<Speaker>>(json);

                return speakers;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error: " + ex);
                return null;
            }
        }
    }
}
