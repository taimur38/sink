﻿using System;
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
            //var post_string = "client_id={0}&scope=https://www.googleapis.com/auth/calendar".Template(Config.GoogleClientCredential.ClientId);

            //var wc = new WebClient();
            //wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";

            //var res = wc.UploadString("http://accounts.google.com/o/oauth2/device/code", post_string);

           // var cert = new X509Certificate2("path/to/file", "password", X509KeyStorageFlags.Exportable);
            //var provider = new AssertionFlow()


            var creds = GoogleWebAuthorizationBroker.AuthorizeAsync(
                Config.GoogleClientCredential, new[] { CalendarService.Scope.Calendar }, "taimur38", CancellationToken.None).Result;

            var service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = creds,
                ApplicationName = "Sink"
            });


            var request = service.Events.List("primary");
            request.MaxResults = 2500; //max
            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;
            request.TimeMin = DateTime.Now.AddYears(-1);

            var events = request.Execute();
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
