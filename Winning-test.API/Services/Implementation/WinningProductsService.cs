using System.Collections.Generic;
using Winning_test.Repository.Interface;
using Winning_test.Services.Interface;

namespace Winning_test.Services.Implementation
{
    public class WinningProductsService : IWinningProductsService
    {

        public IWinningProductsRepository winningProductsRepository { get; }

        public WinningProductsService(IWinningProductsRepository repository)
        {
            winningProductsRepository = repository;

        }

        IList<Winning_test.DAL.DomainModels.ProductsModels.Products> IWinningProductsService.GetProductsByFantasticAttribute(string fantasticFilter)
        {

            var result = winningProductsRepository.GetProductsByFantasticAttribute(fantasticFilter);

            return result;

        }


        IList<Winning_test.DAL.DomainModels.ProductsModels.Products> IWinningProductsService.GetProductsByProductRating(decimal min, decimal max)
        {
            var result = winningProductsRepository.GetProductsByProductRating(min, max);

            return result;
        }

        IList<Winning_test.DAL.DomainModels.ProductsModels.Products> IWinningProductsService.GetProductsCollection(string filter)
        {
            var result = winningProductsRepository.GetProductsCollection(filter);

            return result;

        }

        IList<Winning_test.DAL.DomainModels.ProductsModels.Products> IWinningProductsService.GetProductsByPrice(decimal priceMin, decimal pricemax)
        {
            var result = winningProductsRepository.GetProductsByPrice(priceMin, pricemax);

            return result;
        }
    }
}
