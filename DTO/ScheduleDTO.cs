using TourManagerment.Models;

namespace TourManagerment.DTO
{
    public class ScheduleDTO
    {
        public string CustomerInfo { get; set; }

        public string TourInfo { get; set; }

        public string TourStatus { get; set; } // "Chưa diễn ra", "Đang diễn ra", "Đã diễn ra"

        public string TimeStatus { get; set; } // "Kết thúc sau X ngày (dd/MM/yyyy)", "Bắt đầu sau X ngày (dd/MM/yyyy)", "Kết thúc từ X ngày trước (dd/MM/yyyy)"

        public string TourOrderInfo { get; set; }

        public string InvoiceInfo { get; set; }

        public ScheduleDTO() { }

        public ScheduleDTO(Customer customer, TourOrder tourOrder, Tour tour, Invoice invoice)
        {
            // Thông tin khách hàng
            CustomerInfo = customer != null
                ? $"ID({customer.Id}) - {customer.Name} - {customer.Phone} - {customer.Address}"
                : "Không có thông tin khách hàng";

            // Trạng thái tour dựa trên StartDate và EndDate
            if (tour != null)
            {
                var now = DateTime.Now;
                if (tour.StartDate > now)
                    TourStatus = "Chưa diễn ra";
                else if (tour.StartDate <= now && tour.EndDate >= now)
                    TourStatus = "Đang diễn ra";
                else
                    TourStatus = "Đã diễn ra";
            }
            else
            {
                TourStatus = "Không có thông tin tour";
            }

            // Thông tin tour
            TourInfo = tour != null
                ? $"ID({tour.Id}) - {tour.Name} - Bắt đầu: {tour.StartDate:dd/MM/yyyy} - Kết thúc: {tour.EndDate:dd/MM/yyyy} - Giá: {tour.Cost:N0} VNĐ"
                : "Không có thông tin tour";

            // Trạng thái thời gian tương đối kèm ngày tháng năm
            if (tour != null)
            {
                var now = DateTime.Now;
                var daysToStart = (tour.StartDate - now).Days;
                var daysToEnd = (tour.EndDate - now).Days;
                var daysSinceEnd = (now - tour.EndDate).Days;

                if (daysToStart > 0)
                    TimeStatus = $"Bắt đầu sau {daysToStart} ngày ({tour.StartDate:dd/MM/yyyy})";
                else if (daysToEnd >= 0)
                    TimeStatus = $"Kết thúc sau {daysToEnd} ngày ({tour.EndDate:dd/MM/yyyy})";
                else if (daysSinceEnd > 0)
                    TimeStatus = $"Kết thúc từ {daysSinceEnd} ngày trước ({tour.EndDate:dd/MM/yyyy})";
                else
                    TimeStatus = $"Đang diễn ra hôm nay ({tour.EndDate:dd/MM/yyyy})";
            }
            else
            {
                TimeStatus = "Không có thông tin thời gian";
            }

            // Thông tin đơn hàng
            TourOrderInfo = tourOrder != null
                ? $"ID({tourOrder.Id}) - Tạo: {tourOrder.CreationTime:dd/MM/yyyy HH:mm} - Trạng thái: {tourOrder.Status}"
                : "Không có thông tin đơn hàng";

            // Thông tin hóa đơn
            InvoiceInfo = invoice != null
                ? $"ID({invoice.Id}) - Số tiền: {invoice.amount:N0} VNĐ - Ngày: {invoice.createdAt:dd/MM/yyyy}"
                : "Chưa thanh toán";
        }
    }
}