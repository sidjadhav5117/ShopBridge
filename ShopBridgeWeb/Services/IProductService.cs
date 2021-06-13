using ShopBridgeModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridgeWeb.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProducts();

        Task<Product> GetProduct(long id);

        Task<Product> AddProduct(Product product);

        Task<bool> DeleteProduct(long id);

        Task<Product> UpdatePerson(Product product);
    }
}
