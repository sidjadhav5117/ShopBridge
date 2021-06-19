using Microsoft.AspNetCore.Components;
using ShopBridgeModels.Models;
using ShopBridgeWeb.Component;
using ShopBridgeWeb.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridgeWeb.Pages
{
    public partial class Index
    {
        public IEnumerable<Product> Products { get; set; }

        [CascadingParameter]
        public Error Error { get; set; }

        [Inject]
        public IProductService ProductService { get; set; }

        protected AddProduct AddProductDialog { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Products = (await ProductService.GetProducts()).ToList();
        }

        protected void AddProduct()
        {
            try
            {
                AddProductDialog.Show();
            }
            catch(Exception ex)
            {
                Error.ProcessError(ex);
            }
        }

        public async void AddProductDialog_OnDialogClose()
        {
            Products = (await ProductService.GetProducts()).ToList();
            StateHasChanged();
        }

        protected async Task DeleteProduct(long id)
        {
            try
            {
                var response = await ProductService.DeleteProduct(id);
            }
            catch(Exception ex)
            {
                Error.ProcessError(ex);
            }
        }
    }
}
