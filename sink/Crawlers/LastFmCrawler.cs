using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using sink;
using sink.States;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace sink.Crawlers
{
    class LastFmCrawler : Crawler
    {
        public LastFmCrawler()
            : base("LastFM")
        {
            Url = "http://ws.audioscrobbler.com/2.0/?method=user.getrecenttracks&user=taimur38&api_key={0}&format=json&limit=200&page={1}";
        }

        public override int Crawl()
        {
            var wc = new WebClient();
            var page = 1;

            var items_crawled = 0;
            var copies = 0;

            while (true)
            {
                var json_data = wc.DownloadString(Url.Template(Config.LastFmAPIKey, page++));
                var json = (JObject) JsonConvert.DeserializeObject(json_data);
                var tracks = json["recenttracks"]["track"];

                
                foreach (var track in tracks)
                {
                    try
                    {
                        var model = new MusicState(track);
                        if (model.Exists())
                        {
                            copies++;
                            if (copies > 100)
                                return items_crawled;
                            continue;
                        }

                        model.Save();
                        Console.WriteLine("Crawled " + model.Title + " by " + model.Artist + " on " + model.Date);
                        items_crawled++;
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine("Error " + e.InnerException);
                        Console.WriteLine(track.ToString());
                    }
                }

                copies = 0;
            }
        }
    }
}
