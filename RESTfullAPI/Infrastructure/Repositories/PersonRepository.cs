using Microsoft.EntityFrameworkCore;
using RestfullAPI.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TP1.Domain.Context;
using TP1.Domain.Models;

namespace RestfullAPI.Infrastructure.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly DataContext _context;

        public PersonRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Person>> GetPersons()
        {
            return await _context.Persons.Where(p => p.Covid == true).ToListAsync();
        }

        public async Task<List<PersonCovid>> GetPersonCovidTrue()
        {
            return await _context.PersonCovids.ToListAsync();
        }

        public async Task<bool> UpdatePerson(Person person)
        {
            _context.Update(person);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
