using Microsoft.EntityFrameworkCore;
using TourManagerment.Models;

namespace TourManagerment.Repositories
{
    public class TourOrderRepository : GenericRepository<TourOrder>
    {
        public TourOrderRepository()
        {
        }

        public async Task<TourOrder?> GetByIdWithDetailsAsync(int id)
        {
            return await _dbSet
                .Include(o => o.Tour) // Load Tour
                .Include(o => o.Customer) // Load Customer
                .Include(o => o.Invoice) // Load Invoice nếu cần
                .FirstOrDefaultAsync(o => o.Id == id);
        }



    }
}
