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
                    try
                    {
                        using (var reader = new StreamReader(this.Request.Body))
                        {
                            var json = reader.ReadToEnd();

                            var obj = JObject.Parse(json);

                            var t = Type.GetType("sink.States." + obj["Type"]);
                            var typed = (BaseState)obj.ToObject(t);             //catch errors on input

                            typed.Save();

                            Console.WriteLine(json);
                            return json;
                        }

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        return e.Message;
                    }
                    
                };

            Post["/states"] = parameters =>
                {
                    try
                    {
                        using (var reader = new StreamReader(this.Request.Body))
                        {
                            var json = reader.ReadToEnd();
                            var obj = JObject.Parse(json);

                            var count = 0;
                            foreach(JObject o in obj["states"]) {

                                var t = Type.GetType("sink.States." + o["Type"]);
                                var typed = (BaseState)o.ToObject(t);
                                count++;
                                typed.Save();
                            }

                            Console.WriteLine(string.Format("{0} states logged at {1}", count, DateTime.Now));
                            return json;
                        }
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
