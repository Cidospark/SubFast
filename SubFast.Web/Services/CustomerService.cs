using SubFast.Models;
using System.Net.Http;

namespace SubFast.Web.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly HttpClient _httpClient;
        public CustomerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            var result = new List<Customer>();
            result = await _httpClient.GetFromJsonAsync<List<Customer>>("api/customers");
            return result;
        }
    }
}
