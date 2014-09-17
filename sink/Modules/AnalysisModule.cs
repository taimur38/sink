using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy;
using sink;
using sink.States;
using MongoDB.Driver.Builders;
using Newtonsoft.Json;
using MongoDB.Driver;
using Newtonsoft.Json.Linq;
using MongoDB.Bson;

namespace sink.Modules
{
    public class AnalysisModule : NancyModule
    {
        public AnalysisModule() : base("/fountain")
        {
            Get["/query/{state}/{startDate}/{endDate}"] = parameters =>
                {
                    //from here, i want to serve a data model. parameter can hold beg/end date periods
                    DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                    DateTime beg = dt.AddSeconds(parameters.startDate);
                    Console.WriteLine(beg);
                    DateTime end = dt.AddSeconds(parameters.endDate);
                    Console.WriteLine(end);
                    string collection_name = parameters.state + "State";

                    Console.WriteLine(collection_name + " " + beg + " - " + end);

                    var type = collection_name.GetType("sink.States");

                    Console.WriteLine(type);

                    MongoCollection<BsonDocument> collection = sink.Context.Mongo.DB.GetCollection(collection_name);

                    var q = Query.And(Query.GTE("Date", beg), Query.LTE("Date", end));

                    var res = collection.FindAs(type, q);
                    
                    return res.ToJson();
                };
        }
    }
}
