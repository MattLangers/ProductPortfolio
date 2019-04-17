using ProductPortfolio.Interfaces;
using ProductPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductPortfolioTests.MockClasses
{
    public class MockProductController : IProducts
    {
        private readonly List<Product> _products;

        public MockProductController()
        {
            _products = new List<Product>
            {
                new Product() { Department = "1", Description = "Item 1", ProductCode = "123456" },
                new Product() { Department = "2", Description = "Item 2", ProductCode = "654321"  },
                new Product() { Department = "3", Description = "Item 3", ProductCode = "777777"  },
                new Product() { Department = "4", Description = "Item 4", ProductCode = "666666"  }
            };
        }

        IList<Product> IProducts.GetAllProducts()
        {
            return _products;
        }

        Product IProducts.GetById(string id)
        {
            // Rough implementation
            return _products[0];
        }

    }
}
