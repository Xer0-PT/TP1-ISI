using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using TP1.Domain.Models.DTO;

namespace WASM.Blazor.Pages.Products
{
    public partial class CreateProductDialog
    {
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        void Cancel() => MudDialog.Cancel();

        public async void Submit()
        {
            if (string.IsNullOrWhiteSpace(Name) || Price <= 0 || Stock <= 0)
                Snackbar.Add("All fields are required!", Severity.Error);
            else
            {
                var newProduct = new ProductDTO(Name, Price, Stock, true);

                var result = await ProductService.AddProduct(newProduct);

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
    }
}
