using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy;
using Newtonsoft.Json;

namespace sink.Modules
{
    public class HelloModule : NancyModule
    {
        public HelloModule()
        {
            Get["/"] = parameters =>
            {
                Console.WriteLine("connection");
                return "hi";
            };
        }

    }
}
