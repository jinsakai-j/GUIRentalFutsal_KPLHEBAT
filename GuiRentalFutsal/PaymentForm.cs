using System.Globalization;
using GuiRentalFutsal.Models;

namespace GuiRentalFutsal
{
    public partial class PaymentForm : Form
    {
        private const decimal MaxCashPayment = 5_000_000m;

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
            MetodeBayarCmb.SelectedIndexChanged += MetodeBayarCmb_SelectedIndexChanged;

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
                .FirstOrDefault(b => b.Id == bookingId);

            if (booking is null)
            {
                MessageBox.Show("Booking tidak ditemukan.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (booking.Status != BookingStatus.PendingPayment)
            {
                MessageBox.Show($"Booking dengan status {booking.Status} tidak bisa dibayar.",
                    "Peringatan",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
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

            if (selectedBooking.Status != BookingStatus.PendingPayment)
            {
                MessageBox.Show($"Booking dengan status {selectedBooking.Status} tidak bisa dibayar.",
                    "Peringatan",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            string metodeBayar = MetodeBayarCmb.SelectedItem?.ToString() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(metodeBayar))
            {
                MessageBox.Show("Metode pembayaran wajib dipilih.",
                    "Peringatan",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            string jumlahBayarText = JumlahBayarTxt.Text.Trim();
            if (string.IsNullOrWhiteSpace(jumlahBayarText))
            {
                MessageBox.Show("Nominal pembayaran wajib diisi.",
                    "Peringatan",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (!TryParseRupiah(jumlahBayarText, out decimal jumlahBayar))
            {
                MessageBox.Show("Nominal pembayaran harus angka.",
                    "Peringatan",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (jumlahBayar <= 0)
            {
                MessageBox.Show("Nominal pembayaran harus lebih dari 0.",
                    "Peringatan",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            decimal kembalian = jumlahBayar - selectedBooking.TotalPrice;
            string successMessage = "Pembayaran berhasil.";

            if (metodeBayar == "Cash")
            {
                if (jumlahBayar > MaxCashPayment)
                {
                    MessageBox.Show($"Pembayaran cash maksimal {FormatRupiah(MaxCashPayment)}.",
                        "Peringatan",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                if (jumlahBayar < selectedBooking.TotalPrice)
                {
                    MessageBox.Show("Uang pembayaran kurang.",
                        "Peringatan",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                if (kembalian > 0)
                {
                    successMessage = $"Pembayaran berhasil. Kembalian: {FormatRupiah(kembalian)}";
                }
            }
            else if (metodeBayar == "Transfer Bank" || metodeBayar == "QRIS")
            {
                if (jumlahBayar != selectedBooking.TotalPrice)
                {
                    MessageBox.Show("Pembayaran QRIS/Transfer Bank harus sesuai nominal total harga.",
                        "Peringatan",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Metode pembayaran tidak valid.",
                    "Peringatan",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            var result = AppServices.PaymentService.PayBooking(
                selectedBooking.Id,
                jumlahBayar
            );

            if (result.Success)
            {
                MessageBox.Show(
                    successMessage,
                    "Pembayaran Berhasil",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

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
            TotalTagihanTxt.Text = FormatRupiah(booking.TotalPrice);
            StatusBookingTxt.Text = booking.Status.ToString();
            JumlahBayarTxt.Clear();
            FillExactPaymentAmountForNonCash();
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

        private void MetodeBayarCmb_SelectedIndexChanged(object? sender, EventArgs e)
        {
            FillExactPaymentAmountForNonCash();
        }

        private void FillExactPaymentAmountForNonCash()
        {
            string metodeBayar = MetodeBayarCmb.SelectedItem?.ToString() ?? string.Empty;
            if (selectedBooking is null)
            {
                return;
            }

            if (metodeBayar == "Transfer Bank" || metodeBayar == "QRIS")
            {
                JumlahBayarTxt.Text = selectedBooking.TotalPrice.ToString("0", rupiahCulture);
            }
            else if (metodeBayar == "Cash")
            {
                JumlahBayarTxt.Clear();
            }
        }

        private static string GetFieldName(int fieldId)
        {
            return AppServices.FieldService.GetById(fieldId)?.Name ?? $"Lapangan {fieldId}";
        }

        private bool TryParseRupiah(string text, out decimal amount)
        {
            return decimal.TryParse(
                text,
                NumberStyles.Number | NumberStyles.AllowCurrencySymbol,
                rupiahCulture,
                out amount);
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
