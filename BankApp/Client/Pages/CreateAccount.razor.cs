using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BankApp.Client.Pages
{
    public class CreateAccountBase:ComponentBase
    {
        [Inject]
        public HttpClient _httpClient { get; set; }

        [Parameter]
        public int CustomerId { get; set; }

        protected override Task OnInitializedAsync()
        {
            Console.WriteLine(CustomerId);
            return base.OnInitializedAsync();
        }
        

        /*
         Hämta 1 kund
         
        Skriv ut namnet på kunden 

        Ange en konto typ (bara ett sparkonto)

        Combolista som visar kontotyper

        Skap inte gå att skapa ett lönekoto för det finns redan.

        Spara knapp 

        Anropp ny mvc enpoint som skapar kontotr


         */

    }
}
