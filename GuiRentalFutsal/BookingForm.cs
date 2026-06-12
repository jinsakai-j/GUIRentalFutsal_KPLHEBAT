using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GuiRentalFutsal.Models;

namespace GuiRentalFutsal
{
    public partial class BookingForm : Form
    {
        // Membuat tabel virtual di memori untuk menyimpan data sementara
        DataTable tableData = new DataTable();
        int idCounter = 1;
        const int HARGA_PER_JAM = 100000; // Anda bisa mengubah konstanta harga ini

        public BookingForm()
        {
            InitializeComponent();
            SetupBookingGrid();
        }

        private void SetupBookingGrid()
        {
            dataGridView1.AutoGenerateColumns = false;

            dataGridView1.Columns["Id"].DataPropertyName = "Id";
            dataGridView1.Columns["gPemesan"].DataPropertyName = "Pemesan";
            dataGridView1.Columns["gNoHp"].DataPropertyName = "NoHp";
            dataGridView1.Columns["gLapangan"].DataPropertyName = "Lapangan";
            dataGridView1.Columns["gTanggal"].DataPropertyName = "Tanggal";
            dataGridView1.Columns["gJam"].DataPropertyName = "Jam";
            dataGridView1.Columns["gTotal"].DataPropertyName = "Total";
            dataGridView1.Columns["gStatus"].DataPropertyName = "Status";

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ReadOnly = true;
        }

        private void BookingForm_Load(object sender, EventArgs e)
        {

            lHarga.Text = "0";
            lStatus.Text = "Tersedia";

            LoadFieldsToComboBox();
            LoadBookings();
        }

        private void buatBooking_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tNama.Text) ||
         string.IsNullOrWhiteSpace(tNoHp.Text) ||
         cmbLapangan.SelectedValue == null ||
         string.IsNullOrWhiteSpace(tJam.Text) ||
         string.IsNullOrWhiteSpace(tDurasi.Text))
            {
                MessageBox.Show("Mohon lengkapi semua data form!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!TimeOnly.TryParse(tJam.Text.Trim(), out TimeOnly startTime))
            {
                MessageBox.Show("Format jam harus benar. Contoh: 18:00", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(tDurasi.Text.Trim(), out int durationHours) || durationHours <= 0)
            {
                MessageBox.Show("Durasi harus berupa angka positif.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int fieldId = (int)cmbLapangan.SelectedValue;
            DateOnly bookingDate = DateOnly.FromDateTime(pilihTanggal.Value.Date);

            var result = AppServices.BookingService.CreateBooking(
                fieldId,
                tNama.Text.Trim(),
                tNoHp.Text.Trim(),
                bookingDate,
                startTime,
                durationHours
            );

            MessageBox.Show(result.Message);

            if (result.Success && result.Data is not null)
            {
                lHarga.Text = "Rp " + result.Data.TotalPrice.ToString("N0");
                lStatus.Text = result.Data.Status.ToString();

                LoadBookings();
                BersihkanForm();
            }
        }

        private void cekJadwal_Click(object sender, EventArgs e)
        {
            // Ganti tLapangan dengan cmbLapangan
            if (cmbLapangan.SelectedItem == null || string.IsNullOrWhiteSpace(tJam.Text))
            {
                MessageBox.Show("Pilih Lapangan dan isi Jam Mulai terlebih dahulu untuk mengecek jadwal.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Logika pencarian sederhana di memori apakah jadwal sudah ada yang booking
            string jamDicek = pilihTanggal.Value.ToString("dd/MM/yyyy") + " - " + tJam.Text;
            string lapanganTerpilih = cmbLapangan.Text;
            bool isBentrok = false;

            foreach (DataRow row in tableData.Rows)
            {
                // Cek jika lapangan dan waktu sama
                if (row["Lapangan"].ToString() == lapanganTerpilih && row["Jam"].ToString() == jamDicek)
                {
                    isBentrok = true;
                    break;
                }
            }

            if (isBentrok)
            {
                MessageBox.Show("Jadwal sudah terisi! Silakan pilih jam atau lapangan lain.", "Jadwal Penuh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lStatus.Text = "Penuh";
            }
            else
            {
                MessageBox.Show("Jadwal tersedia!", "Tersedia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lStatus.Text = "Tersedia";
            }
        }

        private void reset_Click(object sender, EventArgs e)
        {
            BersihkanForm();
        }

        // Method kustom untuk mereset seluruh input
        private void BersihkanForm()
        {
            tNama.Clear();
            tNoHp.Clear(); // Jika Anda masih memakai textbox ini

            // Reset ComboBox ke pilihan pertama alih-alih di-.Clear()
            if (cmbLapangan.DataSource != null && cmbLapangan.Items.Count > 0)
            {
                cmbLapangan.SelectedIndex = 0;
            }

            tJam.Clear();
            tDurasi.Clear();
            pilihTanggal.Value = DateTime.Now; // Reset kalender ke hari ini
            lHarga.Text = "0";
            lStatus.Text = "Tersedia";
        }

        // Biarkan event default di bawah ini jika tidak ada interaksi khusus saat text berubah
        private void tNama_TextChanged(object sender, EventArgs e) { }
        private void tNoHp_TextChanged(object sender, EventArgs e) { }
        private void pilihTanggal_ValueChanged(object sender, EventArgs e) { }
        private void tJam_TextChanged(object sender, EventArgs e) { }
        private void tDurasi_TextChanged(object sender, EventArgs e) { }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
        private void lHarga_Click(object sender, EventArgs e) { }
        private void lStatus_Click(object sender, EventArgs e) { }

        private void keluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbLapangan_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Event ini otomatis dibuat, biarkan kosong jika belum ada logika khusus saat user mengganti pilihan lapangan
        }

        private void LoadFieldsToComboBox()
        {
            var fields = AppServices.FieldService.GetActiveFields();

            cmbLapangan.DataSource = null;
            cmbLapangan.DisplayMember = "Name";
            cmbLapangan.ValueMember = "Id";
            cmbLapangan.DataSource = fields;
            cmbLapangan.DropDownStyle = ComboBoxStyle.DropDownList;

            if (fields.Count > 0)
            {
                cmbLapangan.SelectedIndex = 0;
            }
        }

        private void LoadBookings()
        {
            var bookings = AppServices.BookingService.GetAllBookings()
        .Select(b => new
        {
            b.Id,
            Pemesan = b.CustomerName,
            NoHp = b.CustomerPhone,
            Lapangan = AppServices.FieldService.GetById(b.FieldId)?.Name ?? $"Lapangan {b.FieldId}",
            Tanggal = b.Date.ToString("dd/MM/yyyy"),
            Jam = $"{b.StartTime:HH:mm}-{b.EndTime:HH:mm}",
            Total = b.TotalPrice,
            Status = b.Status.ToString()
        })
        .ToList();

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = bookings;
        }

        private void btnRefreshFields_Click(object sender, EventArgs e)
        {
            LoadFieldsToComboBox();
        }
    }
}