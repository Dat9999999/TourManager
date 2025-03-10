using TourManagerment.Models;
using TourManagerment.Services;

namespace TourManagerment.Forms.TourManagerment
{
    public partial class EditTourForm : Form
    {
        private TourService tourService;
        private Tour currentTour;
        public EditTourForm(Tour tour)
        {
            InitializeComponent();
            tourService = new TourService();
            this.currentTour = tour;
        }

        private void EditTourForm_Load(object sender, EventArgs e)
        {
            tbName.Text = currentTour.Name;
            nudCost.Text = currentTour.Cost.ToString();
            nudDuration.Text = currentTour.Duration.ToString();
            dtpStartDate.Value = currentTour.StartDate;
            cbType.Text = currentTour.Type;
            cbTransportMethod.Text = currentTour.TransportationMethod;
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            currentTour.Name = tbName.Text;
            currentTour.Cost = int.Parse(nudCost.Text);
            currentTour.Duration = int.Parse(nudDuration.Text);

            currentTour.StartDate = DateTime.Parse(dtpStartDate.Text);
            currentTour.EndDate = currentTour.StartDate.AddDays(currentTour.Duration);
            currentTour.Type = cbType.Text;
            currentTour.TransportationMethod = cbTransportMethod.Text;
            if (currentTour.Name == "" || currentTour.Cost == 0 || currentTour.StartDate == null || currentTour.Duration == 0 || currentTour.Type == "" ||
                currentTour.TransportationMethod == "")
            {
                MessageBox.Show("Bạn cần nhập đầy đủ dữ liệu");
                return;
            }
            try
            {
                await tourService.UpdateTourAsync(currentTour);
                MessageBox.Show("Sửa tour thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm tour thất bại");

            }
        }
    }
}
