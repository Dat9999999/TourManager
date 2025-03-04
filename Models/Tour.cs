using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TourManagerment.Models
{
    [Table("Tours")]
    public class Tour
    {
        [Key]
        public int ID { get; set; }  // Khóa chính

        [Required, StringLength(255)]
        public string? Name { get; set; }// Tên tour

        public int Duration { get; set; } // Thời gian (số ngày)

        [Required]
        public DateTime StartDate { get; set; } // Ngày bắt đầu

        [Required]
        public DateTime EndDate { get; set; } // Ngày kết thúc

        [Required, StringLength(50)]
        public string? Type { get; set; } // Loại tour (Cao cấp, Tiêu chuẩn, Tiết kiệm)

        [Required, Column(TypeName = "decimal(18,2)")]
        public decimal Cost { get; set; } // Giá tour

        public string? Pics { get; set; } // Hình ảnh (lưu đường dẫn)

        public int? TourGuideId { get; set; } // ID hướng dẫn viên

        [ForeignKey("TourGuideId")]
        public TourGuide? TourGuide { get; set; }

        [Required, StringLength(50)]
        public string? TransportationMethod { get; set; } // Phương thức vận chuyển (xe hoặc máy bay)

        public ICollection<TourOrder> TourOrders { get; set; } = new List<TourOrder>();

        // Navigation property
        //public virtual TourGuide TourGuide { get; set; }
    }
}
