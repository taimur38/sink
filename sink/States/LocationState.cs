using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sink.States
{
    public class LocationState : BaseState
    {
        public LocationState(double lat, double lon, string name = "", bool travel = false)
        {
            Latitude = lat;
            Longitude = lon;
            Name = name;
            Traveling = travel;
        }

        public override void Save()
        {
            this.Collection<LocationState>().Save(this);
        }

        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public string Name { get; set; }
        public bool Traveling { get; set; }

    }
}
