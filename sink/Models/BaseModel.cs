﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

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

    }

    public class ModelUpdator<T> where T : BaseModel
    {
        protected readonly T Model;     // is this a reference to Model? 

        public ModelUpdator(T model)
        {
            Model = model;
        }

        public MongoCollection Collection()
        {
            return Context.Mongo.DB.GetCollection<T>(typeof(T).Name);
        }

        public IQueryable<T> Queryable()
        {
            return Collection().AsQueryable<T>();
        }

        public virtual WriteConcernResult Save()
        {
            return Collection().Save(Model);
        }
    }
}
