using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sink.States
{
    public class AppState : BaseState
    {
        public AppState()
        {
        }

        public AppState(string name, DateTime date, long duration) : this()
        {
            Name = name;
            Date = date;
            Duration = duration;
        }

        public string Name { get; set; }
        public long Duration { get; set; }

        public override void Save()
        {
            this.Collection<AppState>().Save(this);
        }

    }
}
