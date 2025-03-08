using TourManagerment.Models;
using TourManagerment.Repositories;

namespace TourManagerment.Services
{
    public class TourOrderService
    {
        private readonly TourOrderRepository _tourOrderRepository;

        public TourOrderService()
        {
            _tourOrderRepository = new TourOrderRepository();
        }



        public async Task<List<TourOrder>> GetAllTourOrdersAsync()
        {
            return await _tourOrderRepository.GetAllAsync();
        }

        public async Task<TourOrder?> GetTourOrderByIdAsync(int id)
        {
            return await _tourOrderRepository.GetByIdAsync(id);
        }

        public async Task AddTourOrderAsync(TourOrder order)
        {
            await _tourOrderRepository.AddAsync(order);
        }

        public async Task UpdateTourOrderAsync(TourOrder order)
        {
            await _tourOrderRepository.UpdateAsync(order);
        }

        public async Task DeleteTourOrderAsync(int id)
        {

            var tourOrder = await _tourOrderRepository.GetByIdAsync(id);
            if (tourOrder != null)
            {
                await _tourOrderRepository.DeleteAsync(tourOrder);
            }

        }

        public async Task<TourOrder?> GetByIdWithDetailsAsync(int id)
        {
            return await _tourOrderRepository.GetByIdWithDetailsAsync(id);
        }



    }
}
