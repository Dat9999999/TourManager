using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace TourManagerment.Models
{
    [Table("Tours")]
    public class Tour
    {
        public Tour() { }

        public Tour( String Name , int Duration,DateTime StartDate, DateTime EndDate , string Type, decimal  Cost , string TransportationMethod )
        {
            this.Name = Name;
            this.Duration = Duration;
            this.StartDate = StartDate;
            this.EndDate = EndDate;
            this.Type = Type;
            this.Cost = Cost;
            this.TransportationMethod = TransportationMethod;

        }
        [Key]
        public int Id { get; set; }  // Khóa chính

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

        [AllowNull]
        public string? Pics { get; set; } // Hình ảnh (lưu đường dẫn)

        [AllowNull]
        public int? TourGuideId { get; set; } // ID hướng dẫn viên

        [ForeignKey("TourGuideId")]
        [AllowNull]
        public TourGuide? TourGuide { get; set; }

        [Required, StringLength(50)]
        public string? TransportationMethod { get; set; } // Phương thức vận chuyển (xe hoặc máy bay)

        public ICollection<TourOrder> TourOrders { get; set; } = new List<TourOrder>();
        
    }
}
