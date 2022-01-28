using MudBlazor;
using System.Collections.Generic;
using System.Threading.Tasks;
using TP1.Domain.Models.DTO;

namespace WASM.Blazor.Pages.Requisitions
{
    public partial class RequisitionsByTeamPage
    {
        public bool IsLoading { get; set; } = true;
        public List<RequisitionDTO> RequisitionsList { get; set; } = new();
        public RequisitionDTO SelectedRequisition { get; set; } = new();
        public List<TeamDTO> TeamsList { get; set; } = new();
        public int selectedTeamId;
        public bool searched = false;

        protected override async Task OnInitializedAsync()
        {
            await Task.Delay(1);
            TeamsList = await TeamService.GetAllTeams();
            IsLoading = false;
        }

        public void ShowRequisitionDetails()
        {
            var parameters = new DialogParameters();
            parameters.Add("SelectedRequisition", SelectedRequisition);

            DialogService.Show<RequisitionDetailsDialog>("", parameters);
        }

        public async void Search()
        {
            searched = false;
            RequisitionsList.Clear();

            if (selectedTeamId > 0)
            {
                searched = true;
                IsLoading = true;
                await Task.Delay(1);
                RequisitionsList = await RequisitionService.GetRequisitionsByTeam(selectedTeamId);
                IsLoading = false;
            }
            StateHasChanged();
        }
    }
}
