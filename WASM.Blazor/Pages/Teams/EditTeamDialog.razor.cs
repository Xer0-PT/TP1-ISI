using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using TP1.Domain.Models.DTO;

namespace WASM.Blazor.Pages.Teams
{
    public partial class EditTeamDialog
    {
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        [Parameter] public TeamDTO SelectedTeam { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        protected override void OnInitialized()
        {
            Name = SelectedTeam.Name;
            IsActive = SelectedTeam.Active;
        }

        void Cancel() => MudDialog.Cancel();

        public async void Submit()
        {
            if (string.IsNullOrWhiteSpace(Name))
                Snackbar.Add("Field is required!", Severity.Error);
            else
            {
                SelectedTeam.Name = Name;
                SelectedTeam.Active = IsActive;

                var result = await TeamService.UpdateTeam(SelectedTeam);

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
                await TeamService.DeleteTeam(SelectedTeam.Id);
                MudDialog.Close(DialogResult.Ok(true));
            }
        }
    }
}
