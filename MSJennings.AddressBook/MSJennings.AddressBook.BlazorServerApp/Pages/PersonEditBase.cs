using Microsoft.AspNetCore.Components;
using MSJennings.AddressBook.Shared.Models;
using MSJennings.AddressBook.Shared.Services.Interfaces;
using System.Threading.Tasks;

namespace MSJennings.AddressBook.BlazorServerApp.Pages
{
    public class PersonEditBase : ComponentBase
    {
        [Inject]
        public IPersonDataService PersonDataService { get; set; }

        [Parameter]
        public string Id { get; set; }

        public Person  Person { get; private set; }

        protected override async Task OnInitializedAsync()
        {
            Person = string.IsNullOrWhiteSpace(Id)
                ? new Person()
                : await PersonDataService.RetrievePerson(int.Parse(Id));

            await base.OnInitializedAsync();
        }

        protected async Task HandleValidSubmit()
        {
            if (!string.IsNullOrWhiteSpace(Id))
            {
                Person.Id = int.Parse(Id);
                Person = await PersonDataService.UpdatePerson(Person);
            }
            else
            {
                Person = await PersonDataService.CreatePerson(Person);
            }
        }
    }
}
