namespace TourManagerment.DTO
{
    public class TourDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; } // Số ngày
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Type { get; set; }
        public decimal Cost { get; set; } // Chi phí
        public string DisplayText { get; set; } // Thêm thuộc tính DisplayText

        public TourDTO() { }
    }

}
