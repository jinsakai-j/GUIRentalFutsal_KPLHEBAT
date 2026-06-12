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
            InisialisasiTabel();
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
            // Bisa dikosongkan karena inisialisasi sudah dilakukan di Constructor
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
            string idInput = Txt_IDLapangan.Text.Trim();
            string namaInput = Txt_NamaLapangan.Text.Trim();
            string hargaInput = Txt_HargaPerJam.Text.Trim();

            // 1. Validasi isi field tidak boleh kosong
            if (string.IsNullOrWhiteSpace(idInput) || string.IsNullOrWhiteSpace(namaInput) || string.IsNullOrWhiteSpace(hargaInput))
            {
                MessageBox.Show("Semua data field harus diisi terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. VALIDASI: ID Lapangan harus berupa angka dan tidak boleh negatif atau nol
            if (!int.TryParse(idInput, out int idValid) || idValid <= 0)
            {
                MessageBox.Show("ID Lapangan harus berupa angka bulat positif (tidak boleh negatif atau nol)!", "Kesalahan Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 3. VALIDASI: Harga/Jam harus berupa angka dan tidak boleh negatif atau nol
            if (!int.TryParse(hargaInput, out int hargaValid) || hargaValid <= 0)
            {
                MessageBox.Show("Harga per Jam harus berupa angka positif (tidak boleh negatif atau nol)!", "Kesalahan Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 4. VALIDASI: Pengecekan duplikasi ID dan Nama Lapangan
            foreach (DataRow row in dataLapangan.Rows)
            {
                if (row["ID"].ToString() == idInput)
                {
                    MessageBox.Show("ID Lapangan sudah terdaftar. Gunakan ID lain!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (row["Nama Lapangan"].ToString().Trim().ToLower() == namaInput.ToLower())
                {
                    MessageBox.Show($"Nama lapangan '{namaInput}' sudah ada! Gunakan nama lapangan yang berbeda.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // 5. Tambah data baru ke tabel
            string status = cmbBox_Status.SelectedItem?.ToString() ?? "Ya";
            dataLapangan.Rows.Add(idInput, namaInput, hargaValid, status);

            MessageBox.Show("Data lapangan berhasil ditambahkan!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            BereskanInput();
        }

        // ==================== [ TOMBOL UPDATE ] ====================
        private void bttn_Update_Click(object sender, EventArgs e)
        {
            string targetID = Txt_IDLapangan.Text.Trim();
            string namaInput = Txt_NamaLapangan.Text.Trim();
            string hargaInput = Txt_HargaPerJam.Text.Trim();

            if (string.IsNullOrWhiteSpace(targetID))
            {
                MessageBox.Show("Silahkan pilih baris pada tabel atau masukkan ID Lapangan terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 1. VALIDASI: ID Lapangan harus berupa angka positif
            if (!int.TryParse(targetID, out int idValid) || idValid <= 0)
            {
                MessageBox.Show("ID Lapangan harus berupa angka bulat positif!", "Kesalahan Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 2. Cari baris data yang memiliki ID tersebut
            DataRow rowTerpilih = null;
            foreach (DataRow row in dataLapangan.Rows)
            {
                if (row["ID"].ToString() == targetID)
                {
                    rowTerpilih = row;
                    break;
                }
            }

            if (rowTerpilih == null)
            {
                MessageBox.Show($"Data dengan ID Lapangan '{targetID}' tidak ditemukan!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. VALIDASI: Cek duplikasi nama dengan ID lain
            if (!string.IsNullOrWhiteSpace(namaInput))
            {
                foreach (DataRow row in dataLapangan.Rows)
                {
                    if (row["ID"].ToString() != targetID && row["Nama Lapangan"].ToString().Trim().ToLower() == namaInput.ToLower())
                    {
                        MessageBox.Show($"Nama lapangan '{namaInput}' sudah digunakan oleh ID Lapangan {row["ID"]}! Gunakan nama lain.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }

            // 4. VALIDASI: Jika Harga/Jam diisi, pastikan nilainya positif dan bukan negatif
            int hargaValid = 0;
            if (!string.IsNullOrWhiteSpace(hargaInput))
            {
                if (!int.TryParse(hargaInput, out hargaValid) || hargaValid <= 0)
                {
                    MessageBox.Show("Harga per Jam harus berupa angka positif (tidak boleh negatif atau nol)!", "Kesalahan Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // 5. Proses Eksekusi Update
            bool adaPerubahan = false;

            if (!string.IsNullOrWhiteSpace(namaInput))
            {
                rowTerpilih["Nama Lapangan"] = namaInput;
                adaPerubahan = true;
            }

            if (!string.IsNullOrWhiteSpace(hargaInput))
            {
                rowTerpilih["Harga/Jam"] = hargaValid;
                adaPerubahan = true;
            }

            if (cmbBox_Status.SelectedItem != null)
            {
                rowTerpilih["Aktif"] = cmbBox_Status.SelectedItem.ToString();
                adaPerubahan = true;
            }

            if (adaPerubahan)
            {
                MessageBox.Show("Data lapangan berhasil diperbarui!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BereskanInput();
            }
            else
            {
                MessageBox.Show("Tidak ada data baru yang diubah.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        // ==================== [ TOMBOL HAPUS ] ====================
        private void bttn_Hapus_Click(object sender, EventArgs e)
        {
            string targetID = Txt_IDLapangan.Text.Trim();
            DataRow rowTerpilih = null;
            int indeksTerpilih = -1;

            // 1. CARA PERTAMA: Cek berdasarkan baris yang sedang diklik/dipilih di tabel UI
            if (GridView_Lapangan.SelectedRows.Count > 0)
            {
                indeksTerpilih = GridView_Lapangan.SelectedRows[0].Index;
                rowTerpilih = dataLapangan.Rows[indeksTerpilih];
            }
            // 2. CARA KEDUA: Jika tidak ada baris yang diklik, cek berdasarkan ID yang diketik di TextBox
            else if (!string.IsNullOrWhiteSpace(targetID))
            {
                for (int i = 0; i < dataLapangan.Rows.Count; i++)
                {
                    if (dataLapangan.Rows[i]["ID"].ToString() == targetID)
                    {
                        rowTerpilih = dataLapangan.Rows[i];
                        indeksTerpilih = i;
                        break;
                    }
                }
            }

            // 3. Validasi jika data tidak ditemukan dari kedua cara di atas
            if (rowTerpilih == null || indeksTerpilih == -1)
            {
                MessageBox.Show("Silahkan pilih baris data pada tabel atau masukkan ID Lapangan valid yang ingin dihapus!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 4. Konfirmasi keamanan sebelum benar-benar menghapus data lapangan
            string namaLapangan = rowTerpilih["Nama Lapangan"].ToString();
            string idLapangan = rowTerpilih["ID"].ToString();

            DialogResult konfirmasi = MessageBox.Show(
                $"Apakah Anda yakin ingin menghapus data lapangan berikut?\n\nID: {idLapangan}\nNama: {namaLapangan}",
                "Konfirmasi Hapus",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (konfirmasi == DialogResult.Yes)
            {
                // Menghapus data dari DataTable penampung memori
                dataLapangan.Rows.RemoveAt(indeksTerpilih);

                MessageBox.Show("Data lapangan berhasil dihapus!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Membersihkan TextBox input dan mengembalikan kondisi form
                BereskanInput();
            }
        }
        // ==================== [ TOMBOL RESET ] ====================
        private void bttn_Reset_Click(object sender, EventArgs e)
        {
            BereskanInput();
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
            // Mengamankan agar klik bukan pada bagian header kolom
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = GridView_Lapangan.Rows[e.RowIndex];

                // Memindahkan data dari grid kembali ke text box berdasarkan urutan kolom (0, 1, 2, 3)
                Txt_IDLapangan.Text = row.Cells[0].Value?.ToString() ?? "";
                Txt_NamaLapangan.Text = row.Cells[1].Value?.ToString() ?? "";
                Txt_HargaPerJam.Text = row.Cells[2].Value?.ToString() ?? "";

                string statusAktif = row.Cells[3].Value?.ToString() ?? "Ya";
                cmbBox_Status.SelectedItem = statusAktif;

                // KUNCI: Kunci TextBox ID Lapangan agar tidak bisa diubah manual saat proses update
                Txt_IDLapangan.ReadOnly = true;
            }
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