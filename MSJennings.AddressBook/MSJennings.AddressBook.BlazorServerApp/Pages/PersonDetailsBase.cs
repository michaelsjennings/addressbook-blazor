using Microsoft.AspNetCore.Components;
using MSJennings.AddressBook.Shared.Models;
using MSJennings.AddressBook.Shared.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSJennings.AddressBook.BlazorServerApp.Pages
{
    public class PersonDetailsBase : ComponentBase
    {
        [Inject]
        public IPersonDataService PersonDataService { get; set; }

        [Parameter]
        public string Id { get; set; }

        public Person Person { get; private set; }

        protected async override Task OnInitializedAsync()
        {
            Person = await PersonDataService.RetrievePerson(int.Parse(Id));

            await base.OnInitializedAsync();
        }
    }
}
