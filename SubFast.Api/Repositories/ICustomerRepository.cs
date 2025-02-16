using SubFast.Models;

namespace SubFast.Api.Repositories
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetCustomers();
        Task<Customer?> GetCustomer(int customerId);
        Task<Customer> AddCustomer(Customer customer);
        Task<bool> UpdateCustomer(Customer customer);
        Task<bool> DeleteCustomer(int customerId);
        Task<IEnumerable<Customer>> Search(string name, Gender? gender);
    }
}
