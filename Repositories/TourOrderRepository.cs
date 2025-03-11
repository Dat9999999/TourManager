using Microsoft.EntityFrameworkCore;
using TourManagerment.DTO;
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

        public async Task<List<TourOrder>> SearchAsync(string keyword)
        {
            keyword = keyword.ToLower().Trim();

            if (int.TryParse(keyword, out int id))
            {
                var tourOrder = await _dbSet.FindAsync(id);
                return tourOrder != null ? new List<TourOrder> { tourOrder } : new List<TourOrder>();
            }

            return await _dbSet
                .Include(o => o.Customer)
                .Include(o => o.Tour)
                .Where(o => o.Customer.Name.ToLower().Contains(keyword)
                            || o.Tour.Name.ToLower().Contains(keyword)
                            || o.Status.ToLower().Contains(keyword))
                .ToListAsync();
        }

        public async Task<List<TourOrder>> GetAllTourOrdersAsync()
        {
            return await _context.TourOrders
                                 .Include(to => to.Customer) // Bao gồm thông tin khách hàng
                                 .Include(to => to.Tour)     // Bao gồm thông tin tour
                                 .ToListAsync();
        }

        public async Task<List<TourOrderDTO>> FilterTourOrdersByStatusAsync(string status)
        {
            var tourOrders = await _context.TourOrders
                .Include(to => to.Customer)  // Đảm bảo tải thông tin khách hàng
                .Include(to => to.Tour)      // Đảm bảo tải thông tin tour
                .Where(to => to.Status == status || status == "Tất cả") // Lọc theo trạng thái hoặc tất cả
                .ToListAsync();

            // Chuyển đổi TourOrder thành TourOrderDTO
            return tourOrders.Select(to => new TourOrderDTO
            {
                Id = to.Id,
                CustomerName = to.Customer != null ? to.Customer.Name : "Không có thông tin khách hàng",
                Phone = to.Customer != null ? to.Customer.Phone : "Không có số điện thoại",
                TourName = to.Tour != null ? to.Tour.Name : "Không có thông tin tour",
                Address = to.Customer != null ? to.Customer.Address : "Không có thông tin địa chỉ",
                Status = to.Status,
                CreationTime = to.CreationTime.ToString("dd/MM/yyyy HH:mm")
            }).ToList();
        }

    }
}
