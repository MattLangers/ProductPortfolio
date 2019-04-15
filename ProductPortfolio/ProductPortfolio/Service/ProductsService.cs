using ProductPortfolio.Interfaces;
using ProductPortfolio.Models;
using System.Collections.Generic;

namespace ProductPortfolio.Service
{
    public class ProductsService : IProducts
    {
        List<Product> IProducts.GetAllProducts()
        {
            // Define call into Data Access Layer to retrieve all products.
            // Dummy implementation
            return new List<Product>
            {
                new Product() { Department = "1", Description = "Item 1", ProductCode = "123456" },
                new Product() { Department = "2", Description = "Item 2", ProductCode = "654321"  },
                new Product() { Department = "3", Description = "Item 3", ProductCode = "777777"  },
                new Product() { Department = "4", Description = "Item 4", ProductCode = "666666"  }
            };
        }

        Product IProducts.GetById(string id)
        {
            // Define call into Data Access Layer to retrieve specific product.
            // Dummy implementation
            return new Product() { Department = "1", Description = "Item 1", ProductCode = "123456" };
        }
    }
}
