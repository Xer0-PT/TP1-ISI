using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TP1.Domain.Models.DTO;

namespace WASM.Blazor.Pages.Persons
{
    public partial class EditPersonDialog
    {
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        [Parameter] public PersonDTO SelectedPerson { get; set; }
        public List<PersonDTO> PersonsList { get; set; } = new();
        public List<TeamDTO> TeamsList { get; set; } = new();
        public HashSet<PersonDTO> PersonContactList { get; set; } = new();
        public string Name { get; set; }
        public string SnsNumber { get; set; }
        public string Email { get; set; }
        public bool IsInfected { get; set; }
        public bool ShowAllPersons { get; set; } = false;
        public int Click { get; set; } = 0;
        public int SelectedTeamId { get; set; } = 1;
        public bool ShowTeams { get; set; } = false;

        protected override void OnInitialized()
        {
            Name = SelectedPerson.Name;
            SnsNumber = SelectedPerson.SnsNumber;
            Email = SelectedPerson.Email;
            IsInfected = SelectedPerson.Covid;
        }

        void Cancel() => MudDialog.Cancel();


        public async void Submit()
        {
            if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(SnsNumber) || string.IsNullOrWhiteSpace(Email))
            {
                Snackbar.Add("All fields are required!", Severity.Error);
            }
            else
            {
                Click++;
                if (IsInfected)
                {
                    await LoadAllPersons();

                    ShowTeams = true;

                    if (PersonsList.Count > 0)
                        ShowAllPersons = true;

                    StateHasChanged();
                }

                if (!IsInfected || Click == 2)
                {
                    UpdatePerson();
                }
            }
        }

        public async void UpdatePerson()
        {
            SelectedPerson.Name = Name;
            SelectedPerson.SnsNumber = SnsNumber;
            SelectedPerson.Email = Email;
            SelectedPerson.Covid = IsInfected;

            var result = await PersonService.UpdatePerson(SelectedPerson);
            //MudDialog.Close(DialogResult.Ok(true));
            if (result.IsSuccessStatusCode && IsInfected)
            {
                var personCovidDto = new PersonCovidDTO(SelectedPerson.Id, DateTime.Now, SelectedTeamId);

                if (!(await PersonService.CreatePersonCovid(personCovidDto)).IsSuccessStatusCode)
                    Snackbar.Add("PersonCovid was not created!", Severity.Error);

                if (PersonContactList.Count != 0)
                {
                    List<CreatePersonContactDto> personsContactList = new();

                    foreach (var contactPerson in PersonContactList)
                    {
                        var personContact = new CreatePersonContactDto(
                                            SelectedPerson.Id,
                                            contactPerson.Id,
                                            DateTime.Now,
                                            contactPerson,
                                            SelectedPerson
                        );

                        personsContactList.Add(personContact);
                    }

                    if (!(await PersonService.CreatePersonsContact(personsContactList)).IsSuccessStatusCode)
                        Snackbar.Add("PersonsContact were not created!", Severity.Error);
                }

                MudDialog.Close(DialogResult.Ok(true));
            }
            else if (result.IsSuccessStatusCode && !IsInfected)
                MudDialog.Close(DialogResult.Ok(true));
            else
            {
                Snackbar.Add(result.ToString(), Severity.Error);
                Cancel();
            }
        }

        public async Task LoadAllPersons()
        {
            PersonsList = (await PersonService.GetAllActivePersons()).FindAll(x => x.Id != SelectedPerson.Id);
            TeamsList = await TeamService.GetAllActiveTeams();
        }

        public async void Delete()
        {
            bool? result = await DialogService.ShowMessageBox("Delete", "Deleting can not be undone!", yesText: "Delete!", cancelText: "Cancel");
            StateHasChanged();

            if (result == true)
            {
                await PersonService.DeletePerson(SelectedPerson.Id);
                MudDialog.Close(DialogResult.Ok(true));
            }
        }
    }
}
