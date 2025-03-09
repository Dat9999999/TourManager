using TourManagerment.Data;

namespace TourManagerment.Forms
{
    public partial class TourForm : Form
    {
        public TourForm()
        {
            InitializeComponent();
        }

        private void TourForm_Load(object sender, EventArgs e)
        {
            using (var context = new MTourContext())
            {
                var tours = context.Tours.ToList();
                dgvTourList.DataSource = tours;
            }
        }
    }
}
