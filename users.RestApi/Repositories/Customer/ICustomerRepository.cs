using users.RestApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace users.RestApi.Repositories.Customer
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Models.Customer>> GetAllAsync();
        Task<Models.Customer> GetByIdAsync(int id);
        Task<Models.Customer> AddAsync(Models.Customer customer);
        Task UpdateAsync(Models.Customer customer);
        Task DeleteAsync(int id);
    }
}