using users.RestApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace users.RestApi.Repositories.Tour
{
    public interface ITourRepository
    {
        Task<IEnumerable<Models.Tour>> GetAllAsync();
        Task<Models.Tour> GetByIdAsync(int id);
        Task<Models.Tour> AddAsync(Models.Tour tour);
        Task UpdateAsync(Models.Tour tour);
        Task DeleteAsync(int id);
    }
}