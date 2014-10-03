using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sink.States
{
    public class HeartState : BaseState
    {
        public HeartState()
        {

        }

        public double BPM { get; set; }

        public override void Save()
        {
            this.Collection<HeartState>().Save(this);
        }
    }
}
