using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy;
using sink.States;
using Nancy.ModelBinding;

namespace sink.Modules
{
    public class ReceiverModule : NancyModule
    {
        BindingConfig config = new BindingConfig() 
        {
            BodyOnly = true
        };
                    
        public ReceiverModule() : base("/faucet")
        {
            Post["/app"] = parameters =>
            {
                try
                {
                    var entry = this.Bind<AppState>(config, f => f.Id);

                    entry.Save();

                    return "ok";
                }
                catch (Exception e)
                {
                    return e.Message;
                }
            };

            Get["/location"] = parameters =>
                {
                    try
                    {
                        var location = this.Bind<LocationState>(config, f => f.Id);
                        location.Save();
                        return "ok";
                    }
                    catch (Exception e)
                    {
                        return e.Message;
                    }
                };
        }
    }
}
