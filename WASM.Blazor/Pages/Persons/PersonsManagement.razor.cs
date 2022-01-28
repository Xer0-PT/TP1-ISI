using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TP1.Domain.Models;
using TP1.Domain.Models.DTO;

namespace WASM.Blazor.Pages.Persons
{
    public partial class PersonsManagement
    {
        public List<PersonDTO> PersonsList { get; set; } = new();
        public PersonDTO SelectedPerson { get; set; } = new();
        public bool IsLoading { get; set; }

        protected async override Task OnInitializedAsync()
        {
            await LoadPersons();
        }

        public async Task LoadPersons()
        {
            IsLoading = true;
            await Task.Delay(1);
            PersonsList = await PersonService.GetAllPersons();
            IsLoading = false;
            StateHasChanged();
        }

        public async void CreateDialog()
        {
            var dialog = DialogService.Show<CreatePersonDialog>("");
            var result = await dialog.Result;

            if (!result.Cancelled)
            {
                await LoadPersons();
            }
        }

        public async void EditDialog()
        {
            var parameters = new DialogParameters();
            parameters.Add("SelectedPerson", SelectedPerson);

            var dialog = DialogService.Show<EditPersonDialog>("", parameters);
            var result = await dialog.Result;

            if (!result.Cancelled)
            {
                await LoadPersons();
            }
        }
    }
}
