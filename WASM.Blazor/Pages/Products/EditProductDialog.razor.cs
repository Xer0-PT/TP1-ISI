using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Threading.Tasks;
using TP1.Domain.Models.DTO;

namespace WASM.Blazor.Pages.Products
{
    public partial class EditProductDialog
    {
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        [Parameter] public ProductDTO SelectedProduct { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public bool IsActive { get; set; }

        protected override void OnInitialized()
        {
            Name = SelectedProduct.Name;
            Price = SelectedProduct.Price;
            Stock = SelectedProduct.Stock;            
            IsActive = SelectedProduct.Active;
        }

        void Cancel() => MudDialog.Cancel();

        public async void Submit()
        {
            if (string.IsNullOrWhiteSpace(Name) || Price <= 0 || Stock <= 0)
                Snackbar.Add("All fields are required!", Severity.Error);
            else
            {
                SelectedProduct.Name = Name;
                SelectedProduct.Price = Price;
                SelectedProduct.Stock = Stock;
                SelectedProduct.Active = IsActive;

                var result = await ProductService.UpdateProduct(SelectedProduct);

                if (result.IsSuccessStatusCode)
                    MudDialog.Close(DialogResult.Ok(true));
                else
                {
                    Snackbar.Add(result.ToString(), Severity.Error);
                    Console.WriteLine(result.ToString());

                    Cancel();
                }
            }
        }

        public async void Delete()
        {
            bool? result = await DialogService.ShowMessageBox("Delete", "Deleting can not be undone!", yesText: "Delete!", cancelText: "Cancel");
            StateHasChanged();

            if (result == true)
            {
                await ProductService.DeleteProduct(SelectedProduct.Id);
                MudDialog.Close(DialogResult.Ok(true));
            }
        }
    }
}
