using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TourManagerment.Models
{
    [Table("Invoices")]
    public class Invoice
    {
        [Key]
        public int Id { get; set; }

        public long amount { get; set; }

        public DateTime createdAt { get; set; }

        public int? TourOrderID { get; set; }

        [ForeignKey("TourOrderID")]
        public TourOrder? TourOrder { get; set; }
    }
}
