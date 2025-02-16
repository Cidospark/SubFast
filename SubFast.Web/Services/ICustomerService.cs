using SubFast.Models;

namespace SubFast.Web.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetCustomers();
    }
}
