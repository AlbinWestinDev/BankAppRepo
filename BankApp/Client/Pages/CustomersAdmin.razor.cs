using BankApp.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BankApp.Client.Pages
{
    public class CustomerAdminBase:ComponentBase
    {

        [Inject]
        public HttpClient _httpClient { get; set; }

        public List<Customer> Customers { get; set; } = new List<Customer>();

        protected override async Task<Task> OnInitializedAsync()
        {
            await GetCustomerList();
            return base.OnInitializedAsync();
        }
        public async Task GetCustomerList()
        {
            var customers = await _httpClient.GetFromJsonAsync<List<Customer>>($"customer/getunregistered");

            Customers = customers;
        }
        public async Task ApproveAsAdmin(Customer customer)
        {
            await _httpClient.PutAsJsonAsync($"customer/approveasadmin/",customer);
        }
        public async Task ApproveAsCustomer(Customer customer)
        {
            await _httpClient.PutAsJsonAsync($"customer/approveascustomer/", customer);
        }

    }
}
