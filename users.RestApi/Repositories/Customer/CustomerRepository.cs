using users.RestApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using users.RestApi.Data;
using users.RestApi.Repositories.Customer;

namespace users.RestApi.Repositories.Customer
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _context;

        public CustomerRepository(AppDbContext context)
        {
            _context = context;
        }

        public Task<Models.Customer> AddAsync(Models.Customer customer)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Models.Customer>> GetAllAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        public Task<Models.Customer> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Models.Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}