using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sink.States
{
    public abstract class CrawledState : BaseState
    {
        public abstract bool Exists();
    }
}
