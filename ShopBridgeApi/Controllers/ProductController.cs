using Microsoft.AspNetCore.Mvc;
using ShopBridgeApi.Service;
using ShopBridgeModels.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShopBridgeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            return await productService.GetProducts();
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<Product> Get(int id)
        {
            return await productService.GetProduct(id);
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<Product> Post(Product product)
        {
            return await productService.AddProduct(product);
        }

        // PUT api/<ProductController>/5
        [HttpPut]
        public async Task<Product> Put(Product product)
        {
            return await productService.UpdateProduct(product);
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await productService.DeleteProduct(id);
        }
    }
}
