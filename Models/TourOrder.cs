using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TourManagerment.Models
{
    [Table("TourOrders")]
    public class TourOrder
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime CreationTime { get; set; }

        [Required, StringLength(50)]
        public string Status { get; set; } = string.Empty;


        public int? CustomerID { get; set; }

        [ForeignKey("CustomerID")]
        public Customer? Customer { get; set; }

        public int? TourID { get; set; }

        [ForeignKey("TourID")]
        public Tour? Tour { get; set; }

        public Invoice? Invoice { get; set; }
    }
}
