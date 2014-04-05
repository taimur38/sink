using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using sink;
using sink.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace sink.Crawlers
{
    class LastFmCrawler : Crawler
    {
        public LastFmCrawler()
            : base("LastFM")
        {
            Url = "http://ws.audioscrobbler.com/2.0/?method=user.getrecenttracks&user=taimur38&api_key=4fb61b9f3aa975c486531f4e5223d353&format=json&limit=200&page={0}";
        }

        public override int Crawl()
        {
            var wc = new WebClient();
            var page = 2;

            var items_crawled = 0;

            while (true)
            {
                var json_data = wc.DownloadString(Url.Template(page++));
                var json = (JObject) JsonConvert.DeserializeObject(json_data);
                var tracks = json["recenttracks"]["track"];

                
                foreach (var track in tracks)
                {
                    var model = new LastFm(track);
                    if (model.Exists())
                        return items_crawled;
                    
                    model.Save();
                    Console.WriteLine("Crawled " + model.Title + " by " + model.Artist + " on " + model.Date);
                    items_crawled++;
                }
            }
        }
    }
}
