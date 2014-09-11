using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy;
using sink.States;
using Nancy.ModelBinding;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

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

            Post["/state"] = parameters =>
                {
                    using(var reader = new StreamReader(this.Request.Body))
                    {
                        var json = reader.ReadToEnd();

                        var obj = JObject.Parse(json);
                        var t = Type.GetType("sink.States." + obj["Type"]);

                        var typed = (BaseState)obj.ToObject(t);
                        Console.WriteLine(typed.GetType());
                        //typed.Save();
                        
                        
                        Console.WriteLine(json);
                        return json;
                    }
                    
                };

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
                    Console.WriteLine(e.Message);
                    return e.Message;
                }
            };

            Post["/location"] = parameters =>
                {
                    try
                    {
                        var location = this.Bind<LocationState>(config, f => f.Id);
                        location.Save();
                        return "ok";
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        return e.Message;
                    }
                };

            Post["/battery"] = parameters =>
                {
                    try
                    {
                        var battery = this.Bind<BatteryState>(config, f => f.Id);
                        battery.Save();

                        return "ok";
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        return e.Message;
                    }
                };

            Post["/conn"] = parameters =>
                {
                    try
                    {
                        var conn = this.Bind<ConnectivityState>(config, f => f.Id);
                        conn.Save();

                        return "ok";
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        return e.Message;
                    }
                };
        }
    }
}
