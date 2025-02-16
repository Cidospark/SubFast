using Microsoft.AspNetCore.Components;
using SubFast.Models;
using SubFast.Web.Services;

namespace SubFast.Web.Pages
{
    public class CustomerListBase : ComponentBase
    {
        [Inject]
        private ICustomerService _customerService { get; set; }

        public IEnumerable<Customer> Customers { get; set; } = new List<Customer>();

        protected override async Task OnInitializedAsync()
        {
            await Task.Run(LoadCustomers);
        }

        protected async Task LoadCustomers()
        {
            System.Threading.Thread.Sleep(1000);
            Customers = await _customerService.GetCustomers();
        }
    }
}
