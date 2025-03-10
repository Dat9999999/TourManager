using TourManagerment.DTO;
using TourManagerment.Repositories;

namespace TourManagerment.Services
{
    public class ScheduleService
    {
        private readonly TourOrderRepository _tourOrderRepository;
        private readonly CustomerRepository _customerRepository;
        private readonly InvoiceRepository _invoiceRepository;
        private readonly TourRepository _tourRepository;

        public ScheduleService()
        {
            _customerRepository = new CustomerRepository();
            _invoiceRepository = new InvoiceRepository();
            _tourRepository = new TourRepository();
            _tourOrderRepository = new TourOrderRepository();
        }

        public async Task<List<ScheduleDTO>> GetAllSchedulesAsync()
        {
            try
            {
                // Lấy tất cả TourOrder kèm thông tin chi tiết
                var tourOrders = await _tourOrderRepository.GetAllAsync();

                // Tạo danh sách ScheduleDTO
                var schedules = new List<ScheduleDTO>();

                foreach (var tourOrder in tourOrders)
                {
                    // Lấy thông tin liên quan
                    var customer = tourOrder.CustomerID.HasValue
                        ? await _customerRepository.GetByIdAsync(tourOrder.CustomerID.Value)
                        : null;

                    var tour = tourOrder.TourID.HasValue
                        ? await _tourRepository.GetByIdAsync(tourOrder.TourID.Value)
                        : null;

                    var invoice = await _invoiceRepository.FindAsync(i => i.TourOrderID == tourOrder.Id);

                    // Tạo ScheduleDTO
                    var schedule = new ScheduleDTO(customer, tourOrder, tour, invoice.FirstOrDefault());
                    schedules.Add(schedule);
                }

                return schedules;
            }
            catch (Exception ex)
            {
                // Xử lý lỗi (có thể log lỗi thay vì ném exception)
                throw new Exception("Lỗi khi lấy danh sách lịch trình: " + ex.Message, ex);
            }
        }
    }
}