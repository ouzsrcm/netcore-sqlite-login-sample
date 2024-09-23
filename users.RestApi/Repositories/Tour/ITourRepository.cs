using users.RestApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace users.RestApi.Repositories.Tour
{
    public interface ITourRepository
    {
        Task<IEnumerable<Models.Tour>> GetAllAsync();
        Task<Models.Tour> GetByIdAsync(int id);
        Task<Models.Tour> AddAsync(Models.Tour customer);
        Task UpdateAsync(Models.Tour customer);
        Task DeleteAsync(int id);
    }
}