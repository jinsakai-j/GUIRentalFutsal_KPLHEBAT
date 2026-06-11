using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GuiRentalFutsal
{
    public partial class ScheduleForm : Form
    {
        private bool isLoading = true;

        private readonly TimeSpan openingTime = new TimeSpan(8, 0, 0);
        private readonly TimeSpan closingTime = new TimeSpan(23, 0, 0);

        private List<BookingSchedule> scheduleList = new List<BookingSchedule>();

        public ScheduleForm()
        {
            InitializeComponent();

            SetupDataGridView();
            SetupDummyData();
            SetupComboBox();

            isLoading = false;
            ShowScheduleData();
        }

        private class BookingSchedule
        {
            public int Id { get; set; }
            public string Lapangan { get; set; }
            public DateTime Tanggal { get; set; }
            public TimeSpan JamMulai { get; set; }
            public TimeSpan JamSelesai { get; set; }
            public string Status { get; set; }
        }

        private void SetupComboBox()
        {
            cmbField.Items.Clear();
            cmbField.Items.Add("Lapangan A Vinyl");
            cmbField.Items.Add("Lapangan B Sintetis");
            cmbField.Items.Add("Lapangan C Rumput");

            cmbStartTime.Items.Clear();
            for (int i = 8; i <= 22; i++)
            {
                cmbStartTime.Items.Add(i.ToString("00") + ":00");
            }

            cmbDuration.Items.Clear();
            for (int i = 1; i <= 6; i++)
            {
                cmbDuration.Items.Add(i + " Jam");
            }

            cmbDuration.Items.Add("Full Day");

            cmbField.SelectedIndex = 0;
            cmbStartTime.SelectedIndex = 10; // 18:00
            cmbDuration.SelectedIndex = 1;  // 2 Jam

            cmbField.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStartTime.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDuration.DropDownStyle = ComboBoxStyle.DropDownList;

            dtpScheduleDate.Format = DateTimePickerFormat.Custom;
            dtpScheduleDate.CustomFormat = "dd/MM/yyyy";

            // Tidak bisa memilih tanggal sebelum hari ini
            dtpScheduleDate.MinDate = DateTime.Today;
            dtpScheduleDate.Value = DateTime.Today;

            lblAvailabilityResult.Text = "Silakan cek ketersediaan jadwal.";
            lblAvailabilityResult.BackColor = Color.White;
        }

        private void SetupDummyData()
        {
            scheduleList.Add(new BookingSchedule
            {
                Id = 1,
                Lapangan = "Lapangan A Vinyl",
                Tanggal = DateTime.Today,
                JamMulai = new TimeSpan(18, 0, 0),
                JamSelesai = new TimeSpan(20, 0, 0),
                Status = "Paid"
            });

            scheduleList.Add(new BookingSchedule
            {
                Id = 2,
                Lapangan = "Lapangan A Vinyl",
                Tanggal = DateTime.Today,
                JamMulai = new TimeSpan(20, 0, 0),
                JamSelesai = new TimeSpan(21, 0, 0),
                Status = "Pending"
            });

            scheduleList.Add(new BookingSchedule
            {
                Id = 3,
                Lapangan = "Lapangan B Sintetis",
                Tanggal = DateTime.Today,
                JamMulai = new TimeSpan(10, 0, 0),
                JamSelesai = new TimeSpan(12, 0, 0),
                Status = "Paid"
            });
        }

        private void SetupDataGridView()
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
                Name = "colField",
                HeaderText = "Lapangan",
                DataPropertyName = "Lapangan"
            });

            dgvSchedule.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colStartTime",
                HeaderText = "Jam Mulai",
                DataPropertyName = "JamMulai"
            });

            dgvSchedule.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colEndTime",
                HeaderText = "Jam Selesai",
                DataPropertyName = "JamSelesai"
            });

            dgvSchedule.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colStatus",
                HeaderText = "Status",
                DataPropertyName = "Status"
            });

            dgvSchedule.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSchedule.AllowUserToAddRows = false;
            dgvSchedule.ReadOnly = true;
            dgvSchedule.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void ShowScheduleData()
        {
            if (cmbField.SelectedItem == null)
            {
                return;
            }

            string selectedField = cmbField.SelectedItem.ToString();
            DateTime selectedDate = dtpScheduleDate.Value.Date;

            var data = scheduleList
                .Where(s => s.Lapangan == selectedField && s.Tanggal.Date == selectedDate)
                .Select(s => new
                {
                    s.Id,
                    s.Lapangan,
                    JamMulai = s.JamMulai.ToString(@"hh\:mm"),
                    JamSelesai = s.JamSelesai.ToString(@"hh\:mm"),
                    s.Status
                })
                .ToList();

            dgvSchedule.DataSource = data;
        }

        private void cmbField_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isLoading)
            {
                ShowScheduleData();
            }
        }

        private void dtpScheduleDate_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoading)
            {
                ShowScheduleData();
            }
        }

        private void cmbStartTime_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbDuration_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDuration.SelectedItem == null)
            {
                return;
            }

            if (cmbDuration.SelectedItem.ToString() == "Full Day")
            {
                cmbStartTime.SelectedItem = "08:00";
                cmbStartTime.Enabled = false;
            }
            else
            {
                cmbStartTime.Enabled = true;
            }
        }

        private void btnCheckAvailability_Click(object sender, EventArgs e)
        {
            if (cmbField.SelectedItem == null || cmbStartTime.SelectedItem == null || cmbDuration.SelectedItem == null)
            {
                MessageBox.Show("Lengkapi data terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedField = cmbField.SelectedItem.ToString();
            DateTime selectedDate = dtpScheduleDate.Value.Date;

            if (selectedDate < DateTime.Today)
            {
                lblAvailabilityResult.Text = "Tanggal tidak valid. Tidak bisa mengecek jadwal yang sudah lewat.";
                lblAvailabilityResult.BackColor = Color.LightCoral;
                return;
            }

            TimeSpan startTime;
            TimeSpan endTime;

            string durationText = cmbDuration.SelectedItem.ToString();

            if (durationText == "Full Day")
            {
                startTime = openingTime; // 08:00
                endTime = closingTime;   // 23:00
            }
            else
            {
                startTime = TimeSpan.Parse(cmbStartTime.SelectedItem.ToString());

                int duration = int.Parse(durationText.Split(' ')[0]);
                endTime = startTime.Add(TimeSpan.FromHours(duration));
            }

            if (endTime > closingTime)
            {
                lblAvailabilityResult.Text = "Jadwal tidak valid. Jam selesai melebihi jam operasional.";
                lblAvailabilityResult.BackColor = Color.LightCoral;
                return;
            }

            bool isConflict = scheduleList.Any(s =>
                s.Lapangan == selectedField &&
                s.Tanggal.Date == selectedDate &&
                startTime < s.JamSelesai &&
                endTime > s.JamMulai
            );

            if (isConflict)
            {
                lblAvailabilityResult.Text = "Jadwal tidak tersedia. Silakan pilih jam lain.";
                lblAvailabilityResult.BackColor = Color.LightCoral;
            }
            else
            {
                lblAvailabilityResult.Text = "Jadwal tersedia. Booking dapat dibuat.";
                lblAvailabilityResult.BackColor = Color.LightGreen;
            }

            ShowScheduleData();
        }

        private void lblAvailabilityResult_Click(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Kembali ke dashboard utama.",
                "Informasi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            this.Close();
        }

        private void dgvSchedule_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}