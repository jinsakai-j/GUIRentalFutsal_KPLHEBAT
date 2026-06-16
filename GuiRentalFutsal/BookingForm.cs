using System.Globalization;
using GuiRentalFutsal.Models;

namespace GuiRentalFutsal
{
    public partial class BookingForm : Form
    {
        private readonly CultureInfo rupiahCulture = new("id-ID");

        public BookingForm()
        {
            InitializeComponent();
            SetupBookingGrid();
            SetupTimeComboBoxes();
        }

        private void SetupTimeComboBoxes()
        {
            cmbJamMulai.Items.Clear();
            for (int hour = 8; hour <= 22; hour++)
            {
                cmbJamMulai.Items.Add($"{hour:00}:00");
            }

            cmbDurasi.Items.Clear();
            for (int duration = 1; duration <= 6; duration++)
            {
                cmbDurasi.Items.Add($"{duration} Jam");
            }
            cmbDurasi.Items.Add("Full Day");

            cmbJamMulai.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDurasi.DropDownStyle = ComboBoxStyle.DropDownList;

            if (cmbJamMulai.Items.Count > 0)
            {
                cmbJamMulai.SelectedIndex = 0;
            }

            if (cmbDurasi.Items.Count > 0)
            {
                cmbDurasi.SelectedIndex = 0;
            }
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
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;
        }

        private void BookingForm_Load(object sender, EventArgs e)
        {
            pilihTanggal.MinDate = DateTime.Today;
            pilihTanggal.Value = DateTime.Today;

            lHarga.Text = FormatRupiah(0);
            lStatus.Text = "Tersedia";

            LoadFieldsToComboBox();
            LoadBookings();
        }

        private void buatBooking_Click(object sender, EventArgs e)
        {
            if (!TryGetBookingInput(out int fieldId, out DateOnly bookingDate, out TimeOnly startTime, out int durationHours))
            {
                return;
            }

            var result = AppServices.BookingService.CreateBooking(
                fieldId,
                tNama.Text.Trim(),
                tNoHp.Text.Trim(),
                bookingDate,
                startTime,
                durationHours);

            MessageBox.Show(result.Message);

            if (result.Success && result.Data is not null)
            {
                lHarga.Text = FormatRupiah(result.Data.TotalPrice);
                lStatus.Text = result.Data.Status.ToString();
                LoadBookings();
                BersihkanForm();
            }
        }

        private void cekJadwal_Click(object sender, EventArgs e)
        {
            if (!TryGetScheduleInput(out int fieldId, out DateOnly bookingDate, out TimeOnly startTime, out int durationHours))
            {
                return;
            }

            Field? field = AppServices.FieldService.GetById(fieldId);
            if (field is null)
            {
                MessageBox.Show("Data lapangan tidak ditemukan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lHarga.Text = FormatRupiah(field.PricePerHour * durationHours);

            var result = AppServices.ScheduleService.IsAvailable(fieldId, bookingDate, startTime, durationHours);
            lStatus.Text = result.Success && result.Data ? "Tersedia" : "Penuh";
            MessageBox.Show(result.Message);
        }

        private void reset_Click(object sender, EventArgs e)
        {
            BersihkanForm();
            LoadFieldsToComboBox();
            LoadBookings();
        }

        private bool TryGetBookingInput(out int fieldId, out DateOnly bookingDate, out TimeOnly startTime, out int durationHours)
        {
            fieldId = 0;
            bookingDate = default;
            startTime = default;
            durationHours = 0;

            if (string.IsNullOrWhiteSpace(tNama.Text))
            {
                MessageBox.Show("Nama tidak boleh kosong.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(tNoHp.Text))
            {
                MessageBox.Show("Nomor HP tidak boleh kosong.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return TryGetScheduleInput(out fieldId, out bookingDate, out startTime, out durationHours);
        }

        private bool TryGetScheduleInput(out int fieldId, out DateOnly bookingDate, out TimeOnly startTime, out int durationHours)
        {
            fieldId = 0;
            bookingDate = DateOnly.FromDateTime(pilihTanggal.Value.Date);
            startTime = default;
            durationHours = 0;

            if (cmbLapangan.SelectedValue is not int selectedFieldId)
            {
                MessageBox.Show("Lapangan wajib dipilih.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cmbJamMulai.SelectedItem is null)
            {
                MessageBox.Show("Jam mulai wajib dipilih.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cmbDurasi.SelectedItem is null)
            {
                MessageBox.Show("Durasi wajib dipilih.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!TimeOnly.TryParse(cmbJamMulai.Text, out startTime))
            {
                MessageBox.Show("Format jam tidak valid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            durationHours = GetSelectedDurationHours();
            if (durationHours <= 0)
            {
                MessageBox.Show("Durasi tidak valid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!IsWithinOperatingHours(startTime, durationHours))
            {
                lStatus.Text = "Penuh";
                MessageBox.Show("Booking tidak boleh melewati jam operasional 08:00 - 23:00.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            fieldId = selectedFieldId;
            return true;
        }

        private int GetSelectedDurationHours()
        {
            string selectedDuration = cmbDurasi.Text.Trim();

            if (selectedDuration.Equals("Full Day", StringComparison.OrdinalIgnoreCase))
            {
                return 15;
            }

            string numberOnly = selectedDuration.Replace("Jam", string.Empty).Trim();
            return int.TryParse(numberOnly, out int durationHours) ? durationHours : 0;
        }

        private static bool IsWithinOperatingHours(TimeOnly startTime, int durationHours)
        {
            TimeSpan start = startTime.ToTimeSpan();
            TimeSpan end = start.Add(TimeSpan.FromHours(durationHours));
            return start >= TimeSpan.FromHours(8) && start <= TimeSpan.FromHours(22) && end <= TimeSpan.FromHours(23);
        }

        private void BersihkanForm()
        {
            tNama.Clear();
            tNoHp.Clear();

            if (cmbLapangan.DataSource != null && cmbLapangan.Items.Count > 0)
            {
                cmbLapangan.SelectedIndex = 0;
            }

            if (cmbJamMulai.Items.Count > 0)
            {
                cmbJamMulai.SelectedIndex = 0;
            }

            if (cmbDurasi.Items.Count > 0)
            {
                cmbDurasi.SelectedIndex = 0;
            }

            cmbJamMulai.Enabled = true;
            pilihTanggal.Value = DateTime.Today;
            lHarga.Text = FormatRupiah(0);
            lStatus.Text = "Tersedia";
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
                    Total = FormatRupiah(b.TotalPrice),
                    Status = b.Status.ToString()
                })
                .ToList();

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = bookings;
        }

        private string FormatRupiah(decimal amount)
        {
            return amount.ToString("C0", rupiahCulture);
        }

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
        }

        private void btnRefreshFields_Click(object sender, EventArgs e)
        {
            LoadFieldsToComboBox();
            LoadBookings();
        }

        private void cmbDurasi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDurasi.Text.Equals("Full Day", StringComparison.OrdinalIgnoreCase))
            {
                cmbJamMulai.SelectedItem = "08:00";
                cmbJamMulai.Enabled = false;
            }
            else
            {
                cmbJamMulai.Enabled = true;
            }
        }
    }
}
