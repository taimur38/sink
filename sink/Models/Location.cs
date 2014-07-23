using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sink.Models
{
    public class Location : BaseActivity
    {
        public Location(double lat, double lon)
        {
            Latitude = lat;
            Longitude = lon;
            Name = "";
            Traveling = false;
        }

        public Location(double lat, double lon, string name)
            : this(lat, lon)
        {
            Name = name;
        }

        public Location(double lat, double lon, string name, bool travel)
            : this(lat, lon, name)
        {
            Traveling = travel;
        }

        public ModelUpdator<Location> Updator { get; private set; }

        public override void Save()
        {
            Updator.Save();
        }

        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Name { get; set; }
        public bool Traveling { get; set; }

    }
}
