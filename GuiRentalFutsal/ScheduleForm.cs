using GuiRentalFutsal.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace GuiRentalFutsal
{
    public partial class ScheduleForm : Form
    {
        private bool isLoading;

        public ScheduleForm()
        {
            InitializeComponent();
        }

        private void ScheduleForm_Load(object sender, EventArgs e)
        {
            isLoading = true;

            dtpTanggal.MinDate = DateTime.Today;
            dtpTanggal.Value = DateTime.Today;

            SetupScheduleGrid();
            SetupTimeComboBoxes();
            LoadFieldsToComboBox();

            lblStatus.Text = "-";

            isLoading = false;
            LoadScheduleData();
        }

        private void SetupScheduleGrid()
        {
            dgvSchedule.AutoGenerateColumns = false;
            dgvSchedule.Columns.Clear();

            dgvSchedule.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colId",
                HeaderText = "ID",
                DataPropertyName = "Id"
            });

            dgvSchedule.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colTanggal",
                HeaderText = "Tanggal",
                DataPropertyName = "Tanggal"
            });

            dgvSchedule.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colLapangan",
                HeaderText = "Lapangan",
                DataPropertyName = "Lapangan"
            });

            dgvSchedule.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colJam",
                HeaderText = "Jam",
                DataPropertyName = "Jam"
            });

            dgvSchedule.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colDurasi",
                HeaderText = "Durasi",
                DataPropertyName = "Durasi"
            });

            dgvSchedule.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colStatus",
                HeaderText = "Status",
                DataPropertyName = "Status"
            });

            dgvSchedule.ReadOnly = true;
            dgvSchedule.AllowUserToAddRows = false;
            dgvSchedule.AllowUserToDeleteRows = false;
            dgvSchedule.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSchedule.MultiSelect = false;
            dgvSchedule.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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

        private void LoadFieldsToComboBox()
        {
            var fields = AppServices.FieldService.GetActiveFields();

            cmbLapangan.DataSource = null;
            cmbLapangan.DisplayMember = "Name";
            cmbLapangan.ValueMember = "Id";
            cmbLapangan.DataSource = fields;
            cmbLapangan.DropDownStyle = ComboBoxStyle.DropDownList;

            if (cmbLapangan.Items.Count > 0)
            {
                cmbLapangan.SelectedIndex = 0;
            }
        }

        private void LoadScheduleData()
        {
            DateOnly selectedDate = DateOnly.FromDateTime(dtpTanggal.Value.Date);
            int? selectedFieldId = GetSelectedFieldId();

            var data = AppServices.BookingService.GetAllBookings()
                .Where(b => b.Date == selectedDate)
                .Where(b => b.Status != BookingStatus.Cancelled)
                .Where(b => !selectedFieldId.HasValue || b.FieldId == selectedFieldId.Value)
                .OrderBy(b => b.StartTime)
                .Select(b => new
                {
                    b.Id,
                    Tanggal = b.Date.ToString("dd/MM/yyyy"),
                    Lapangan = AppServices.FieldService.GetById(b.FieldId)?.Name ?? "-",
                    Jam = $"{b.StartTime:HH:mm}-{b.EndTime:HH:mm}",
                    Durasi = $"{b.DurationHours} Jam",
                    Status = b.Status.ToString()
                })
                .ToList();

            dgvSchedule.DataSource = data;
        }

        private int GetSelectedDurationHours()
        {
            if (cmbDurasi.Text.Equals("Full Day", StringComparison.OrdinalIgnoreCase))
            {
                return 15;
            }

            string durationText = cmbDurasi.Text.Trim();
            string numberText = durationText.Split(' ', StringSplitOptions.RemoveEmptyEntries).FirstOrDefault() ?? string.Empty;

            return int.TryParse(numberText, out int durationHours) ? durationHours : 0;
        }

        private int? GetSelectedFieldId()
        {
            if (cmbLapangan.SelectedValue is int fieldId)
            {
                return fieldId;
            }

            if (cmbLapangan.SelectedItem is Field field)
            {
                return field.Id;
            }

            return null;
        }

        private void btnCekJadwal_Click(object sender, EventArgs e)
        {
            int? fieldId = GetSelectedFieldId();
            if (!fieldId.HasValue)
            {
                MessageBox.Show("Pilih lapangan terlebih dahulu.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbJamMulai.SelectedItem == null)
            {
                MessageBox.Show("Pilih jam mulai terlebih dahulu.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int durationHours = GetSelectedDurationHours();
            if (durationHours <= 0)
            {
                MessageBox.Show("Pilih durasi yang valid.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!TimeOnly.TryParse(cmbJamMulai.Text, out TimeOnly startTime))
            {
                MessageBox.Show("Jam mulai tidak valid.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateOnly bookingDate = DateOnly.FromDateTime(dtpTanggal.Value.Date);
            var result = AppServices.ScheduleService.IsAvailable(fieldId.Value, bookingDate, startTime, durationHours);

            lblStatus.Text = result.Success && result.Data ? "Tersedia" : "Penuh";
            MessageBox.Show(result.Message);

            LoadScheduleData();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            isLoading = true;
            LoadFieldsToComboBox();
            isLoading = false;

            LoadScheduleData();
        }

        private void btnKembali_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void cmbLapangan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isLoading)
            {
                LoadScheduleData();
            }
        }

        private void dtpTanggal_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoading)
            {
                LoadScheduleData();
            }
        }
    }
}
