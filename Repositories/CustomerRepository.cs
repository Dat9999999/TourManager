using Microsoft.EntityFrameworkCore;
using TourManagerment.Models;

namespace TourManagerment.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>
    {
        public CustomerRepository()
        {
        }

        public async Task<Customer?> FindByPhone(string phone)
        {
            return await _dbSet.FirstOrDefaultAsync(c => c.Phone == phone);
        }
    }
}

