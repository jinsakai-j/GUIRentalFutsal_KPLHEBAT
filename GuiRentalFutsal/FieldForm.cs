using GuiRentalFutsal.Models;

namespace GuiRentalFutsal
{
    public partial class FieldForm : Form
    {
        public FieldForm()
        {
            InitializeComponent();
            SetupGrid();
            GridView_Lapangan.CellClick += GridView_Lapangan_CellContentClick;
        }

        private void SetupGrid()
        {
            GridView_Lapangan.AutoGenerateColumns = false;

            if (GridView_Lapangan.Columns.Count >= 4)
            {
                GridView_Lapangan.Columns[0].DataPropertyName = nameof(Field.Id);
                GridView_Lapangan.Columns[1].DataPropertyName = nameof(Field.Name);
                GridView_Lapangan.Columns[2].DataPropertyName = nameof(Field.PricePerHour);
                GridView_Lapangan.Columns[3].DataPropertyName = nameof(Field.IsActive);
            }

            GridView_Lapangan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            GridView_Lapangan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            GridView_Lapangan.MultiSelect = false;
            GridView_Lapangan.AllowUserToAddRows = false;
            GridView_Lapangan.AllowUserToDeleteRows = false;
            GridView_Lapangan.ReadOnly = true;

            cmbBox_Status.Items.Clear();
            cmbBox_Status.Items.Add("Ya");
            cmbBox_Status.Items.Add("Tidak");
            cmbBox_Status.SelectedIndex = 0;
            cmbBox_Status.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void LoadFields()
        {
            GridView_Lapangan.DataSource = null;
            GridView_Lapangan.DataSource = AppServices.FieldService.GetAllFields();
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

        private void bttn_Tambah_Click(object sender, EventArgs e)
        {
            string namaInput = Txt_NamaLapangan.Text.Trim();

            if (!TryGetValidFieldInput(namaInput, Txt_HargaPerJam.Text, out decimal harga))
            {
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

        private void bttn_Update_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(Txt_IDLapangan.Text.Trim(), out int id) || id <= 0)
            {
                MessageBox.Show("Pilih data lapangan yang ingin diperbarui.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string namaInput = Txt_NamaLapangan.Text.Trim();

            if (!TryGetValidFieldInput(namaInput, Txt_HargaPerJam.Text, out decimal harga))
            {
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
                MessageBoxIcon.Question);

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

        private void bttn_Reset_Click(object sender, EventArgs e)
        {
            BereskanInput();
            LoadFields();
        }

        private static bool TryGetValidFieldInput(string name, string priceText, out decimal price)
        {
            price = 0;

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(priceText))
            {
                MessageBox.Show("Nama lapangan dan harga per jam wajib diisi.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!decimal.TryParse(priceText.Trim(), out price) || price <= 0)
            {
                MessageBox.Show("Harga per jam harus berupa angka positif.", "Kesalahan Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void BereskanInput()
        {
            Txt_IDLapangan.Clear();
            Txt_NamaLapangan.Clear();
            Txt_HargaPerJam.Clear();
            Txt_IDLapangan.ReadOnly = false;

            if (cmbBox_Status.Items.Count > 0)
            {
                cmbBox_Status.SelectedIndex = 0;
            }

            GridView_Lapangan.ClearSelection();
        }

        private void GridView_Lapangan_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || GridView_Lapangan.Rows[e.RowIndex].DataBoundItem is not Field field)
            {
                return;
            }

            Txt_IDLapangan.Text = field.Id.ToString();
            Txt_NamaLapangan.Text = field.Name;
            Txt_HargaPerJam.Text = field.PricePerHour.ToString("0");
            cmbBox_Status.SelectedItem = field.IsActive ? "Ya" : "Tidak";
            Txt_IDLapangan.ReadOnly = true;
        }

        private void bttn_Kembali_Click(object sender, EventArgs e)
        {
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
