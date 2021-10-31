using Microsoft.Extensions.Configuration;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Winning_test.Controllers;
using Winning_test.DAL.DomainModels.ProductsModels;
using Winning_test.Services.Interface;
using Xunit;

namespace Winning_test.Tests
{
    public class WinningProductsControllerTests
    {
        private readonly Mock<IWinningProductsService> service;
        private readonly Mock<IConfiguration> _configuration = new Mock<IConfiguration>();

        private readonly WinningProductsController sut;

        private List<Products> products;

        public WinningProductsControllerTests()
        {
            const string testData = @"[
                {'id':998,'sku':'421 - 03 - 8525','name':'SODIUM CHLORIDE, POTASSIUM CHLORIDE, AND CALCIUM CHLORIDE','price':996.35,'attribute':{'fantastic':{'value':false,'type':1,'name':'fantastic'},'rating':{'name':'rating','type':'2','value':2.6}}},
                { 'id':999,'sku':'872-84-3201','name':'Acetaminophen, guaifenesin, phenylephrine HCl','price':623.12,'attribute':{ 'fantastic':{ 'value':true,'type':1,'name':'fantastic'},'rating':{ 'name':'rating','type':'2','value':2.1} } },
                { 'id':1000,'sku':'199-75-7755','name':'Diltiazem Hydrochloride','price':791.82,'attribute':{ 'fantastic':{ 'value':true,'type':1,'name':'fantastic'},'rating':{ 'name':'rating','type':'2','value':1.3} } }
            ]";

            products = JsonConvert.DeserializeObject<List<Products>>(testData);

            // Prepare Mock
            service = new Mock<IWinningProductsService>();
            sut = new WinningProductsController(_configuration.Object, service.Object);
        }

        [Fact]
        public void Get_All_Products()
        {
            // Arrange
            service.Setup(x => x.GetProductsCollection("")).Returns(products);

            // Act
            var result = sut.GetProducts();

            // Assert
            result.Equals(products);
        }


    }
}
