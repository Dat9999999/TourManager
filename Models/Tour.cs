using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TourManagerment.Models
{
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

        [ForeignKey("TourGuide")]
        public int TourGuideID { get; set; } // ID hướng dẫn viên

        [Required, StringLength(50)]
        public string? TransportationMethod { get; set; } // Phương thức vận chuyển (xe hoặc máy bay)

        // Navigation property
        //public virtual TourGuide TourGuide { get; set; }
    }
}
