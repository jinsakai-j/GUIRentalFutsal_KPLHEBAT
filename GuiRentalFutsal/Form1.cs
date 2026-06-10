namespace GuiRentalFutsal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnField_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Form Kelola Lapangan belum dibuat.");
        }

        private void btnBooking_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Form Booking belum dibuat.");
        }

        private void btnSchedule_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Form Cek Jadwal belum dibuat.");
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Form Pembayaran belum dibuat.");
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Form Laporan belum dibuat.");

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }
    }
}
