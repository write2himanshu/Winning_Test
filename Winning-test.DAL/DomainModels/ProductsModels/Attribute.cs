using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Winning_test.DAL.DomainModels.ProductsModels
{
    public class Attribute
    {
        [BsonElement("fantastic")]
        public Fantastic Fantastic { get; set; }

        [BsonElement("rating")]
        public Rating Rating { get; set; }
    }
}
