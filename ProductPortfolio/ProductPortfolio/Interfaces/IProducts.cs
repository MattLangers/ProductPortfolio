using ProductPortfolio.Models;
using System.Collections.Generic;

namespace ProductPortfolio.Interfaces
{
    public interface IProducts
    {
        List<Product> GetAllProducts();
        Product GetById(string id);
    }
}
