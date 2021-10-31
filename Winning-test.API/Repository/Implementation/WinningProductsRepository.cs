using AutoMapper;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Winning_test.DAL.Databases.WinningDb;
using Winning_test.DAL.DomainModels.ProductsModels;
using Winning_test.Repository.Interface;

namespace Winning_test.Repository.Implementation
{
    public class WinningProductsRepository : IWinningProductsRepository
    {
        private readonly IWinningDbContext context;

        public WinningProductsRepository(IWinningDbContext wContext)
        {
            context = wContext;
        }

        public IList<Products> GetProductsByProductRating(decimal min, decimal max)
        {
            List<Winning_test.DAL.DomainModels.ProductsModels.Products> prodResult = new List<DAL.DomainModels.ProductsModels.Products>();

            var productContext = context.GetCollection<Winning_test.DAL.DomainModels.ProductsModels.Products>(typeof(Winning_test.DAL.DomainModels.ProductsModels.Products).Name);

            var queryFilter = $"{{'attribute.rating.value':{{$gte:{min},$lte:{max}}}}}";
            var query = new QueryDocument(BsonSerializer.Deserialize<BsonDocument>(queryFilter));
            return productContext.Find<Products>(query).ToList();
        }

        IList<Products> IWinningProductsRepository.GetProductsByFantasticAttribute(string fantasticFilter)
        {
            List<Winning_test.DAL.DomainModels.ProductsModels.Products> prodResult = new List<DAL.DomainModels.ProductsModels.Products>();

            var productContext = context.GetCollection<Winning_test.DAL.DomainModels.ProductsModels.Products>(typeof(Winning_test.DAL.DomainModels.ProductsModels.Products).Name);

            var queryFilter = $"{{'attribute.fantastic.value':{{$eq:{fantasticFilter}}}}}";
            var query = productContext.Find(queryFilter).ToListAsync();
            prodResult = query.Result;
            return prodResult;
        }

        IList<Products> IWinningProductsRepository.GetProductsByPrice(decimal priceMin, decimal pricemax)
        {
            List<Winning_test.DAL.DomainModels.ProductsModels.Products> prodResult = new List<DAL.DomainModels.ProductsModels.Products>();

            var productContext = context.GetCollection<Winning_test.DAL.DomainModels.ProductsModels.Products>(typeof(Winning_test.DAL.DomainModels.ProductsModels.Products).Name);

            var queryFilter = $"{{'price':{{$gte:{priceMin},$lte:{pricemax}}}}}";
            var query = productContext.Find(queryFilter).ToListAsync();
            prodResult = query.Result;

            return prodResult;
        }

        IList<Winning_test.DAL.DomainModels.ProductsModels.Products> IWinningProductsRepository.GetProductsCollection(string filter)
        {
            List<Winning_test.DAL.DomainModels.ProductsModels.Products> prodResult = new List<DAL.DomainModels.ProductsModels.Products>();

            var productContext = context.GetCollection<Winning_test.DAL.DomainModels.ProductsModels.Products>(typeof(Winning_test.DAL.DomainModels.ProductsModels.Products).Name);

            if (string.IsNullOrEmpty(filter))
            {
               var queryFilter = Builders<Winning_test.DAL.DomainModels.ProductsModels.Products>.Filter.Empty;
                var query = productContext.Find(queryFilter).ToListAsync();
                prodResult = query.Result;
            }
            else
            {
                var query = new QueryDocument(BsonSerializer.Deserialize<BsonDocument>(filter));
                prodResult =  productContext.Find<Winning_test.DAL.DomainModels.ProductsModels.Products>(query).ToList();
            }
            
            return prodResult;
        }
    }
}
