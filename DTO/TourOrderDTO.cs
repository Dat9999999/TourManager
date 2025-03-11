using TourManagerment.Models;

namespace TourManagerment.DTO
{
    public class TourOrderDTO
    {
        public int Id { get; set; } // Mã đơn đặt tour
        public string CustomerName { get; set; } // Tên khách hàng
        public string Phone { get; set; } // Số điện thoại khách hàng

        public string Address { get; set; }
        public string TourName { get; set; } // Tên tour
        public string CreationTime { get; set; } // Thời gian tạo đơn đặt tour
        public string Status { get; set; } // Trạng thái đơn hàng (đã xác nhận, chưa xác nhận...)

        public TourOrderDTO() { }

        public TourOrderDTO(TourOrder tourOrder, Customer customer, Tour tour)
        {
            Id = tourOrder.Id;
            CustomerName = customer != null ? customer.Name : "Không có thông tin khách hàng";
            Phone = customer != null ? customer.Phone : "Không có số điện thoại";
            TourName = tour != null ? tour.Name : "Không có thông tin tour";
            Status = tourOrder.Status;
            CreationTime = tourOrder.CreationTime.ToString("dd/MM/yyyy HH:mm");


        }
    }
}
