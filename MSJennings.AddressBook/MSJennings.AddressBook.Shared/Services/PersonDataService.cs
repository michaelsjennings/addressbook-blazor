using MSJennings.AddressBook.Shared.Models;
using MSJennings.AddressBook.Shared.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSJennings.AddressBook.Shared.Services
{
    public class PersonDataService : IPersonDataService
    {
        private IList<Person> Persons { get; set; }

        public PersonDataService()
        {
            Persons = new List<Person>
            {
                new Person { Id = 101, FirstName = "Amy", LastName = "Anderson" },
                new Person { Id = 102, FirstName = "Brian", LastName = "Brown" },
                new Person { Id = 103, FirstName = "Christine", LastName = "Collins" }
            };
        }

        public async Task<Person> CreatePerson(Person person)
        {
            if (!Persons.Any())
            {
                person.Id = 101;
            }
            else
            {
                person.Id = Persons.Max(x => x.Id) + 1;
            }

            Persons.Add(person);

            return await Task.FromResult(person);
        }

        public async Task<IList<Person>> RetrieveAllPersons()
        {
            return await Task.FromResult(Persons);
        }

        public async Task<Person> RetrievePerson(int id)
        {
            var all = await RetrieveAllPersons();
            var person = all.SingleOrDefault(x => x.Id == id);

            return await Task.FromResult(person);
        }

        public async Task<Person> UpdatePerson(Person person)
        {
            var personToUpdate = await RetrievePerson(person.Id);
            if (personToUpdate != null)
            {
                personToUpdate.FirstName = person.FirstName;
                personToUpdate.LastName = person.LastName;
            }

            return await Task.FromResult(personToUpdate);
        }

        public async Task DeletePerson(Person person)
        {
            var personToDelete = await RetrievePerson(person.Id);
            if (personToDelete != null)
            {
                Persons.Remove(personToDelete);
            }
        }
    }
}
