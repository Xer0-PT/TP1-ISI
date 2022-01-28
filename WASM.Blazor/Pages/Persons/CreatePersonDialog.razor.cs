using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TP1.Domain.Models.DTO;

namespace WASM.Blazor.Pages.Persons
{
    public partial class CreatePersonDialog
    {
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool IsInfected { get; set; } = false;
        public string SNSNumber { get; set; }
        public bool ShowAllPersons { get; set; } = false;
        public List<PersonDTO> PersonsList { get; set; } = new();
        public HashSet<PersonDTO> PersonContactList { get; set; } = new();
        public List<TeamDTO> TeamsList { get; set; } = new();
        public int SelectedTeamId { get; set; } = 1;
        public int Click { get; set; } = 0;


        void Cancel() => MudDialog.Cancel();

        public async void Add()
        {
            if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(SNSNumber) || string.IsNullOrWhiteSpace(Email) || SelectedTeamId == -1)
            {
                Snackbar.Add("All fields are required!", Severity.Error);
            }
            else
            {
                Click++;
                if (IsInfected)
                {
                    await LoadAllPersons();
                    if (PersonsList.Count > 0)
                    {
                        ShowAllPersons = true;
                        StateHasChanged();
                    }
                    else Click++;
                }

                if (!IsInfected || Click == 2)
                {
                    CreatePerson();
                }
            }
        }

        public async void CreatePerson()
        {
            var newPerson = await PersonService.CreatePerson(new PersonDTO(Name, SNSNumber, Email, IsInfected, true));

            if (newPerson == null)
                Snackbar.Add("Person was not created!", Severity.Error);

            if (IsInfected && newPerson != null)
            {
                var personCovidDto = new PersonCovidDTO(newPerson.Id, DateTime.Now, SelectedTeamId);

                if (!(await PersonService.CreatePersonCovid(personCovidDto)).IsSuccessStatusCode)
                    Snackbar.Add("PersonCovid was not created!", Severity.Error);

                if (PersonContactList.Count != 0)
                {
                    List<CreatePersonContactDto> personsContactList = new();

                    foreach (var contactPerson in PersonContactList)
                    {
                        var personContact = new CreatePersonContactDto(
                                            newPerson.Id,
                                            contactPerson.Id,
                                            DateTime.Now,
                                            contactPerson,
                                            newPerson
                        );

                        personsContactList.Add(personContact);
                    }

                    if (!(await PersonService.CreatePersonsContact(personsContactList)).IsSuccessStatusCode)
                        Snackbar.Add("PersonsContact were not created!", Severity.Error);
                }
            }
            MudDialog.Close(DialogResult.Ok(true));
        }

        public async Task LoadAllPersons()
        {
            PersonsList = await PersonService.GetAllActivePersons();
            TeamsList = await TeamService.GetAllActiveTeams();
        }
    }
}
