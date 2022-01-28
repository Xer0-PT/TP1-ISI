using System.Collections.Generic;
using TP1.Domain.Context;
using System.Linq;
using System.Threading.Tasks;
using TP1.Domain.Models;
using System;
using TP1.Domain.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace SOAPI.Services
{
    public class Persons : IPersons
    {
        public Persons()
        { }

        public Task<Person> GetPerson(int id)
        {
            try
            {
                DataContext db = new DataContext();

                return db.Persons.FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public async Task<Person> CreatePerson(Person person)
        {
            try
            {
                DataContext db = new DataContext();

                var aux = db.Persons.FirstOrDefault(x => x.Name == person.Name);

                if (aux != null) return null;

                person.CreateDate = DateTime.Now;
                person.ChangeDate = DateTime.Now;

                var result = db.Persons.Add(person).Entity;

                await db.SaveChangesAsync();

                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Person> GetAllPersons()
        {
            try
            {
                DataContext db = new DataContext();

                var list = db.Persons.ToList();

                return list;

            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<bool> UpdatePerson(int id, bool? covid, string name = null, string snsNumber = null, string email = null)
        {
            try
            {
                DataContext db = new DataContext();

                var person = db.Persons.FirstOrDefault(x => x.Id == id);

                if (name != null) { person.Name = name; }
                if (snsNumber != null) { person.SnsNumber = snsNumber; }
                if (email != null) { person.Email = email; }
                if (covid != null) { person.Covid = (bool)covid; }

                person.ChangeDate = DateTime.Now;

                db.Persons.Update(person);

                await db.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<Person> GetAllActivePersons()
        {
            try
            {
                DataContext db = new DataContext();

                var list = db.Persons.Where(x => x.Active == true).ToList();

                return list;

            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<bool> DeletePerson(int id)
        {
            DataContext db = new DataContext();
            try
            {
                var person = db.Persons.FirstOrDefault(x => x.Id == id);

                person.Active = false;
                person.ChangeDate = DateTime.Now;

                db.Persons.Update(person);

                await db.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<bool> CreatePersonCovid(PersonCovid person)
        {
            try
            {
                DataContext db = new DataContext();
                
                var infected = db.Persons.FirstOrDefault(x => x.Id == person.PersonId);

                if (infected == null) { return false; }

                person.Person = infected;
                person.CreateDate = DateTime.Now;

                db.PersonCovids.Add(person);

                await db.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<PersonCovid> GetAllCovidPeople()
        {
            try
            {
                DataContext db = new DataContext();

               
                return db.PersonCovids.ToList();
            }
            catch (Exception)
            {

                return null;
            }

        }

        public async Task<bool> CreatePersonContact(PersonContact person)
        {
            try
            {
                DataContext db = new DataContext();

                person.CreateDate = DateTime.Now;

                db.PersonContacts.Add(person);

                await db.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<List<Person>> GetAllContacts(int infectedId, DateTime date)
        {
            try
            {
                DataContext db = new DataContext();

                var list = await db.PersonContacts.Where(p => p.InfectedId == infectedId &&
                                                        p.Date.Day == date.Day &&
                                                        p.Date.Month == date.Month &&
                                                        p.Date.Year == date.Year &&
                                                        p.Date.Hour == date.Hour &&
                                                        p.Date.Minute == date.Minute).ToListAsync();

                var result = new List<Person>();

                if (list.Count != 0)
                {
                    foreach (var contact in list)
                    {
                        var person = db.Persons.FirstOrDefault(x => x.Id == contact.ContactId);
                        result.Add(person);
                    }
                }

                return result;
            }
            catch (Exception)
            {

                return null;
            }

        }
    }
}
