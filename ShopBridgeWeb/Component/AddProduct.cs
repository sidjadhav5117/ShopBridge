using Microsoft.AspNetCore.Components;
using ShopBridgeModels.Models;
using ShopBridgeWeb.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridgeWeb.Component
{
    public partial class AddProduct
    {
        [Inject]
        public IProductService ProductService { get; set; }

        [Parameter]
        public EventCallback<bool> CloserEventCallback { get; set; }

        public Product Product { get; set; } = new Product();

        public bool ShowDialog { get; set; }

        public void Show()
        {
            ResetDialog();
            ShowDialog = true;
            StateHasChanged();
        }

        public void Close()
        {
            ShowDialog = false;
            StateHasChanged();
        }

        public void ResetDialog()
        {
            Product = new Product();
        }

        protected async Task HandleValidSubmit()
        {
            await ProductService.AddProduct(Product);
            ShowDialog = false;

            await CloserEventCallback.InvokeAsync(true);
            StateHasChanged();
        }
    }
}
