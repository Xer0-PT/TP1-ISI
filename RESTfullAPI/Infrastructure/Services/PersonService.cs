using RestfullAPI.Infrastructure.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace RestfullAPI.Infrastructure.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task CheckTimeOfCovid()
        {
            var persons = await _personRepository.GetPersons();

            var personCovids = await _personRepository.GetPersonCovidTrue();

            if (persons != null && personCovids != null)
            {
                foreach (var person in persons)
                {
                    var infected = personCovids.LastOrDefault(x => x.PersonId == person.Id);

                    if (infected != null)
                    {
                        if (DateTime.Now >= infected.DateOfInfection.AddMinutes(1))
                        {
                            person.Covid = false;
                            await _personRepository.UpdatePerson(person);
                        }
                    }
                }
            }

        }
    }
}
