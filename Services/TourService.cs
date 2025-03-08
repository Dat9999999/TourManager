using Microsoft.EntityFrameworkCore;
using TourManagerment.Data;
using TourManagerment.Models;

namespace TourManagerment.Services
{
    public class TourService
    {
        private readonly MTourContext _context;

        public TourService()
        {
            _context = new MTourContext();
        }

        public async Task<List<Tour>> GetAllToursAsync()
        {
            return await _context.Tours.ToListAsync();
        }

        public async Task<Tour?> GetTourByIdAsync(int id)
        {
            return await _context.Tours.FindAsync(id);
        }

        public async Task CreateTourAsync(Tour tour)
        {
            await _context.Tours.AddAsync(tour);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTourAsync(Tour tour)
        {
            _context.Tours.Update(tour);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTourAsync(int id)
        {
            var tour = await _context.Tours.FindAsync(id);
            if (tour != null)
            {
                _context.Tours.Remove(tour);
                await _context.SaveChangesAsync();
            }
        }
    }
}
