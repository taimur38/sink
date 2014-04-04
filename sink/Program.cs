using Nancy.Hosting.Self;
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

            var uri = new Uri("http://localhost:80");

            var hc = new HostConfiguration();
            hc.UrlReservations.CreateAutomatically = true;

            using (var host = new NancyHost(hc, uri))
            {
                host.Start();
                Thread.Sleep(Timeout.Infinite);
            }
        }
    }
}
