using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google;
using Google.Apis.Calendar.v3.Data;

namespace sink.Models
{
    public class GoogleCalendarEvent : Crawlable
    {
        public GoogleCalendarEvent(Event e)
        {
            this.Event = e;
            this.Updator = new ModelUpdator<GoogleCalendarEvent>(this);
            if (e.RecurringEventId != null)
                this.Date = e.OriginalStartTime.DateTime ?? DateTime.Now;       //TODO: something else when null
            else
                this.Date = e.Start.DateTime ?? DateTime.Now;
        }

        public Event Event { get; private set; }
        public ModelUpdator<GoogleCalendarEvent> Updator { get; private set; }

        public void Save()
        {
            Updator.Save();
        }

        public override bool Exists()
        {
            var res = Updator.Queryable().FirstOrDefault(x => x.Event.Id == this.Event.Id);

            return res != null;
        }

    }
}
