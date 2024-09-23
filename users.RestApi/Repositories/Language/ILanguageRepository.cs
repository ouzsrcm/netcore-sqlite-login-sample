using users.RestApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace users.RestApi.Repositories.Language
{
    public interface ILanguageRepository
    {
        Task<IEnumerable<Models.Language>> GetAllAsync();
        Task<Models.Language> GetByIdAsync(int id);
        Task<Models.Language> AddAsync(Models.Language language);
        Task UpdateAsync(Models.Language language);
        Task DeleteAsync(int id);
    }
}