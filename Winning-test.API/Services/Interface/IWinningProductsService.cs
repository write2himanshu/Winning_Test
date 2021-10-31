using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Winning_test.DAL.DomainModels.ProductsModels;

namespace Winning_test.Services.Interface
{
    public interface IWinningProductsService
    {
        IList<Products> GetProductsCollection(string filter);
        IList<Products> GetProductsByPrice(decimal priceMin, decimal pricemax);
        IList<Products> GetProductsByFantasticAttribute(string filter);
        IList<Products> GetProductsByProductRating(decimal min, decimal max);
    }

    
}
