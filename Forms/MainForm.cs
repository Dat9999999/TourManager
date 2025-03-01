using TourManagerment.Forms;

namespace TourManagerment
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void btnShowTourForm_Click(object sender, EventArgs e)
        {
            TourForm tourForm = new TourForm();
            tourForm.ShowDialog();
        }
    }
}
