using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sink.States
{
    public class BatteryState : BaseState
    {
        public BatteryState()
        {
            
        }

        public override void Save()
        {
            this.Collection<BatteryState>().Save(this);
        }

        public double Level { get; set; }
        public bool Charging { get; set; }
    }
}
