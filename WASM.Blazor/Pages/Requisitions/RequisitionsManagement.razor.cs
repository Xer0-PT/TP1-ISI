using MudBlazor;
using System.Collections.Generic;
using System.Threading.Tasks;
using TP1.Domain.Models.DTO;

namespace WASM.Blazor.Pages.Requisitions
{
    public partial class RequisitionsManagement
    {
        public List<RequisitionDTO> RequisitionsList { get; set; } = new();
        public RequisitionDTO SelectedRequisition { get; set; } = new();
        public bool IsLoading { get; set; } = true;

        protected async override Task OnInitializedAsync()
        {
            await UpdateList();
        }

        public async Task UpdateList()
        {
            IsLoading = true;
            await Task.Delay(1);
            RequisitionsList = await RequisitionService.GetAllRequisitions();
            IsLoading = false;
            StateHasChanged();
        }

        public async void CreateDialog()
        {
            var dialog = DialogService.Show<CreateRequisitionDialog>("");
            var result = await dialog.Result;

            if (!result.Cancelled)
            {
                await UpdateList();
            }
        }

        public void ShowRequisitionDetails()
        {
            var parameters = new DialogParameters();
            parameters.Add("SelectedRequisition", SelectedRequisition);

            DialogService.Show<RequisitionDetailsDialog>("", parameters);
        }
    }
}
