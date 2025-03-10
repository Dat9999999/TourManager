namespace TourManagerment.DTO
{
    public class ReportDTO
    {
        public string Category { get; set; } // Loại tour (cho báo cáo theo loại) hoặc Thời gian (cho báo cáo theo tháng)
        public int Quantity { get; set; }    // Số lượng tour
        public decimal Revenue { get; set; } // Doanh thu
        public string FormattedRevenue => Revenue.ToString("N0") + " VNĐ"; // Định dạng doanh thu cho hiển thị

        public ReportDTO(string category, int quantity, decimal revenue)
        {
            Category = category;
            Quantity = quantity;
            Revenue = revenue;
        }
    }
}
