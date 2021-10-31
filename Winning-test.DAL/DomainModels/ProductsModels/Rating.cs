using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Winning_test.DAL.DomainModels.ProductsModels
{
    public class Rating
    {
        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("type")]
        public string Type { get; set; }

        [BsonElement("value")]
        public double Value { get; set; }
    }
}
