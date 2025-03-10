using TourManagerment.Models;
using TourManagerment.Services;

namespace TourManagerment.Forms.TourManagerment
{
    public partial class AddTourForm : Form
    {
        private TourService tourService;
        public AddTourForm()
        {
            InitializeComponent();
            tourService = new TourService();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private async void  btnAdd_Click(object sender, EventArgs e)
        {

            var name = tbName.Text;
            var cost = int.Parse(nudCost.Text);
            var duration = int.Parse(nudDuration.Text);
            DateTime startDate = DateTime.Parse(dtpStartDate.Text);
            DateTime endDate = startDate.AddDays(duration);
            var type = cbType.Text;
            var transportMethod = cbTransportMethod.Text;
            if(name == "" || cost == 0 || startDate == null || duration == 0 || type == "" ||
                transportMethod == "")
            {
                MessageBox.Show("Bạn cần nhập đầy đủ dữ liệu");
                return;
            }
            Tour newTour = new Tour(name, duration, startDate, endDate, type, cost, transportMethod);
            try
            {
                await tourService.CreateTourAsync(newTour);
                MessageBox.Show("Thêm tour thành công");
                tbName.Text = "";
                nudCost.Text = "0";
                nudDuration.Text = "0";
                dtpStartDate.Value = DateTime.Now;
                cbTransportMethod.SelectedIndex = 0;
                cbType.SelectedIndex = 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm tour thất bại");

            }
        }

        private void AddTourForm_Load(object sender, EventArgs e)
        {
            cbType.SelectedIndex = 0;
            cbTransportMethod.SelectedIndex = 0;

        }
    }
}
