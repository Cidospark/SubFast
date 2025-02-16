using Microsoft.EntityFrameworkCore;
using SubFast.Api.Data;
using SubFast.Models;
using System;

namespace SubFast.Api.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly SubFastDbContext _context;

        public CustomerRepository(SubFastDbContext context)
        {
            _context = context;
        }
        public async Task<Customer> AddCustomer(Customer customer)
        {
            var result = await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> DeleteCustomer(int customerId)
        {
            var result = await GetCustomer(customerId);
            if (result != null)
            {
                _context.Remove(result);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Customer?> GetCustomer(int customerId)
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.CustomerId == customerId);
        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<bool> UpdateCustomer(Customer customer)
        {
            if (customer != null)
            {
                //_context.Update(customer);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<IEnumerable<Customer>> Search(string name, Gender? gender)
        {
            IQueryable<Customer> query = _context.Customers;

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(e => e.FirstName.Contains(name)
                            || e.LastName.Contains(name));
            }

            if (gender != null)
            {
                query = query.Where(e => e.Gender == gender);
            }

            return await query.ToListAsync();
        }
    }
}
