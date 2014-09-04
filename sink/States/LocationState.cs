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

        public LocationState()
        {
        }

        public LocationState(double lat, double lon, double alt, double acc, double speed, string name = "")
        {
            Latitude = lat;
            Longitude = lon;
            Altitude = alt;
            Accuracy = acc;
            Speed = speed;
            Name = name;
        }

        public override void Save()
        {
            this.Collection<LocationState>().Save(this);
        }

        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Altitude { get; set; }
        public double Accuracy { get; set; }
        public double Speed { get; set; }   // m/s

        public string Name { get; set; }

    }
}
