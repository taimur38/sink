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
            Post["/faucet/app"] = parameters =>
            {
                try
                {
                    var d = parameters.Date;

                    var entry = new AppUsage(parameters.Name, parameters.Date, new TimeSpan(0, 0, parameters.Duration));

                    return "ok";
                }
                catch (Exception e)
                {
                    return e.Message;
                }
            };

            Get["/faucet/location"] = parameters =>
                {
                    return "yes";
                };
        }
    }
}
