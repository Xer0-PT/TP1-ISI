using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using TP1.Domain.Models.DTO;

namespace WASM.Blazor.Pages.Teams
{
    public partial class CreateTeamDialog
    {
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        public string Name { get; set; }
        void Cancel() => MudDialog.Cancel();

        public async void Submit()
        {
            if (string.IsNullOrWhiteSpace(Name))
                Snackbar.Add("Field is required!", Severity.Error);
            else
            {
                var newTeam = new TeamDTO(Name, true);

                var result = await TeamService.AddTeam(newTeam);

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
