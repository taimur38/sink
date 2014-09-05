using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace sink.States
{
    public abstract class BaseState
    {

        public BaseState()
        {
        }

        public BaseState(string deviceName, Device deviceType)
        {
            DeviceName = deviceName;
            DeviceType = deviceType;
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime Date { get; set; }

        [BsonRequired]
        public string DeviceName { get; set; }
        [BsonRequired]
        public Device DeviceType { get; set; }

        public abstract void Save();

        public MongoCollection<T> Collection<T>()
        {
            return Context.Mongo.DB.GetCollection<T>(typeof(T).Name);
        }

        public IQueryable<T> Queryable<T>()
        {
            return Collection<T>().AsQueryable<T>();
        }
    }

    public enum Device
    {
        Desktop,
        Laptop,
        Phone,
        Watch,
        All
    }
}
