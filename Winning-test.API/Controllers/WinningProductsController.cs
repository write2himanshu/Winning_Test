using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Winning_test.Common;
using Winning_test.DAL.DomainModels.ProductsModels;
using Winning_test.Services.Interface;

namespace Winning_test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WinningProductsController : BaseController
    {
        /// <summary>
        /// The configuration
        /// </summary>
        private IConfiguration configuration;
        /// <summary>
        /// Battleship Service
        /// </summary>
        private IWinningProductsService _winningProductsService;

        /// <summary>
        /// Constructor for the controller
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="winningProductsService"></param>
        public WinningProductsController(IConfiguration configuration, IWinningProductsService winningProductsService) : base(configuration)
        {
            this.configuration = configuration;
            _winningProductsService = winningProductsService;
        }

        /// <summary>
        /// Get All products with/without filter
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(Products), (int)HttpStatusCode.OK)]
        [Route("/GetProducts")]
        public IActionResult GetProducts(string filter = "")
        {
            try
            {
                InitializeCorelation();


                var result = _winningProductsService.GetProductsCollection(filter);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }

        }

        /// <summary>
        /// Get Products by price
        /// </summary>
        /// <param name="priceMin"></param>
        /// <param name="pricemax"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(Products), (int)HttpStatusCode.OK)]
        [Route("/GetProductsByPrice")]
        public IActionResult GetProductsByPrice(decimal priceMin = 0, decimal pricemax = 0)
        {
            try
            {
                InitializeCorelation();


                var result = _winningProductsService.GetProductsByPrice(priceMin, pricemax);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }

        }

        /// <summary>
        /// Get products by fantastic attribute
        /// </summary>
        /// <param name="fantasticValue"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(Products), (int)HttpStatusCode.OK)]
        [Route("/GetProductsByAttribute")]
        public IActionResult GetProductsByFantasticAttribute(string fantasticValue = "")
        {
            try
            {
                InitializeCorelation();


                var result = _winningProductsService.GetProductsByFantasticAttribute(fantasticValue);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(Products), (int)HttpStatusCode.OK)]
        [Route("/GetProductsByRating")]
        public IActionResult GetProductsByProductRating(decimal min = 0, decimal max = 0)
        {
            try
            {
                InitializeCorelation();


                var result = _winningProductsService.GetProductsByProductRating(min, max);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }

        }
    }
}
