using Microsoft.AspNetCore.Components;
using ShopBridgeModels.Models;
using ShopBridgeWeb.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridgeWeb.Pages
{
    public partial class ProductDetails
    {
        [Parameter]
        public string ProductId { get; set; }

        [CascadingParameter]
        public Error Error { get; set; } 

        [Inject]
        public IProductService ProductService { get; set; }

        public Product Product { get; set; } = new Product();

        protected async override Task OnInitializedAsync()
        {
            try
            {
                Product = (await ProductService.GetProduct(int.Parse(ProductId)));
            }
            catch(Exception ex)
            {
                Error.ProcessError(ex);
            }
        }
    }
}
