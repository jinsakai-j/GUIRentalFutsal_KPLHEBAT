using System.Globalization;
using GuiRentalFutsal.Models;

namespace GuiRentalFutsal
{
    public partial class PaymentForm : Form
    {
        private readonly CultureInfo rupiahCulture = new("id-ID");
        private Booking? selectedBooking;

        public PaymentForm()
        {
            InitializeComponent();
        }

        private void JumlahBayarBtn_TextChanged(object sender, EventArgs e)
        {
        }

        private void PaymentForm_Load(object sender, EventArgs e)
        {
            SetupPaymentForm();
            SetupPaymentGrid();
            LoadPendingPayments();
            ClearDetail();
        }

        private void SetupPaymentForm()
        {
            MetodeBayarCmb.Items.Clear();
            MetodeBayarCmb.Items.Add("Cash");
            MetodeBayarCmb.Items.Add("Transfer Bank");
            MetodeBayarCmb.Items.Add("QRIS");
            MetodeBayarCmb.DropDownStyle = ComboBoxStyle.DropDownList;
            MetodeBayarCmb.SelectedIndex = 0;

            IdBookingTxt.ReadOnly = false;
            NamaPemesanTxt.ReadOnly = true;
            LapanganTxt.ReadOnly = true;
            TanggalJamTxt.ReadOnly = true;
            TotalTagihanTxt.ReadOnly = true;
            StatusBookingTxt.ReadOnly = true;
        }

