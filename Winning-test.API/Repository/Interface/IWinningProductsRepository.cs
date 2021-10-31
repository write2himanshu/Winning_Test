using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Winning_test.Repository.Interface
{
    public interface IWinningProductsRepository
    {
        IList<Winning_test.DAL.DomainModels.ProductsModels.Products> GetProductsCollection(string filter);
        IList<Winning_test.DAL.DomainModels.ProductsModels.Products> GetProductsByPrice(decimal priceMin, decimal pricemax);
        IList<Winning_test.DAL.DomainModels.ProductsModels.Products> GetProductsByFantasticAttribute(string fantasticFilter);
        IList<Winning_test.DAL.DomainModels.ProductsModels.Products> GetProductsByProductRating(decimal min, decimal max);
    }
}
