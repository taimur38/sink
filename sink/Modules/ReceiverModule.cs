using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy;
using sink.Models;

namespace sink.Modules
{
    public class ReceiverModule : NancyModule
    {
        public ReceiverModule()
        {
            Get["/receive/app"] = parameters =>
            {
                var entry = new AppUsage(parameters.Name, parameters.Date, new TimeSpan(0, 0, parameters.Duration));
                
                return "ok";
            };

            Get["/receive/location"] = parameters =>
                {
                    return "yes";
                };
        }
    }
}
