using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Winning_test.DAL.DomainModels.ProductsModels
{
    public class Fantastic
    {
        [BsonElement("value")]
        public bool Value { get; set; }

        [BsonElement("type")]
        public int Type { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }
    }
}
