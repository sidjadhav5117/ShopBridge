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

        [Inject]
        public IProductService ProductService { get; set; }

        protected AddProduct AddProductDialog { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Products = (await ProductService.GetProducts()).ToList();
        }

        protected void AddProduct()
        {
            AddProductDialog.Show();
        }

        public async void AddProductDialog_OnDialogClose()
        {
            Products = (await ProductService.GetProducts()).ToList();
            StateHasChanged();
        }
    }
}
