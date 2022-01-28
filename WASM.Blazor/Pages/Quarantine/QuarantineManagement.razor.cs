using MudBlazor;
using System.Collections.Generic;
using System.Threading.Tasks;
using TP1.Domain.Models.DTO;

namespace WASM.Blazor.Pages.Quarantine
{
    public partial class QuarantineManagement
    {
        public List<PersonCovidDTO> PersonCovidList { get; set; } = new();
        public List<PersonDTO> PersonList { get; set; } = new();
        public PersonCovidDTO SelectedPerson { get; set; } = new();
        public bool IsLoading { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await LoadData();
        }

        public async Task LoadData()
        {
            IsLoading = true;
            await Task.Delay(1);
            
            PersonCovidList = await PersonService.GetAllCovidPeople();

            if (PersonCovidList.Count != 0)
            {
                foreach (var item in PersonCovidList)
                {
                    PersonList.Add(await PersonService.GetPerson(item.PersonId));
                }
            }

            IsLoading = false;
            StateHasChanged();
        }

        public void ShowDetails()
        {
            var parameters = new DialogParameters();
            parameters.Add("SelectedPerson", SelectedPerson);
            parameters.Add("PersonName", PersonList.Find(x => x.Id == SelectedPerson.PersonId).Name);
            
            DialogService.Show<QuarantineDetailsDialog>("", parameters);
        }
    }
}
