using users.RestApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using users.RestApi.Data;
using users.RestApi.Repositories.Tour;

namespace users.RestApi.Repositories.Tour
{
    public class TourRepository : ITourRepository
    {
        private readonly AppDbContext _context;

        public TourRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Models.Tour> AddAsync(Models.Tour tour)
        {
            await _context.Tours.AddAsync(tour);
            await _context.SaveChangesAsync();
            return tour;
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Models.Tour>> GetAllAsync()
        {
            return await _context.Tours.ToListAsync();
        }

        public Task<Models.Tour> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Models.Tour tour)
        {
            throw new NotImplementedException();
        }
    }
}