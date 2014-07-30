using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sink.States
{
    public class ConnectivityState : BaseState
    {
        public ConnectivityState()
        {
        }

        public string NetworkType { get; set; }
        public bool WiFiConn { get; set; }
        public bool WiFiAvailable { get; set; }

        public override void Save()
        {
            this.Collection<ConnectivityState>().Save(this);
        }
    }
}
