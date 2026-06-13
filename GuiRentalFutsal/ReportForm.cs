using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace GuiRentalFutsal
{
    public partial class ReportForm : Form
    {
        public ReportForm()
        {
            InitializeComponent();
            SetupReportGrid();
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            dtpPeriodeAwal.Value = DateTime.Today;
            dtpPeriodeAkhir.Value = DateTime.Today;

            GenerateReport();
        }

        private void SetupReportGrid()
        {
            dgvReport.AutoGenerateColumns = false;

            dgvReport.Columns["colId"].DataPropertyName = "Id";
            dgvReport.Columns["colTanggal"].DataPropertyName = "Tanggal";
            dgvReport.Columns["colLapangan"].DataPropertyName = "Lapangan";
            dgvReport.Columns["colStatus"].DataPropertyName = "Status";
            dgvReport.Columns["colTotal"].DataPropertyName = "Total";

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
                    MessageBoxIcon.Warning
                );
                return;
            }

            var bookings = AppServices.BookingService.GetAllBookings()
                .Where(b => b.Date >= periodeAwal && b.Date <= periodeAkhir)
                .ToList();

            int totalBooking = bookings.Count;
            int bookingPending = bookings.Count(b => b.Status.ToString() == "PendingPayment");
            int bookingPaid = bookings.Count(b => b.Status.ToString() == "Paid");
            int bookingCompleted = bookings.Count(b => b.Status.ToString() == "Completed");
            int bookingCancelled = bookings.Count(b => b.Status.ToString() == "Cancelled");

            decimal totalPendapatan = bookings
                .Where(b => b.Status.ToString() == "Paid" || b.Status.ToString() == "Completed")
                .Sum(b => b.TotalPrice);

            lblTotalBooking.Text = totalBooking.ToString();
            lblBookingPending.Text = bookingPending.ToString();
            lblBookingPaid.Text = bookingPaid.ToString();
            lblBookingCompleted.Text = bookingCompleted.ToString();
            lblBookingCancelled.Text = bookingCancelled.ToString();
            lblTotalPendapatan.Text = "Rp " + totalPendapatan.ToString("N0", new CultureInfo("id-ID"));

            var reportData = bookings
                .Select(b => new
                {
                    b.Id,
                    Tanggal = b.Date.ToString("dd/MM/yyyy"),
                    Lapangan = AppServices.FieldService.GetById(b.FieldId)?.Name ?? $"Lapangan {b.FieldId}",
                    Status = b.Status.ToString(),
                    Total = "Rp " + b.TotalPrice.ToString("N0", new CultureInfo("id-ID"))
                })
                .ToList();

            dgvReport.DataSource = null;
            dgvReport.DataSource = reportData;
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
