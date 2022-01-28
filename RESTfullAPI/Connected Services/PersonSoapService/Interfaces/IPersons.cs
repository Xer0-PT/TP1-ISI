using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;
using TP1.Domain.Models;

namespace RestfullAPI.Connected_Services.PersonSoapService
{
    [GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3-preview3.21351.2")]
    [ServiceContractAttribute(ConfigurationName = "PersonSoapService.IPersons")]
    public interface IPersons
    {
        [OperationContractAttribute(Action = "http://tempuri.org/IPersons/GetPerson", ReplyAction = "http://tempuri.org/IPersons/GetPersonResponse")]
        Task<Person> GetPersonAsync(int id);

        [OperationContractAttribute(Action = "http://tempuri.org/IPersons/CreatePerson", ReplyAction = "http://tempuri.org/IPersons/CreatePersonResponse")]
        Task<Person> CreatePersonAsync(Person person);

        [OperationContractAttribute(Action = "http://tempuri.org/IPersons/GetAllPersons", ReplyAction = "http://tempuri.org/IPersons/GetAllPersonsResponse")]
        Task<List<Person>> GetAllPersonsAsync();

        [OperationContractAttribute(Action = "http://tempuri.org/IPersons/UpdatePerson", ReplyAction = "http://tempuri.org/IPersons/UpdatePersonResponse")]
        Task<bool> UpdatePersonAsync(int id, System.Nullable<bool> covid, string name, string snsNumber, string email);

        [OperationContractAttribute(Action = "http://tempuri.org/IPersons/GetAllActivePersons", ReplyAction = "http://tempuri.org/IPersons/GetAllActivePersonsResponse")]
        Task<List<Person>> GetAllActivePersonsAsync();

        [OperationContractAttribute(Action = "http://tempuri.org/IPersons/DeletePerson", ReplyAction = "http://tempuri.org/IPersons/DeletePersonResponse")]
        Task<bool> DeletePersonAsync(int id);

        [OperationContractAttribute(Action = "http://tempuri.org/IPersons/CreatePersonCovid", ReplyAction = "http://tempuri.org/IPersons/CreatePersonCovidResponse")]
        Task<bool> CreatePersonCovidAsync(PersonCovid person);

        [OperationContractAttribute(Action = "http://tempuri.org/IPersons/GetAllCovidPeople", ReplyAction = "http://tempuri.org/IPersons/GetAllCovidPeopleResponse")]
        Task<List<PersonCovid>> GetAllCovidPeopleAsync();

        [OperationContractAttribute(Action = "http://tempuri.org/IPersons/CreatePersonContact", ReplyAction = "http://tempuri.org/IPersons/CreatePersonContactResponse")]
        Task<bool> CreatePersonContactAsync(PersonContact person);

        [OperationContractAttribute(Action = "http://tempuri.org/IPersons/GetAllContacts", ReplyAction = "http://tempuri.org/IPersons/GetAllContactsResponse")]
        Task<List<Person>> GetAllContactsAsync(int infectedId, DateTime date);
    }
}
