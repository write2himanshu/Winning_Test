using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Winning_test.DAL.DomainModels.ProductsModels
{
    public class Products
    {
        [BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
        public ObjectId _Id { get; set; }

        [BsonElement("id")]
        public int Id { get; set; }

        [BsonElement("sku")]
        public string SKU { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("price")]
        public double Price { get; set; }

        [BsonElement("attribute")]
        public Attribute Attribute { get; set; }
    }
}
