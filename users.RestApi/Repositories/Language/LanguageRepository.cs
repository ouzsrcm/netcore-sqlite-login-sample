using users.RestApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using users.RestApi.Data;
using users.RestApi.Repositories.Tour;

namespace users.RestApi.Repositories.Language
{
    public class LanguageRepository : ILanguageRepository
    {
        private readonly AppDbContext _context;

        public TourRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Models.Language> AddAsync(Models.Language language)
        {
            await _context.Languages.AddAsync(language);
            await _context.SaveChangesAsync();
            return language;
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Models.Language>> GetAllAsync()
        {
            return await _context.Languages.ToListAsync();
        }

            public Task<Models.Language> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Models.Language language)
        {
            throw new NotImplementedException();
        }
    }
}