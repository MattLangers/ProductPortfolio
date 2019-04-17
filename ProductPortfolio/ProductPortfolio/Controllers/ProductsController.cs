using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ProductPortfolio.Interfaces;
using ProductPortfolio.Models;

namespace ProductPortfolio.Controllers
{
    [Route("api/[controller]")]

    public class ProductsController : Controller
    {

        private readonly IProducts _service;

        public ProductsController(IProducts service)
        {
            _service = service;
        }

        // GET api/products
        [HttpGet]        
        public IList<Product> Get()
        {
            return _service.GetAllProducts();
        }

        // GET api/products/5
        [HttpGet("{id}")]
        public Product Get(string id)
        {
            return _service.GetById(id);
        }
    }
}

