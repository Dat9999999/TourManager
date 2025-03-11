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

        public async Task<List<Customer>> SearchAsync(string keyword)
        {
            keyword = keyword.ToLower().Trim();

            // Nếu keyword là số nguyên -> thử tìm theo ID trước
            if (int.TryParse(keyword, out int id))
            {
                var customer = await _dbSet.FindAsync(id);
                return customer != null ? new List<Customer> { customer } : new List<Customer>();
            }

            // Nếu không phải số -> tìm theo các trường khác
            return await _dbSet.Where(c =>
                c.Name.ToLower().Contains(keyword) ||
                c.Phone.ToLower().Contains(keyword) ||
                c.Address.ToLower().Contains(keyword)
            ).ToListAsync();
        }

    }
}

