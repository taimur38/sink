using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace sink.Services
{
    public class MongoService
    {
        public MongoService()
        {
            var client = new MongoClient("mongodb://localhost");
            var server = client.GetServer();
            DB = server.GetDatabase("sink-db");
        }

        public MongoDatabase DB { get; private set; }


    }
}
