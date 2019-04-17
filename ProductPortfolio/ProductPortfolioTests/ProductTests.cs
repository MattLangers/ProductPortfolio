using NUnit.Framework;
using ProductPortfolio.Controllers;
using ProductPortfolio.Interfaces;
using System.Collections.Generic;
using ProductPortfolioTests.MockClasses;
using ProductPortfolio.Models;

namespace ProductPortfolio.Tests
{
    using Moq;

    public class ProductControllerTest
    {
        private readonly IList<Product> expectedProducts = new List<Product>();
        private string productId = "ABC";
        private readonly Mock<IProducts> mockedIProducts = new Mock<IProducts>();
        private readonly Product expectedProduct = new Product();
        ProductsController _controller;
        IProducts _service;

        public ProductControllerTest()
        {
            this.mockedIProducts.Setup(m => m.GetAllProducts()).Returns(this.expectedProducts);
            this.mockedIProducts.Setup(m => m.GetById(this.productId)).Returns(this.expectedProduct);
            _service = this.mockedIProducts.Object;
            _controller = new ProductsController(_service);
        }

        [Test]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            var products = _controller.Get();
            this.mockedIProducts.Verify(m => m.GetAllProducts(), Times.Once);
            Assert.AreSame(this.expectedProducts, products);
        }

        [Test]
        public void Get_WhenCalled_ReturnsOneItem()
        {
            // Assert
            var product = _controller.Get(this.productId);
            this.mockedIProducts.Verify(m => m.GetById(It.IsAny<string>()), Times.Once);
            Assert.AreSame(this.expectedProduct, product);
        }
    }
}