using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sink.Models
{
    public class AppUsage : BaseActivity
    {
        public AppUsage()
        {
            Updator = new ModelUpdator<AppUsage>(this);
        }

        public AppUsage(string name, DateTime date, TimeSpan duration)
        {
            Name = name;
            Date = date;
            Duration = duration;
        }

        public string Name { get; set; }

        public ModelUpdator<AppUsage> Updator { get; private set; }

        public override void Save()
        {
            Updator.Save();
        }
        

    }
}
