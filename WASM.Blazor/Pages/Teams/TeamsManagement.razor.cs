using MudBlazor;
using System.Collections.Generic;
using System.Threading.Tasks;
using TP1.Domain.Models.DTO;

namespace WASM.Blazor.Pages.Teams
{
    public partial class TeamsManagement
    {
        public List<TeamDTO> TeamsList { get; set; } = new();
        public TeamDTO SelectedTeam { get; set; }
        public bool IsLoading { get; set; } = true;

        protected async override Task OnInitializedAsync()
        {
            await UpdateList();
            IsLoading = false;
        }

        public async Task UpdateList()
        {
            await Task.Delay(1);
            TeamsList = await TeamService.GetAllTeams();
            StateHasChanged();
        }

        public async void CreateDialog()
        {
            var dialog = DialogService.Show<CreateTeamDialog>("");
            var result = await dialog.Result;

            if (!result.Cancelled)
            {
                await UpdateList();
            }
        }

        public async void EditDialog()
        {
            var parameters = new DialogParameters();
            parameters.Add("SelectedTeam", SelectedTeam);

            var dialog = DialogService.Show<EditTeamDialog>("", parameters);
            var result = await dialog.Result;

            if (!result.Cancelled)
            {
                await UpdateList();
            }
        }
    }
}
