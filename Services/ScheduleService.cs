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

        public async Task<List<ScheduleDTO>> SearchSchedulesAsync(string keyword)
        {
            try
            {
                var tourOrders = await _tourOrderRepository.GetAllAsync(); // Lấy tất cả các tourOrder
                var schedules = new List<ScheduleDTO>();

                bool isNumeric = int.TryParse(keyword, out int numericKeyword); // Kiểm tra xem keyword có phải là số không

                foreach (var tourOrder in tourOrders)
                {
                    // Kiểm tra nếu từ khóa là số và so sánh với ID
                    if (isNumeric)
                    {
                        // Kiểm tra nếu ID của TourOrder, Customer, hoặc TourOrderId có khớp với numericKeyword
                        if (tourOrder.Id == numericKeyword ||
                            tourOrder.CustomerID == numericKeyword ||
                            tourOrder.TourID == numericKeyword)
                        {
                            var customer = tourOrder.CustomerID.HasValue
                                ? await _customerRepository.GetByIdAsync(tourOrder.CustomerID.Value)
                                : null;

                            var tour = tourOrder.TourID.HasValue
                                ? await _tourRepository.GetByIdAsync(tourOrder.TourID.Value)
                                : null;

                            var invoice = await _invoiceRepository.FindAsync(i => i.TourOrderID == tourOrder.Id);

                            var schedule = new ScheduleDTO(customer, tourOrder, tour, invoice.FirstOrDefault());
                            schedules.Add(schedule);
                        }
                    }
                    else
                    {
                        // Tìm kiếm bình thường theo các trường trong ScheduleDTO nếu keyword không phải là số
                        var customer = tourOrder.CustomerID.HasValue
                            ? await _customerRepository.GetByIdAsync(tourOrder.CustomerID.Value)
                            : null;

                        var tour = tourOrder.TourID.HasValue
                            ? await _tourRepository.GetByIdAsync(tourOrder.TourID.Value)
                            : null;

                        var invoice = await _invoiceRepository.FindAsync(i => i.TourOrderID == tourOrder.Id);

                        var schedule = new ScheduleDTO(customer, tourOrder, tour, invoice.FirstOrDefault());

                        // Kiểm tra nếu từ khóa (keyword) có xuất hiện trong các trường của ScheduleDTO
                        // Chỉ so sánh khi các trường không phải là null
                        if ((schedule.CustomerInfo?.ToLower()?.Contains(keyword.ToLower()) ?? false) ||
                            (schedule.TourInfo?.ToLower()?.Contains(keyword.ToLower()) ?? false) ||
                            (schedule.TourStatus?.ToLower()?.Contains(keyword.ToLower()) ?? false) ||
                            (schedule.TimeStatus?.ToLower()?.Contains(keyword.ToLower()) ?? false) ||
                            (schedule.TourOrderInfo?.ToLower()?.Contains(keyword.ToLower()) ?? false) ||
                            (schedule.InvoiceInfo?.ToLower()?.Contains(keyword.ToLower()) ?? false))
                        {
                            schedules.Add(schedule);
                        }
                    }
                }

                return schedules;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tìm kiếm lịch trình: " + ex.Message, ex);
            }
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