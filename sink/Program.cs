﻿using Nancy.Hosting.Self;
using sink.Crawlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace sink
{
    class Program
    {
        static void Main(string[] args)
        {

            var uri = new Uri("http://localhost:6969");

            //var hc = new HostConfiguration();
            //hc.UrlReservations.CreateAutomatically = true;

            var t = new Thread(new ThreadStart(extra_shit));
            t.Start();

            using (var host = new NancyHost(uri))
            {
                host.Start();
                Thread.Sleep(Timeout.Infinite);
            }
        }

        static void extra_shit()
        {
            Console.WriteLine("starting crawl");
            var c = new LastFmCrawler();

            var items = c.Crawl();

            Console.WriteLine("{0} items crawled.".Template(items));

            
        }
    }
}