        private void SetupPaymentGrid()
        {
            RiwayatPembayaranDgv.AutoGenerateColumns = false;
            RiwayatPembayaranDgv.Columns.Clear();

            RiwayatPembayaranDgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colId",
                HeaderText = "ID Booking",
                DataPropertyName = "Id"
            });
            RiwayatPembayaranDgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colPemesan",
                HeaderText = "Nama Pemesan",
                DataPropertyName = "Pemesan"
            });
            RiwayatPembayaranDgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colNoHp",
                HeaderText = "No HP",
                DataPropertyName = "NoHp"
            });
            RiwayatPembayaranDgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colLapangan",
                HeaderText = "Lapangan",
                DataPropertyName = "Lapangan"
            });
            RiwayatPembayaranDgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colTanggal",
                HeaderText = "Tanggal",
                DataPropertyName = "Tanggal"
            });
            RiwayatPembayaranDgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colJam",
                HeaderText = "Jam",
                DataPropertyName = "Jam"
            });
            RiwayatPembayaranDgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colTotal",
                HeaderText = "Total Harga",
                DataPropertyName = "Total"
            });
            RiwayatPembayaranDgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colStatus",
                HeaderText = "Status",
                DataPropertyName = "Status"
            });

            RiwayatPembayaranDgv.ReadOnly = true;
            RiwayatPembayaranDgv.AllowUserToAddRows = false;
            RiwayatPembayaranDgv.AllowUserToDeleteRows = false;
            RiwayatPembayaranDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            RiwayatPembayaranDgv.MultiSelect = false;
            RiwayatPembayaranDgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            RiwayatPembayaranDgv.CellClick += RiwayatPembayaranDgv_CellClick;
        }

        private void LoadPendingPayments()
        {
            var data = AppServices.BookingService.GetAllBookings()
                .Where(b => b.Status == BookingStatus.PendingPayment)
                .Select(b => new
                {
                    b.Id,
                    Pemesan = b.CustomerName,
                    NoHp = b.CustomerPhone,
                    Lapangan = GetFieldName(b.FieldId),
                    Tanggal = b.Date.ToString("dd/MM/yyyy"),
                    Jam = $"{b.StartTime:HH:mm}-{b.EndTime:HH:mm}",
                    Total = FormatRupiah(b.TotalPrice),
                    Status = b.Status.ToString()
                })
                .ToList();

            RiwayatPembayaranDgv.DataSource = null;
            RiwayatPembayaranDgv.DataSource = data;
        }

        private void CariBtn_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(IdBookingTxt.Text.Trim(), out int bookingId))
            {
                MessageBox.Show("ID booking harus berupa angka.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Booking? booking = AppServices.BookingService.GetAllBookings()
                .FirstOrDefault(b => b.Id == bookingId && b.Status == BookingStatus.PendingPayment);

            if (booking is null)
            {
                MessageBox.Show("Booking pending payment tidak ditemukan.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ShowBookingDetail(booking);
        }

        private void KonfirmasiPembayaranBtn_Click(object sender, EventArgs e)
        {
            if (selectedBooking is null)
            {
                MessageBox.Show("Pilih booking terlebih dahulu.",
                    "Peringatan",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(JumlahBayarTxt.Text.Trim(), out decimal jumlahBayar))
            {
                MessageBox.Show("Jumlah pembayaran wajib angka.",
                    "Peringatan",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (jumlahBayar < selectedBooking.TotalPrice)
            {
                MessageBox.Show("Jumlah pembayaran tidak boleh kurang dari total harga.",
                    "Peringatan",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            decimal kembalian = jumlahBayar - selectedBooking.TotalPrice;

            var result = AppServices.PaymentService.PayBooking(
                selectedBooking.Id,
                jumlahBayar
            );

            if (result.Success)
            {
                if (kembalian > 0)
                {
                    MessageBox.Show(
                        $"Pembayaran berhasil!\n\n" +
                        $"Total Tagihan : {FormatRupiah(selectedBooking.TotalPrice)}\n" +
                        $"Jumlah Bayar : {FormatRupiah(jumlahBayar)}\n" +
                        $"Kembalian : {FormatRupiah(kembalian)}",
                        "Pembayaran Berhasil",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(
                        "Pembayaran berhasil!",
                        "Pembayaran Berhasil",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }

                LoadPendingPayments();
                ClearDetail();
            }
            else
            {
                MessageBox.Show(
                    result.Message,
                    "Gagal",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void BatalPembayaranBtn_Click(object sender, EventArgs e)
        {
            ClearDetail();
        }

        private void KembaliBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RiwayatPembayaranDgv_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            object? idValue = RiwayatPembayaranDgv.Rows[e.RowIndex].Cells["colId"].Value;
            if (idValue is null || !int.TryParse(idValue.ToString(), out int bookingId))
            {
                return;
            }

            Booking? booking = AppServices.BookingService.GetAllBookings()
                .FirstOrDefault(b => b.Id == bookingId && b.Status == BookingStatus.PendingPayment);

            if (booking is not null)
            {
                ShowBookingDetail(booking);
            }
        }

        private void ShowBookingDetail(Booking booking)
        {
            selectedBooking = booking;

            IdBookingTxt.Text = booking.Id.ToString();
            NamaPemesanTxt.Text = booking.CustomerName;
            LapanganTxt.Text = $"{GetFieldName(booking.FieldId)} | HP: {booking.CustomerPhone}";
            TanggalJamTxt.Text = $"{booking.Date:dd/MM/yyyy} {booking.StartTime:HH:mm}-{booking.EndTime:HH:mm}";
            TotalTagihanTxt.Text = booking.TotalPrice.ToString("0");
            StatusBookingTxt.Text = booking.Status.ToString();
            JumlahBayarTxt.Clear();
            JumlahBayarTxt.Focus();
        }

        private void ClearDetail()
        {
            selectedBooking = null;
            IdBookingTxt.Clear();
            NamaPemesanTxt.Clear();
            LapanganTxt.Clear();
            TanggalJamTxt.Clear();
            TotalTagihanTxt.Clear();
            StatusBookingTxt.Clear();
            JumlahBayarTxt.Clear();
            RiwayatPembayaranDgv.ClearSelection();
        }

        private static string GetFieldName(int fieldId)
        {
            return AppServices.FieldService.GetById(fieldId)?.Name ?? $"Lapangan {fieldId}";
        }

        private string FormatRupiah(decimal amount)
        {
            return amount.ToString("C0", rupiahCulture);
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }
    }
}
