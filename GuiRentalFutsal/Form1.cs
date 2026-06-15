using System;
using System.Windows.Forms;
using GuiRentalFutsal.Models;

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
            // Membuat instance dari FieldForm
            FieldForm formField = new FieldForm();

            // Sembunyikan Form1 (Menu Utama) sementara
            this.Hide();

            // Buka FieldForm secara modal
            formField.ShowDialog();

            // Setelah FieldForm ditutup melalui tombol kembali, Form1 muncul lagi
            this.Show();
        }

        private void btnBooking_Click(object sender, EventArgs e)
        {
            // Membuat instance dari BookingForm
            BookingForm formBooking = new BookingForm();

            // Sembunyikan Form1 (Menu Utama) sementara
            this.Hide();

            // Buka form booking secara modal (harus ditutup dulu baru kode di bawahnya berjalan)
            formBooking.ShowDialog();

            // Setelah BookingForm ditutup (karena tombol kembali di-klik), Form1 muncul lagi
            this.Show();
        }

        private void btnSchedule_Click(object sender, EventArgs e)
        {
            ScheduleForm scheduleForm = new ScheduleForm();

            // Dashboard disembunyikan sementara
            this.Hide();

            // Membuka form cek jadwal
            scheduleForm.ShowDialog();

            // Setelah ScheduleForm ditutup, dashboard muncul lagi
            this.Show();
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (PaymentForm PaymentForm = new PaymentForm())
            {
                PaymentForm.ShowDialog();
            }

            this.Show();

        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            this.Hide();

            using (ReportForm reportForm = new ReportForm())
            {
                reportForm.ShowDialog();
            }

            this.Show();

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}