using System.Collections.Generic;
using System.Threading.Tasks;
using TP1.Domain.Models;

namespace RestfullAPI.Infrastructure.Repositories
{
    public interface IPersonRepository
    {
        Task<List<Person>> GetPersons();
        Task<List<PersonCovid>> GetPersonCovidTrue();
        Task<bool> UpdatePerson(Person person);
    }
}
