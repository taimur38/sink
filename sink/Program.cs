using Nancy.Hosting.Self;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sink
{
    class Program
    {
        static void Main(string[] args)
        {

            var uri = new Uri("http://localhost:8080");
            using (var host = new NancyHost(uri))
            {
                host.Start();
            }
        }
    }
}
