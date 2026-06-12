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
    public partial class BookingForm : Form
    {
        // Membuat tabel virtual di memori untuk menyimpan data sementara
        DataTable tableData = new DataTable();
        int idCounter = 1;
        const int HARGA_PER_JAM = 100000; // Anda bisa mengubah konstanta harga ini

        public BookingForm()
        {
            InitializeComponent();
        }

        private void BookingForm_Load(object sender, EventArgs e)
        {
            // Setup kolom tabel saat form pertama kali dimuat
            tableData.Columns.Add("Id", typeof(int));
            tableData.Columns.Add("Pemesan", typeof(string));
            tableData.Columns.Add("Lapangan", typeof(string));
            tableData.Columns.Add("Jam", typeof(string));
            tableData.Columns.Add("Total", typeof(int));
            tableData.Columns.Add("status", typeof(string));

            // Bersihkan kolom dari UI Designer agar tidak muncul dua kali
            dataGridView1.Columns.Clear();

            // Hubungkan DataGridView dengan DataTable
            dataGridView1.DataSource = tableData;

            // Set nilai default label
            lHarga.Text = "0";
            lStatus.Text = "Tersedia";

            LoadFieldsToComboBox();
        }

        private void buatBooking_Click(object sender, EventArgs e)
        {
            // 1. Validasi Input agar tidak ada data yang kosong (Ganti tLapangan dengan cmbLapangan)
            if (string.IsNullOrWhiteSpace(tNama.Text) ||
                cmbLapangan.SelectedItem == null ||
                string.IsNullOrWhiteSpace(tJam.Text) ||
                string.IsNullOrWhiteSpace(tDurasi.Text))
            {
                MessageBox.Show("Mohon lengkapi semua data form!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Validasi angka pada durasi
            if (!int.TryParse(tDurasi.Text, out int durasi))
            {
                MessageBox.Show("Durasi harus berupa angka!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 3. Kalkulasi Harga
            int totalHarga = durasi * HARGA_PER_JAM;
            lHarga.Text = "Rp " + totalHarga.ToString("N0");
            lStatus.Text = "Booked";

            // Format tanggal dan jam
            string jamBooking = pilihTanggal.Value.ToString("dd/MM/yyyy") + " - " + tJam.Text;

            // Ambil teks dari ComboBox
            string lapanganTerpilih = cmbLapangan.Text;
            // 4. Masukkan data ke DataGridView melalui DataTable
            tableData.Rows.Add(idCounter, tNama.Text, lapanganTerpilih, jamBooking, totalHarga, lStatus.Text);
            idCounter++;

            MessageBox.Show("Booking berhasil dibuat!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // 5. Bersihkan form untuk input selanjutnya
            BersihkanForm();
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

        private void btnRefreshFields_Click(object sender, EventArgs e)
        {
            LoadFieldsToComboBox();
        }
    }
}