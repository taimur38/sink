using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google;
using Google.Apis.Calendar.v3.Data;
using MongoDB.Bson.Serialization.Attributes;

namespace sink.States
{
    public class CalendarState : CrawledState
    {
        public CalendarState(Event e)
        {
            this.Event = e;
            if (e.RecurringEventId != null)
                this.Date = e.OriginalStartTime.DateTime ?? DateTime.Now;       //TODO: something else when null
            else
                this.Date = e.Start.DateTime ?? DateTime.Now;

            if (e.End.DateTime != null && e.Start.DateTime != null)
                Duration = (DateTime)e.End.DateTime - (DateTime)e.Start.DateTime;
            else
                Duration = new TimeSpan(0, 30, 0); // default to 30 min i guess.
        }

        public Event Event { get; private set; }
        public TimeSpan Duration { get; private set; }

        public override void Save()
        {
            this.Collection<CalendarState>().Save(this);
        }

        public override bool Exists()
        {
            var res = this.Queryable<CalendarState>().FirstOrDefault(x => x.Event.Id == this.Event.Id);

            return res != null;
        }

    }
}
