using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Collections.Generic;
using System.Threading.Tasks;
using TP1.Domain.Models.DTO;

namespace WASM.Blazor.Pages.Quarantine
{
    public partial class QuarantineDetailsDialog
    {
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        [Parameter] public PersonCovidDTO SelectedPerson { get; set; }
        [Parameter] public int TeamId { get; set; }
        [Parameter] public string PersonName { get; set; }
        public List<PersonDTO> ContactsList { get; set; } = new();
        public TeamDTO Team { get; set; } = new();
        void Cancel() => MudDialog.Cancel();

        protected override async Task OnInitializedAsync()
        {
            ContactsList = await PersonService.GetAllContactPersons(SelectedPerson.PersonId, SelectedPerson.DateOfInfection);
            Team = await TeamService.GetTeam(SelectedPerson.TeamId);
        }
    }
}
