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
using sink.States;
using System.Net;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;


namespace sink.Crawlers
{
    public class GoogleCalendarCrawler : Crawler
    {
        public GoogleCalendarCrawler()
            : base("Google Calendar")
        {
            Url = "";
        }

        public override int Crawl()
        {
            //TODO: redo all this shit
            return 0;
        }

    }
}
