using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;
using Newtonsoft.Json.Linq;

namespace sink.Models
{
    
    public class LastFm : Crawlable
    {

        public LastFm()
        {
            Updator = new ModelUpdator<LastFm>(this);
        }

        public LastFm(JToken json) : this()
        {
            Artist = json["artist"]["#text"].ToString();
            Title = json["name"].ToString();
            Album = json["album"]["#text"].ToString();
            Url = json["url"].ToString();
            Image = json["image"].Last["#text"].ToString();

            var uts = long.Parse(json["date"]["uts"].ToString());
            Date = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            Date = Date.AddSeconds(uts).ToLocalTime(); //TODO: this needs to use time of location from phone. can be done at deserialization
        }

        public ModelUpdator<LastFm> Updator { get; private set; }

        public void Save()
        {
            Updator.Save();
        }

        public override bool Exists()
        {
            var res = Updator.Queryable().FirstOrDefault(x => x.Date == this.Date && x.Title == this.Title);

            return res != null;
        }

        public string Artist { get; private set; }
        public string Title { get; private set; }
        public string Album { get; private set; }
        public string Url { get; private set; }
        public string Image { get; private set; }

    }
}
