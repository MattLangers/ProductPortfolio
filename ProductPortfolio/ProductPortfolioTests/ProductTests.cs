using NUnit.Framework;
using ProductPortfolio.Controllers;
using ProductPortfolio.Interfaces;
using System.Collections.Generic;
using ProductPortfolioTests.MockClasses;
using ProductPortfolio.Models;

namespace ProductPortfolio.Tests
{
    public class ProductTest
    {
        ProductsController _controller;
        IProducts _service;

        public ProductTest()
        {
            _service = new MockProductController();
            _controller = new ProductsController(_service);
        }

        [Test]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            var products = _controller.Get();
            Assert.AreEqual(4, products.Count);
        }

        [Test]
        public void Get_WhenCalled_ReturnsOneItem()
        {
            // Assert
            var product = _controller.Get("123");
            Assert.IsNotNull(product);
        }


    }
}