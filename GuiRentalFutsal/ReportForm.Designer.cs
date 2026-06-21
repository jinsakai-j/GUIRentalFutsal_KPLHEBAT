namespace GuiRentalFutsal
{
    partial class ReportForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblPeriodeAwal = new Label();
            dtpPeriodeAwal = new DateTimePicker();
            lblPeriodeAkhir = new Label();
            dtpPeriodeAkhir = new DateTimePicker();
            btnGenerateReport = new Button();
            btnRefresh = new Button();
            gbRingkasan = new GroupBox();
            lblTotalBookingText = new Label();
            lblTotalBooking = new Label();
            lblBookingPendingText = new Label();
            lblBookingPending = new Label();
            lblBookingPaidText = new Label();
            lblBookingPaid = new Label();
            lblBookingCompletedText = new Label();
            lblBookingCompleted = new Label();
            lblBookingCancelledText = new Label();
            lblBookingCancelled = new Label();
            lblTotalPendapatanText = new Label();
            lblTotalPendapatan = new Label();
            lblDetailBooking = new Label();
            dgvReport = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colTanggal = new DataGridViewTextBoxColumn();
            colLapangan = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            colTotal = new DataGridViewTextBoxColumn();
            btnKembali = new Button();
            gbRingkasan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReport).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.Top;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.Location = new Point(30, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(790, 36);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "LAPORAN";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblPeriodeAwal
            // 
            lblPeriodeAwal.Anchor = AnchorStyles.Top;
            lblPeriodeAwal.Location = new Point(145, 77);
            lblPeriodeAwal.Name = "lblPeriodeAwal";
            lblPeriodeAwal.Size = new Size(100, 25);
            lblPeriodeAwal.TabIndex = 1;
            lblPeriodeAwal.Text = "Periode Awal :";
            lblPeriodeAwal.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dtpPeriodeAwal
            // 
            dtpPeriodeAwal.Anchor = AnchorStyles.Top;
            dtpPeriodeAwal.Format = DateTimePickerFormat.Short;
            dtpPeriodeAwal.Location = new Point(255, 77);
            dtpPeriodeAwal.Name = "dtpPeriodeAwal";
            dtpPeriodeAwal.Size = new Size(135, 23);
            dtpPeriodeAwal.TabIndex = 2;
            dtpPeriodeAwal.ValueChanged += dtpPeriodeAwal_ValueChanged;
            // 
            // lblPeriodeAkhir
            // 
            lblPeriodeAkhir.Anchor = AnchorStyles.Top;
            lblPeriodeAkhir.Location = new Point(430, 77);
            lblPeriodeAkhir.Name = "lblPeriodeAkhir";
            lblPeriodeAkhir.Size = new Size(105, 25);
            lblPeriodeAkhir.TabIndex = 3;
            lblPeriodeAkhir.Text = "Periode Akhir :";
            lblPeriodeAkhir.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dtpPeriodeAkhir
            // 
            dtpPeriodeAkhir.Anchor = AnchorStyles.Top;
            dtpPeriodeAkhir.Format = DateTimePickerFormat.Short;
            dtpPeriodeAkhir.Location = new Point(545, 77);
            dtpPeriodeAkhir.Name = "dtpPeriodeAkhir";
            dtpPeriodeAkhir.Size = new Size(135, 23);
            dtpPeriodeAkhir.TabIndex = 4;
            dtpPeriodeAkhir.ValueChanged += dtpPeriodeAkhir_ValueChanged;
            // 
            // btnGenerateReport
            // 
            btnGenerateReport.Anchor = AnchorStyles.Top;
            btnGenerateReport.Location = new Point(300, 118);
            btnGenerateReport.Name = "btnGenerateReport";
            btnGenerateReport.Size = new Size(150, 34);
            btnGenerateReport.TabIndex = 5;
            btnGenerateReport.Text = "Generate Laporan";
            btnGenerateReport.UseVisualStyleBackColor = true;
            btnGenerateReport.Click += btnGenerateReport_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = AnchorStyles.Top;
            btnRefresh.Location = new Point(465, 118);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(100, 34);
            btnRefresh.TabIndex = 6;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // gbRingkasan
            // 
            gbRingkasan.Anchor = AnchorStyles.Top;
            gbRingkasan.Controls.Add(lblTotalBookingText);
            gbRingkasan.Controls.Add(lblTotalBooking);
            gbRingkasan.Controls.Add(lblBookingPendingText);
            gbRingkasan.Controls.Add(lblBookingPending);
            gbRingkasan.Controls.Add(lblBookingPaidText);
            gbRingkasan.Controls.Add(lblBookingPaid);
            gbRingkasan.Controls.Add(lblBookingCompletedText);
            gbRingkasan.Controls.Add(lblBookingCompleted);
            gbRingkasan.Controls.Add(lblBookingCancelledText);
            gbRingkasan.Controls.Add(lblBookingCancelled);
            gbRingkasan.Controls.Add(lblTotalPendapatanText);
            gbRingkasan.Controls.Add(lblTotalPendapatan);
            gbRingkasan.Location = new Point(80, 176);
            gbRingkasan.Name = "gbRingkasan";
            gbRingkasan.Size = new Size(690, 170);
            gbRingkasan.TabIndex = 7;
            gbRingkasan.TabStop = false;
            gbRingkasan.Text = "Ringkasan";
            // 
            // lblTotalBookingText
            // 
            lblTotalBookingText.Location = new Point(45, 35);
            lblTotalBookingText.Name = "lblTotalBookingText";
            lblTotalBookingText.Size = new Size(145, 24);
            lblTotalBookingText.TabIndex = 0;
            lblTotalBookingText.Text = "Total Booking";
            lblTotalBookingText.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTotalBooking
            // 
            lblTotalBooking.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTotalBooking.Location = new Point(200, 35);
            lblTotalBooking.Name = "lblTotalBooking";
            lblTotalBooking.Size = new Size(90, 24);
            lblTotalBooking.TabIndex = 1;
            lblTotalBooking.Text = "0";
            lblTotalBooking.TextAlign = ContentAlignment.MiddleLeft;
            lblTotalBooking.Click += lblTotalBooking_Click;
            // 
            // lblBookingPendingText
            // 
            lblBookingPendingText.Location = new Point(45, 75);
            lblBookingPendingText.Name = "lblBookingPendingText";
            lblBookingPendingText.Size = new Size(145, 24);
            lblBookingPendingText.TabIndex = 2;
            lblBookingPendingText.Text = "Booking Pending";
            lblBookingPendingText.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblBookingPending
            // 
            lblBookingPending.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblBookingPending.Location = new Point(200, 75);
            lblBookingPending.Name = "lblBookingPending";
            lblBookingPending.Size = new Size(90, 24);
            lblBookingPending.TabIndex = 3;
            lblBookingPending.Text = "0";
            lblBookingPending.TextAlign = ContentAlignment.MiddleLeft;
            lblBookingPending.Click += lblBookingPending_Click;
            // 
            // lblBookingPaidText
            // 
            lblBookingPaidText.Location = new Point(45, 115);
            lblBookingPaidText.Name = "lblBookingPaidText";
            lblBookingPaidText.Size = new Size(145, 24);
            lblBookingPaidText.TabIndex = 4;
            lblBookingPaidText.Text = "Booking Paid";
            lblBookingPaidText.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblBookingPaid
            // 
            lblBookingPaid.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblBookingPaid.Location = new Point(200, 115);
            lblBookingPaid.Name = "lblBookingPaid";
            lblBookingPaid.Size = new Size(90, 24);
            lblBookingPaid.TabIndex = 5;
            lblBookingPaid.Text = "0";
            lblBookingPaid.TextAlign = ContentAlignment.MiddleLeft;
            lblBookingPaid.Click += lblBookingPaid_Click;
            // 
            // lblBookingCompletedText
            // 
            lblBookingCompletedText.Location = new Point(385, 35);
            lblBookingCompletedText.Name = "lblBookingCompletedText";
            lblBookingCompletedText.Size = new Size(145, 24);
            lblBookingCompletedText.TabIndex = 6;
            lblBookingCompletedText.Text = "Booking Completed";
            lblBookingCompletedText.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblBookingCompleted
            // 
            lblBookingCompleted.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblBookingCompleted.Location = new Point(545, 35);
            lblBookingCompleted.Name = "lblBookingCompleted";
            lblBookingCompleted.Size = new Size(100, 24);
            lblBookingCompleted.TabIndex = 7;
            lblBookingCompleted.Text = "0";
            lblBookingCompleted.TextAlign = ContentAlignment.MiddleLeft;
            lblBookingCompleted.Click += lblBookingCompleted_Click;
            // 
            // lblBookingCancelledText
            // 
            lblBookingCancelledText.Location = new Point(385, 75);
            lblBookingCancelledText.Name = "lblBookingCancelledText";
            lblBookingCancelledText.Size = new Size(145, 24);
            lblBookingCancelledText.TabIndex = 8;
            lblBookingCancelledText.Text = "Booking Cancelled";
            lblBookingCancelledText.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblBookingCancelled
            // 
            lblBookingCancelled.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblBookingCancelled.Location = new Point(545, 75);
            lblBookingCancelled.Name = "lblBookingCancelled";
            lblBookingCancelled.Size = new Size(100, 24);
            lblBookingCancelled.TabIndex = 9;
            lblBookingCancelled.Text = "0";
            lblBookingCancelled.TextAlign = ContentAlignment.MiddleLeft;
            lblBookingCancelled.Click += lblBookingCancelled_Click;
            // 
            // lblTotalPendapatanText
            // 
            lblTotalPendapatanText.Location = new Point(385, 115);
            lblTotalPendapatanText.Name = "lblTotalPendapatanText";
            lblTotalPendapatanText.Size = new Size(145, 24);
            lblTotalPendapatanText.TabIndex = 10;
            lblTotalPendapatanText.Text = "Total Pendapatan";
            lblTotalPendapatanText.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTotalPendapatan
            // 
            lblTotalPendapatan.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTotalPendapatan.Location = new Point(545, 115);
            lblTotalPendapatan.Name = "lblTotalPendapatan";
            lblTotalPendapatan.Size = new Size(125, 24);
            lblTotalPendapatan.TabIndex = 11;
            lblTotalPendapatan.Text = "Rp 0";
            lblTotalPendapatan.TextAlign = ContentAlignment.MiddleLeft;
            lblTotalPendapatan.Click += lblTotalPendapatan_Click;
            // 
            // lblDetailBooking
            // 
            lblDetailBooking.Anchor = AnchorStyles.Top;
            lblDetailBooking.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDetailBooking.Location = new Point(30, 369);
            lblDetailBooking.Name = "lblDetailBooking";
            lblDetailBooking.Size = new Size(790, 24);
            lblDetailBooking.TabIndex = 8;
            lblDetailBooking.Text = "Detail Booking";
            lblDetailBooking.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dgvReport
            // 
            dgvReport.AllowUserToAddRows = false;
            dgvReport.AllowUserToDeleteRows = false;
            dgvReport.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            dgvReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReport.Columns.AddRange(new DataGridViewColumn[] { colId, colTanggal, colLapangan, colStatus, colTotal });
            dgvReport.Location = new Point(30, 398);
            dgvReport.MultiSelect = false;
            dgvReport.Name = "dgvReport";
            dgvReport.ReadOnly = true;
            dgvReport.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReport.Size = new Size(790, 180);
            dgvReport.TabIndex = 9;
            dgvReport.CellContentClick += dgvReport_CellContentClick;
            // 
            // colId
            // 
            colId.HeaderText = "ID";
            colId.Name = "colId";
            colId.ReadOnly = true;
            // 
            // colTanggal
            // 
            colTanggal.HeaderText = "Tanggal";
            colTanggal.Name = "colTanggal";
            colTanggal.ReadOnly = true;
            // 
            // colLapangan
            // 
            colLapangan.HeaderText = "Lapangan";
            colLapangan.Name = "colLapangan";
            colLapangan.ReadOnly = true;
            // 
            // colStatus
            // 
            colStatus.HeaderText = "Status";
            colStatus.Name = "colStatus";
            colStatus.ReadOnly = true;
            // 
            // colTotal
            // 
            colTotal.HeaderText = "Total";
            colTotal.Name = "colTotal";
            colTotal.ReadOnly = true;
            // 
            // btnKembali
            // 
            btnKembali.Anchor = AnchorStyles.Bottom;
            btnKembali.Location = new Point(30, 596);
            btnKembali.Name = "btnKembali";
            btnKembali.Size = new Size(100, 34);
            btnKembali.TabIndex = 10;
            btnKembali.Text = "Kembali";
            btnKembali.UseVisualStyleBackColor = true;
            btnKembali.Click += btnKembali_Click;
            // 
            // ReportForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(850, 650);
            Controls.Add(btnKembali);
            Controls.Add(dgvReport);
            Controls.Add(lblDetailBooking);
            Controls.Add(gbRingkasan);
            Controls.Add(btnRefresh);
            Controls.Add(btnGenerateReport);
            Controls.Add(dtpPeriodeAkhir);
            Controls.Add(lblPeriodeAkhir);
            Controls.Add(dtpPeriodeAwal);
            Controls.Add(lblPeriodeAwal);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.Sizable;
            MaximizeBox = true;
            MinimumSize = new Size(760, 600);
            Name = "ReportForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ReportForm";
            gbRingkasan.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvReport).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label lblTitle;
        private Label lblPeriodeAwal;
        private DateTimePicker dtpPeriodeAwal;
        private Label lblPeriodeAkhir;
        private DateTimePicker dtpPeriodeAkhir;
        private Button btnGenerateReport;
        private Button btnRefresh;
        private GroupBox gbRingkasan;
        private Label lblTotalBookingText;
        private Label lblTotalBooking;
        private Label lblBookingPendingText;
        private Label lblBookingPending;
        private Label lblBookingPaidText;
        private Label lblBookingPaid;
        private Label lblBookingCompletedText;
        private Label lblBookingCompleted;
        private Label lblBookingCancelledText;
        private Label lblBookingCancelled;
        private Label lblTotalPendapatanText;
        private Label lblTotalPendapatan;
        private Label lblDetailBooking;
        private DataGridView dgvReport;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colTanggal;
        private DataGridViewTextBoxColumn colLapangan;
        private DataGridViewTextBoxColumn colStatus;
        private DataGridViewTextBoxColumn colTotal;
        private Button btnKembali;
    }
}
