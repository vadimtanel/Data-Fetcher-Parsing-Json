using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataFetcher.Model;
using DataFetcher.Provider;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DataFetcher.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductProvider _productProivder;

        public ProductsController(IProductProvider productProvider)
        {
            _productProivder = productProvider;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            List<Product> products = await _productProivder.GetProduct();
            return products;
        }
    }
}
