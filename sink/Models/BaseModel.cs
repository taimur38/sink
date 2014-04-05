using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using MongoDB.Driver;

namespace sink.Models
{
    public abstract class BaseModel
    {
        public BaseModel()
        {
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime Date { get; set; }

        [BsonIgnore]
        public MongoCollection Collection { get; set; }

        public virtual void Save()
        {
            Collection.Save(this);
        }
    }
}
