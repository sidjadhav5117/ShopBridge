using Microsoft.EntityFrameworkCore;
using ShopBridgeModels.Models;

namespace ShopBridgeApi.Context
{
    public class ShopBridgeContext : DbContext
    {
        public ShopBridgeContext(DbContextOptions<ShopBridgeContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
    }
}
