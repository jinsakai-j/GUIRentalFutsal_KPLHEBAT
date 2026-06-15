using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuiRentalFutsal
{
    public partial class PaymentForm : Form
    {
        public PaymentForm()
        {
            InitializeComponent();
        }

        private void JumlahBayarBtn_TextChanged(object sender, EventArgs e)
        {

        }

        private void PaymentForm_Load(object sender, EventArgs e)
        {
            MetodeBayarCmb.Items.Add("Cash");
            MetodeBayarCmb.Items.Add("Transfer Bank");
            MetodeBayarCmb.Items.Add("QRIS");

            MetodeBayarCmb.SelectedIndex = 0;

            RiwayatPembayaranDgv.ColumnCount = 7;

            RiwayatPembayaranDgv.Columns[0].Name = "ID Booking";
            RiwayatPembayaranDgv.Columns[1].Name = "Nama Pemesan";
            RiwayatPembayaranDgv.Columns[2].Name = "Total Tagihan";
            RiwayatPembayaranDgv.Columns[3].Name = "Jumlah Bayar";
            RiwayatPembayaranDgv.Columns[4].Name = "Metode Bayar";
            RiwayatPembayaranDgv.Columns[5].Name = "Tanggal";
            RiwayatPembayaranDgv.Columns[6].Name = "Status";
        }

        private void CariBtn_Click(object sender, EventArgs e)
        {
            if (IdBookingTxt.Text == "BK001")
            {
                NamaPemesanTxt.Text = "Muhammad Fitrah";
                LapanganTxt.Text = "Lapangan A";
                TanggalJamTxt.Text = "15/06/2026 19:00";
                TotalTagihanTxt.Text = "150000";
                StatusBookingTxt.Text = "Belum Lunas";
            }
            else
            {
                MessageBox.Show("Booking tidak ditemukan!");
            }
        }

        private void KonfirmasiPembayaranBtn_Click(object sender, EventArgs e)
        {
            decimal totalTagihan;
            decimal jumlahBayar;

            if (!decimal.TryParse(TotalTagihanTxt.Text, out totalTagihan))
            {
                MessageBox.Show("Total tagihan tidak valid!");
                return;
            }

            if (!decimal.TryParse(JumlahBayarTxt.Text, out jumlahBayar))
            {
                MessageBox.Show("Jumlah bayar tidak valid!");
                return;
            }

            if (jumlahBayar < totalTagihan)
            {
                MessageBox.Show("Jumlah pembayaran kurang!");
                return;
            }

            StatusBookingTxt.Text = "Lunas";

            RiwayatPembayaranDgv.Rows.Add(
                IdBookingTxt.Text,
                NamaPemesanTxt.Text,
                TotalTagihanTxt.Text,
                JumlahBayarTxt.Text,
                MetodeBayarCmb.Text,
                DateTime.Now.ToString("dd/MM/yyyy HH:mm"),
                "Lunas"
            );

            MessageBox.Show("Pembayaran berhasil!");
        }

        private void BatalPembayaranBtn_Click(object sender, EventArgs e)
        {
            DialogResult hasil = MessageBox.Show(
               "Yakin ingin membatalkan pembayaran?",
               "Konfirmasi",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question);

            if (hasil == DialogResult.Yes)
            {
                StatusBookingTxt.Text = "Dibatalkan";

                RiwayatPembayaranDgv.Rows.Add(
                    IdBookingTxt.Text,
                    NamaPemesanTxt.Text,
                    TotalTagihanTxt.Text,
                    "-",
                    "-",
                    DateTime.Now.ToString("dd/MM/yyyy HH:mm"),
                    "Dibatalkan"
                );

                MessageBox.Show("Pembayaran dibatalkan.");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
