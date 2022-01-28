using MudBlazor;
using System.Collections.Generic;
using System.Threading.Tasks;
using TP1.Domain.Models.DTO;

namespace WASM.Blazor.Pages.Products
{
    public partial class ProductsManagement
    {
        public List<ProductDTO> ProductsList { get; set; } = new();
        public ProductDTO SelectedProduct { get; set; }
        public bool IsLoading { get; set; } = true;

        protected async override Task OnInitializedAsync()
        {
            await UpdateList();
            IsLoading = false;
        }

        public async Task UpdateList()
        {
            await Task.Delay(1);
            ProductsList = await ProductService.GetAllProducts();
            StateHasChanged();
        }

        public async void CreateDialog()
        {
            var dialog = DialogService.Show<CreateProductDialog>("");
            var result = await dialog.Result;

            if (!result.Cancelled)
            {
                await UpdateList();
            }
        }

        public async void EditDialog()
        {
            var parameters = new DialogParameters();
            parameters.Add("SelectedProduct", SelectedProduct);

            var dialog = DialogService.Show<EditProductDialog>("", parameters);
            var result = await dialog.Result;

            if (!result.Cancelled)
            {
                await UpdateList();
            }
        }
    }
}
