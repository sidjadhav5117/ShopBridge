using ShopBridgeApi.Context;
using ShopBridgeModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridgeApi.Service
{
    public class ProductService : IProductService
    {
        private readonly ShopBridgeContext shopBridgeContext;

        public ProductService(ShopBridgeContext shopBridgeContext)
        {
            this.shopBridgeContext = shopBridgeContext;
        }

        public async Task<Product> AddProduct(Product product)
        {
            product.CreatedDate = DateTime.Now;
            product.UpdatedDate = DateTime.Now;
            var addedProduct = shopBridgeContext.Products.Add(product);
            await shopBridgeContext.SaveChangesAsync();
            return addedProduct.Entity;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return shopBridgeContext.Products.ToList();
        }

        public async Task<Product> GetProduct(long id)
        {
            return shopBridgeContext.Products.FirstOrDefault(p => p.Id == id);
        }

        public async Task<bool> DeleteProduct(long id)
        {
            var foundProduct = await GetProduct(id);
            if (foundProduct == null)
                return false;

            shopBridgeContext.Products.Remove(foundProduct);
            return await shopBridgeContext.SaveChangesAsync() > 0;
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            if (product != null)
            {
                var foundProduct = await GetProduct(product.Id);
                if (foundProduct != null)
                {
                    foundProduct.ProductName = product.ProductName;
                    foundProduct.ProductCode = product.ProductCode;
                    foundProduct.Description = product.Description;
                    foundProduct.PurchaseCost = product.PurchaseCost;
                    foundProduct.SellingCost = product.SellingCost;
                    foundProduct.UpdatedDate = DateTime.Now;
                    await shopBridgeContext.SaveChangesAsync();
                    return foundProduct;
                }
                return null;
            }

            return null;
        }
    }
}
