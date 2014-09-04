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
using MongoDB.Bson.Serialization.Attributes;

namespace sink.States
{
    
    public class MusicState : CrawledState
    {
        public MusicState()
        {
            DeviceType = Device.All;
            DeviceName = "";
        }

        public MusicState(JToken json) : this()
        {
            Artist = json["artist"]["#text"].ToString();
            Title = json["name"].ToString();
            Album = json["album"]["#text"].ToString();
            Url = json["url"].ToString();
            Image = json["image"].Last["#text"].ToString();

            try
            {
                var uts = long.Parse(json["date"]["uts"].ToString());
                Date = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                Date = Date.AddSeconds(uts).ToLocalTime(); //TODO: this needs to use time of location from phone. can be done at deserialization
            }
            catch()
            {
                Date = DateTime.Now;
            }
            
        }

        public override void Save()
        {
            this.Collection<MusicState>().Save(this);
        }

        public override bool Exists()
        {
            var res = this.Queryable<MusicState>().FirstOrDefault(x => x.Date == this.Date && x.Title == this.Title);

            return res != null;
        }

        public string Artist { get; private set; }
        public string Title { get; private set; }
        public string Album { get; private set; }
        public string Url { get; private set; }
        public string Image { get; private set; }

    }
}
