using System.Globalization;
using GuiRentalFutsal.Models;

namespace GuiRentalFutsal
{
    public partial class ReportForm : Form
    {
        private readonly CultureInfo rupiahCulture = new("id-ID");

        public ReportForm()
        {
            InitializeComponent();
            SetupReportGrid();
            Load += ReportForm_Load;
        }

        private void ReportForm_Load(object? sender, EventArgs e)
        {
            InitializePeriod();
            GenerateReport();
        }

        private void InitializePeriod()
        {
            DateTime today = DateTime.Today;
            dtpPeriodeAkhir.MaxDate = today;

            var bookings = AppServices.BookingService.GetAllBookings();
            DateOnly firstBookingDate = bookings.Count > 0
                ? bookings.Min(b => b.Date)
                : DateOnly.FromDateTime(today);

            dtpPeriodeAwal.Value = firstBookingDate.ToDateTime(TimeOnly.MinValue);
            dtpPeriodeAkhir.Value = today;
        }

        private void SetupReportGrid()
        {
            dgvReport.AutoGenerateColumns = false;
            dgvReport.Columns.Clear();

            dgvReport.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colId",
                HeaderText = "ID",
                DataPropertyName = "Id"
            });
            dgvReport.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colTanggal",
                HeaderText = "Tanggal",
                DataPropertyName = "Tanggal"
            });
            dgvReport.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colPemesan",
                HeaderText = "Pemesan",
                DataPropertyName = "Pemesan"
            });
            dgvReport.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colLapangan",
                HeaderText = "Lapangan",
                DataPropertyName = "Lapangan"
            });
            dgvReport.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colJam",
                HeaderText = "Jam",
                DataPropertyName = "Jam"
            });
            dgvReport.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colDurasi",
                HeaderText = "Durasi",
                DataPropertyName = "Durasi"
            });
            dgvReport.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colTotal",
                HeaderText = "Total",
                DataPropertyName = "Total"
            });
            dgvReport.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colStatus",
                HeaderText = "Status",
                DataPropertyName = "Status"
            });

            dgvReport.ReadOnly = true;
            dgvReport.AllowUserToAddRows = false;
            dgvReport.AllowUserToDeleteRows = false;
            dgvReport.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReport.MultiSelect = false;
            dgvReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void GenerateReport()
        {
            DateOnly periodeAwal = DateOnly.FromDateTime(dtpPeriodeAwal.Value.Date);
            DateOnly periodeAkhir = DateOnly.FromDateTime(dtpPeriodeAkhir.Value.Date);

            if (periodeAwal > periodeAkhir)
            {
                MessageBox.Show(
                    "Periode awal tidak boleh lebih besar dari periode akhir.",
                    "Peringatan",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            var bookings = AppServices.BookingService.GetAllBookings()
                .Where(b => b.Date >= periodeAwal && b.Date <= periodeAkhir)
                .ToList();

            lblTotalBooking.Text = bookings.Count.ToString();
            lblBookingPending.Text = bookings.Count(b => b.Status == BookingStatus.PendingPayment).ToString();
            lblBookingPaid.Text = bookings.Count(b => b.Status == BookingStatus.Paid).ToString();
            lblBookingCompleted.Text = bookings.Count(b => b.Status == BookingStatus.Completed).ToString();
            lblBookingCancelled.Text = bookings.Count(b => b.Status == BookingStatus.Cancelled).ToString();

            decimal totalPendapatan = bookings
                .Where(b => b.Status == BookingStatus.Paid || b.Status == BookingStatus.Completed)
                .Sum(b => b.TotalPrice);

            lblTotalPendapatan.Text = FormatRupiah(totalPendapatan);

            var reportData = bookings
                .Select(b => new
                {
                    b.Id,
                    Tanggal = b.Date.ToString("dd/MM/yyyy"),
                    Pemesan = b.CustomerName,
                    Lapangan = AppServices.FieldService.GetById(b.FieldId)?.Name ?? $"Lapangan {b.FieldId}",
                    Jam = $"{b.StartTime:HH:mm}-{b.EndTime:HH:mm}",
                    Durasi = $"{b.DurationHours} Jam",
                    Total = FormatRupiah(b.TotalPrice),
                    Status = b.Status.ToString()
                })
                .ToList();

            dgvReport.DataSource = null;
            dgvReport.DataSource = reportData;
        }

        private string FormatRupiah(decimal amount)
        {
            return "Rp " + amount.ToString("N0", rupiahCulture);
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            GenerateReport();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GenerateReport();
        }

        private void btnKembali_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtpPeriodeAwal_ValueChanged(object sender, EventArgs e)
        {
        }

        private void dtpPeriodeAkhir_ValueChanged(object sender, EventArgs e)
        {
        }

        private void lblTotalBooking_Click(object sender, EventArgs e)
        {
        }

        private void lblBookingPending_Click(object sender, EventArgs e)
        {
        }

        private void lblBookingPaid_Click(object sender, EventArgs e)
        {
        }

        private void lblBookingCompleted_Click(object sender, EventArgs e)
        {
        }

        private void lblBookingCancelled_Click(object sender, EventArgs e)
        {
        }

        private void lblTotalPendapatan_Click(object sender, EventArgs e)
        {
        }

        private void dgvReport_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
