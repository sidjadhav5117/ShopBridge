using ShopBridgeModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ShopBridgeWeb.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient httpClient;

        public ProductService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<Product>>
                (await httpClient.GetStreamAsync($"api/product"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<Product> GetProduct(long id)
        {
            return await JsonSerializer.DeserializeAsync<Product>
                (await httpClient.GetStreamAsync($"api/product/{id}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<Product> AddProduct(Product product)
        {
            var productJson = new StringContent(JsonSerializer.Serialize(product), Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("api/Product", productJson);

            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<Product>(await response.Content.ReadAsStreamAsync());
            }

            return null;
        }

        public async Task<bool> DeleteProduct(long id)
        {
            var response = await httpClient.DeleteAsync("api/Product/" + id);
            return await JsonSerializer.DeserializeAsync<bool>(await response.Content.ReadAsStreamAsync());
        }

        public async Task<Product> UpdatePerson(Product product)
        {
            var productJson = new StringContent(JsonSerializer.Serialize(product), Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync("api/Product", productJson);
            return await JsonSerializer.DeserializeAsync<Product>(await response.Content.ReadAsStreamAsync());
        }
    }
}
