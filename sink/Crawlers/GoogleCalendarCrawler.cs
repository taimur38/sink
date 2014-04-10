using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google;
using Google.GData.Client;
using Google.Apis.Calendar.v3;
using Google.Apis.Auth.OAuth2;
using System.Threading;
using Google.Apis.Services;
using sink.Models;


namespace sink.Crawlers
{
    public class GoogleCalendarCrawler : Crawler
    {
        public GoogleCalendarCrawler()
            : base("Google Calendar")
        {
            Url = "https://www.googleapis.com/calendar/v3/users/me/calendarList";
        }

        public override int Crawl()
        {
            var creds = GoogleWebAuthorizationBroker.AuthorizeAsync(
                Config.GoogleClientCredential, new[] { CalendarService.Scope.Calendar }, "user", CancellationToken.None).Result;

            var service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = creds,
                ApplicationName = "Sink"
            });


            var events = service.Events.List("primary").Execute();
            var count = 0;

            foreach (var e in events.Items)
            {
                var model = new GoogleCalendarEvent(e);

                if (!model.Exists())
                {
                    model.Save();
                    count++;
                }                
            }
            
            return count;
        }

    }
}
