using ShopBridgeModels.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopBridgeApi.Service
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProducts();

        Task<Product> GetProduct(long id);

        Task<Product> AddProduct(Product product);

        Task<Product> UpdateProduct(Product product);

        Task<bool> DeleteProduct(long id);
    }
}
