namespace GuiRentalFutsal
{
    public partial class DashboardForm : Form
    {
        public DashboardForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnField_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (FieldForm form = new FieldForm())
            {
                form.ShowDialog();
            }
            this.Show();
        }

        private void btnBooking_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (BookingForm form = new BookingForm())
            {
                form.ShowDialog();
            }
            this.Show();
        }

        private void btnSchedule_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (ScheduleForm form = new ScheduleForm())
            {
                form.ShowDialog();
            }
            this.Show();
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (PaymentForm form = new PaymentForm())
            {
                form.ShowDialog();
            }
            this.Show();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            this.Hide();

            using (ReportForm form = new ReportForm())
            {
                form.ShowDialog();
            }
            this.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
