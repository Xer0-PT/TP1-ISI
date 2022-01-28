using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TP1.Domain.Models.DTO;

namespace WASM.Blazor.Pages.Requisitions
{
    public partial class CreateRequisitionDialog
    {
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }

        public List<TeamDTO> TeamsList { get; set; } = new();
        public List<ProductDTO> ProductsList { get; set; } = new();
        public List<ProductQuantityDTO> ProductsToAdd { get; set; } = new();
        public string selectedTeam = "";
        public bool confirmingRequisition = false;
        public int counter = 0;
        void Cancel() => MudDialog.Cancel();

        protected override async Task OnInitializedAsync()
        {
            TeamsList = await TeamService.GetAllActiveTeams();
            ProductsList = await ProductService.GetAllActiveProducts();

            var product = new ProductQuantityDTO();
            ProductsToAdd.Add(product);
        }

        public void AddProduct()
        {
            var product = new ProductQuantityDTO();
            ProductsToAdd.Add(product);
        }

        public async void Submit()
        {
            if (ProductsToAdd.Count == 0 || ProductsToAdd.Find(x => x.ProductName == "" || x.Quantity == 0) != null || selectedTeam == "")
            {
                Snackbar.Add("All fields are required!", Severity.Error);
            }
            else
            {
                confirmingRequisition = true;
                counter++;
                StateHasChanged();

                if (counter == 2)
                {
                    var newRequisition = new CreateRequisitionDTO(selectedTeam, ProductsToAdd);
                    var result = await RequisitionService.AddRequisition(newRequisition);

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
}
