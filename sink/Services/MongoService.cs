using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace sink.Services
{
    public class MongoService
    {
        public MongoService()
        {
            var client = new MongoClient(Config.MongoIP);
            var server = client.GetServer();
            DB = server.GetDatabase("sink-db");
        }

        public MongoCollection<T> Collection<T>()
        {
            return DB.GetCollection<T>(typeof(T).Name);
        }

        public IQueryable<T> Queryable<T>()
        {
            return Collection<T>().AsQueryable<T>();
        }

        public virtual WriteConcernResult Save<T>()
        {
            return Collection<T>().Save(this);
        }
        
        public MongoDatabase DB { get; private set; }
    }
}
