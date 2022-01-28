using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;
using TP1.Domain.Models;

namespace SOAPI.Services
{
    [ServiceContract]
    public interface IPersons
    {
        [OperationContract]
        Task<Person> GetPerson(int id);

        [OperationContract]
        Task<Person> CreatePerson(Person person);
        
        [OperationContract]
        List<Person> GetAllPersons();
        
        [OperationContract]
        Task<bool> UpdatePerson(int id, bool? covid, string name = "", string snsNumber = "", string email = "");
        
        [OperationContract]
        List<Person> GetAllActivePersons();
        
        [OperationContract]
        Task<bool> DeletePerson(int id);
        
        [OperationContract]
        Task<bool> CreatePersonCovid(PersonCovid person);
        
        [OperationContract]
        List<PersonCovid> GetAllCovidPeople();
        
        [OperationContract]
        Task<bool> CreatePersonContact(PersonContact person);
        
        [OperationContract]
        Task<List<Person>> GetAllContacts(int infectedId, DateTime date);

    }
}
