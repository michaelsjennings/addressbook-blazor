using MSJennings.AddressBook.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MSJennings.AddressBook.Shared.Services.Interfaces
{
    public interface IPersonDataService
    {
        Task<Person> CreatePerson(Person person);

        Task<IList<Person>> RetrieveAllPersons();

        Task<Person> RetrievePerson(int id);

        Task<Person> UpdatePerson(Person person);

        Task DeletePerson(Person person);
    }
}
