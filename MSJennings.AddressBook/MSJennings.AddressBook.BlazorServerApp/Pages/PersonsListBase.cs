using Microsoft.AspNetCore.Components;
using MSJennings.AddressBook.Shared.Models;
using MSJennings.AddressBook.Shared.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MSJennings.AddressBook.BlazorServerApp.Pages
{
    public class PersonsListBase : ComponentBase
    {
        [Inject]
        public IPersonDataService PersonDataService { get; set; }

        public IEnumerable<Person> Persons { get; private set; }

        protected override async Task OnInitializedAsync()
        {
            Persons = await PersonDataService.RetrieveAllPersons();

            await base.OnInitializedAsync();
        }
    }
}
