using Microsoft.AspNetCore.Components;
using ShopBridgeModels.Models;
using ShopBridgeWeb.Services;
using System.Threading.Tasks;

namespace ShopBridgeWeb.Pages
{
    public partial class ProductEdit
    {
        [Parameter]
        public string ProductId { get; set; }

        [Inject]
        public IProductService ProductService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public Product Product { get; set; } = new Product();

        //used to store the state of screen
        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;
        protected bool Saved;

        protected async override Task OnInitializedAsync()
        {
            Saved = true;

            if (string.IsNullOrEmpty(ProductId))
            {
                return;
            }
            else
            {
                Product = (await ProductService.GetProduct(int.Parse(ProductId)));
            }
        }

        protected async Task DeleteProduct()
        {
            var response = await ProductService.DeleteProduct(int.Parse(ProductId));

            if (response)
            {
                NavigationManager.NavigateTo("/");
            }
            else
            {
                StatusClass = "alert=danger";
                Message = "Something went wrong while deleting. Please try again.";
                Saved = false;
            }
        }

        protected async Task HandleValidSubmit()
        {
            var response = await ProductService.UpdatePerson(Product);
            if (response != null)
            {
                NavigationManager.NavigateTo("/");
            }
            else
            {
                StatusClass = "alert=danger";
                Message = "Something went wrong while updating. Please try again.";
                Saved = false;
            }
        }

        protected async Task HandleInvalidSubmit()
        {
            StatusClass = "alert-danger";
            Message = "There are some validation errors. Please try again.";
        }
    }
}
