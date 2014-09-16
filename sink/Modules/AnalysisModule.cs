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
            Get["/query"] = parameters =>
                {
                    //from here, i want to serve a data model. parameter can hold beg/end date periods

                    DateTime beg = parameters.startDate;
                    DateTime end = parameters.endDate;
                    string collection_name = parameters.state + "State";
                    var type = collection_name.GetType("sink.States");

                    MongoCollection<BsonDocument> collection = sink.Context.Mongo.DB.GetCollection(collection_name);

                    var q = Query.And(Query.GTE("Date", beg), Query.LTE("Date", end));

                    var res = collection.FindAs(type, q);
                    
                    return res.ToJson();
                };
        }
    }
}
