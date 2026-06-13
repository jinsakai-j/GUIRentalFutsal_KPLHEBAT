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
    public partial class FieldForm : Form
    {
        // Mendefinisikan DataTable untuk menampung data lapangan secara sementara
        private DataTable dataLapangan;

        public FieldForm()
        {
            InitializeComponent();
            SetupGrid();
        }

        private void SetupGrid()
        {
            GridView_Lapangan.AutoGenerateColumns = false;

            if (GridView_Lapangan.Columns.Count >= 4)
            {
                GridView_Lapangan.Columns[0].DataPropertyName = "Id";
                GridView_Lapangan.Columns[1].DataPropertyName = "Name";
                GridView_Lapangan.Columns[2].DataPropertyName = "PricePerHour";
                GridView_Lapangan.Columns[3].DataPropertyName = "IsActive";
            }

            GridView_Lapangan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            GridView_Lapangan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            GridView_Lapangan.MultiSelect = false;
            GridView_Lapangan.AllowUserToAddRows = false;
            GridView_Lapangan.ReadOnly = true;

            cmbBox_Status.Items.Clear();
            cmbBox_Status.Items.Add("Ya");
            cmbBox_Status.Items.Add("Tidak");
            cmbBox_Status.SelectedIndex = 0;
        }

        private void LoadFields()
        {
            var fields = AppServices.FieldService.GetAllFields();

            GridView_Lapangan.DataSource = null;
            GridView_Lapangan.DataSource = fields;
        }

        // Fungsi untuk mengatur kolom tabel dan pilihan ComboBox Status saat form pertama kali dimuat
        private void InisialisasiTabel()
        {
            // 1. Setup Data Memori (DataTable)
            dataLapangan = new DataTable();
            dataLapangan.Columns.Add("ID", typeof(string));
            dataLapangan.Columns.Add("Nama Lapangan", typeof(string));
            dataLapangan.Columns.Add("Harga/Jam", typeof(int));
            dataLapangan.Columns.Add("Aktif", typeof(string));

            // --- KUNCI PERBAIKAN ---
            // Matikan auto-generate agar GridView menggunakan kolom dari Designer Anda, bukan membuat baru
            GridView_Lapangan.AutoGenerateColumns = false;

            // Petakan DataPropertyName kolom Designer ke kolom DataTable
            GridView_Lapangan.Columns[0].DataPropertyName = "ID";
            GridView_Lapangan.Columns[1].DataPropertyName = "Nama Lapangan";
            GridView_Lapangan.Columns[2].DataPropertyName = "Harga/Jam";
            GridView_Lapangan.Columns[3].DataPropertyName = "Aktif";
            // -----------------------

            // Hubungkan DataTable ke DataGridView Anda
            GridView_Lapangan.DataSource = dataLapangan;

            // Atur properti grid agar rapi
            GridView_Lapangan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            GridView_Lapangan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            GridView_Lapangan.MultiSelect = false;
            GridView_Lapangan.AllowUserToAddRows = false;

            // 2. Setup Pilihan ComboBox Status
            cmbBox_Status.Items.Clear();
            cmbBox_Status.Items.Add("Ya");
            cmbBox_Status.Items.Add("Tidak");
            cmbBox_Status.SelectedIndex = 0;
        }

        private void FieldForm_Load(object sender, EventArgs e)
        {
            LoadFields();
        }

        private void Txt_IDLapangan_TextChanged(object sender, EventArgs e)
        {
        }

        private void Txt_NamaLapangan_TextChanged(object sender, EventArgs e)
        {
        }

        private void Txt_HargaPerJam_TextChanged(object sender, EventArgs e)
        {
        }

        private void cmbBox_Status_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        // ==================== [ TOMBOL TAMBAH ] ====================
        private void bttn_Tambah_Click(object sender, EventArgs e)
        {
            string namaInput = Txt_NamaLapangan.Text.Trim();
            string hargaInput = Txt_HargaPerJam.Text.Trim();

            if (string.IsNullOrWhiteSpace(namaInput) || string.IsNullOrWhiteSpace(hargaInput))
            {
                MessageBox.Show("Nama lapangan dan harga per jam wajib diisi.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(hargaInput, out decimal harga) || harga <= 0)
            {
                MessageBox.Show("Harga per jam harus berupa angka positif.", "Kesalahan Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var result = AppServices.FieldService.AddField(namaInput, harga);

            MessageBox.Show(result.Message);

            if (result.Success)
            {
                LoadFields();
                BereskanInput();
            }
        }

        // ==================== [ TOMBOL UPDATE ] ====================
        private void bttn_Update_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(Txt_IDLapangan.Text.Trim(), out int id) || id <= 0)
            {
                MessageBox.Show("Pilih data lapangan yang ingin diperbarui.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string namaInput = Txt_NamaLapangan.Text.Trim();
            string hargaInput = Txt_HargaPerJam.Text.Trim();

            if (string.IsNullOrWhiteSpace(namaInput) || string.IsNullOrWhiteSpace(hargaInput))
            {
                MessageBox.Show("Nama lapangan dan harga per jam wajib diisi.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(hargaInput, out decimal harga) || harga <= 0)
            {
                MessageBox.Show("Harga per jam harus berupa angka positif.", "Kesalahan Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool isActive = cmbBox_Status.SelectedItem?.ToString() == "Ya";

            var result = AppServices.FieldService.UpdateField(id, namaInput, harga, isActive);

            MessageBox.Show(result.Message);

            if (result.Success)
            {
                LoadFields();
                BereskanInput();
            }
        }
        // ==================== [ TOMBOL HAPUS ] ====================
        private void bttn_Hapus_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(Txt_IDLapangan.Text.Trim(), out int id) || id <= 0)
            {
                MessageBox.Show("Pilih data lapangan yang ingin dihapus.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                "Apakah Anda yakin ingin menghapus lapangan ini?",
                "Konfirmasi Hapus",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm != DialogResult.Yes)
            {
                return;
            }

            var result = AppServices.FieldService.DeleteField(id);

            MessageBox.Show(result.Message);

            if (result.Success)
            {
                LoadFields();
                BereskanInput();
            }
        }
        // ==================== [ TOMBOL RESET ] ====================
        private void bttn_Reset_Click(object sender, EventArgs e)
        {
            BereskanInput();
            LoadFields();
        }

        // Fungsi pembantu untuk mengosongkan semua field input text box
        // ==================== [ FUNGSI RESET / BERESKAN INPUT ] ====================
        private void BereskanInput()
        {
            // Mengosongkan field teks input agar siap untuk input data baru
            Txt_IDLapangan.Clear();
            Txt_NamaLapangan.Clear();
            Txt_HargaPerJam.Clear();

            // Kembalikan status read-only ke false agar ID bisa diketik lagi jika ingin TAMBAH data baru
            Txt_IDLapangan.ReadOnly = false;

            if (cmbBox_Status.Items.Count > 0)
            {
                cmbBox_Status.SelectedIndex = 0;
            }
            GridView_Lapangan.ClearSelection();
        }
        // ==================== [ EVENT KLIK BARIS TABEL ] ====================
        private void GridView_Lapangan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow row = GridView_Lapangan.Rows[e.RowIndex];

            Txt_IDLapangan.Text = row.Cells[0].Value?.ToString() ?? "";
            Txt_NamaLapangan.Text = row.Cells[1].Value?.ToString() ?? "";
            Txt_HargaPerJam.Text = row.Cells[2].Value?.ToString() ?? "";

            bool isActive = row.Cells[3].Value is bool value && value;
            cmbBox_Status.SelectedItem = isActive ? "Ya" : "Tidak";

            Txt_IDLapangan.ReadOnly = true;
        }

        // ==================== [ TOMBOL KEMBALI ] ====================
        private void bttn_Kembali_Click(object sender, EventArgs e)
        {
            // Menutup Form ini, otomatis memicu Form1 (Menu Utama) muncul kembali 
            // karena Form1 menggunakan mekanisme 'ShowDialog()'
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}