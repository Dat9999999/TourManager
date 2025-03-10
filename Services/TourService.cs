using Microsoft.EntityFrameworkCore;
using TourManagerment.Data;
using TourManagerment.DTO;
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

        /// <summary>
        /// Báo cáo theo loại tour
        /// </summary>
        public async Task<List<ReportDTO>> GetReportByTourTypeAsync()
        {
            var report = await _context.Tours
                .Join(_context.TourOrders,
                    tour => tour.Id,
                    order => order.TourID,
                    (tour, order) => new { tour.Type, tour.Cost, order.Status })
                .Where(to => to.Status == "Đã thanh toán")
                .GroupBy(to => to.Type)
                .Select(g => new ReportDTO(
                    g.Key,
                    g.Count(),
                    g.Sum(x => x.Cost)
                ))
                .ToListAsync();

            return report;
        }

        /// <summary>
        /// Báo cáo theo thời gian đặt (theo tháng)
        /// </summary>
        public async Task<List<ReportDTO>> GetReportByBookingTimeAsync(DateTime startDate, DateTime endDate)
        {
            var report = await _context.TourOrders
                .Where(to => to.CreationTime >= startDate && to.CreationTime <= endDate && to.Status == "Đã thanh toán")
                .Join(_context.Tours,
                    order => order.TourID,
                    tour => tour.Id,
                    (order, tour) => new { order.CreationTime, tour.Cost })
                .GroupBy(to => new DateTime(to.CreationTime.Year, to.CreationTime.Month, 1))
                .Select(g => new ReportDTO(
                    g.Key.ToString("MM/yyyy"),
                    g.Count(),
                    g.Sum(x => x.Cost)
                ))
                .ToListAsync();

            return report;
        }
    }
}
