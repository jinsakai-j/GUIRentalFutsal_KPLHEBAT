namespace GuiRentalFutsal
{
    partial class PaymentForm
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
            IdBooking = new Label();
            NamaPemesan = new Label();
            Lapangan = new Label();
            TanggalJam = new Label();
            TotalTagihan = new Label();
            StatusBooking = new Label();
            JumlahBayar = new Label();
            MetodeBayar = new Label();
            RiwayatPembayaran = new Label();
            RiwayatPembayaranDgv = new DataGridView();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            KonfirmasiPembayaranBtn = new Button();
            BatalPembayaranBtn = new Button();
            JumlahBayarTxt = new TextBox();
            StatusBookingTxt = new TextBox();
            TotalTagihanTxt = new TextBox();
            TanggalJamTxt = new TextBox();
            LapanganTxt = new TextBox();
            NamaPemesanTxt = new TextBox();
            IdBookingTxt = new TextBox();
            MetodeBayarCmb = new ComboBox();
            CariBtn = new Button();
            label1 = new Label();
            KembaliBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)RiwayatPembayaranDgv).BeginInit();
            SuspendLayout();
            // 
            // IdBooking
            // 
            IdBooking.AutoSize = true;
            IdBooking.Location = new Point(12, 48);
            IdBooking.Name = "IdBooking";
            IdBooking.Size = new Size(65, 15);
            IdBooking.TabIndex = 0;
            IdBooking.Text = "ID Booking";
            // 
            // NamaPemesan
            // 
            NamaPemesan.AutoSize = true;
            NamaPemesan.Location = new Point(12, 79);
            NamaPemesan.Name = "NamaPemesan";
            NamaPemesan.Size = new Size(90, 15);
            NamaPemesan.TabIndex = 1;
            NamaPemesan.Text = "Nama Pemesan";
            // 
            // Lapangan
            // 
            Lapangan.AutoSize = true;
            Lapangan.Location = new Point(12, 106);
            Lapangan.Name = "Lapangan";
            Lapangan.Size = new Size(59, 15);
            Lapangan.TabIndex = 2;
            Lapangan.Text = "Lapangan";
            // 
            // TanggalJam
            // 
            TanggalJam.AutoSize = true;
            TanggalJam.Location = new Point(12, 131);
            TanggalJam.Name = "TanggalJam";
            TanggalJam.Size = new Size(72, 15);
            TanggalJam.TabIndex = 3;
            TanggalJam.Text = "Tanggal Jam";
            // 
            // TotalTagihan
            // 
            TotalTagihan.AutoSize = true;
            TotalTagihan.Location = new Point(12, 164);
            TotalTagihan.Name = "TotalTagihan";
            TotalTagihan.Size = new Size(76, 15);
            TotalTagihan.TabIndex = 4;
            TotalTagihan.Text = "Total Tagihan";
            // 
            // StatusBooking
            // 
            StatusBooking.AutoSize = true;
            StatusBooking.Location = new Point(12, 195);
            StatusBooking.Name = "StatusBooking";
            StatusBooking.Size = new Size(86, 15);
            StatusBooking.TabIndex = 5;
            StatusBooking.Text = "Status Booking";
            // 
            // JumlahBayar
            // 
            JumlahBayar.AutoSize = true;
            JumlahBayar.Location = new Point(12, 227);
            JumlahBayar.Name = "JumlahBayar";
            JumlahBayar.Size = new Size(77, 15);
            JumlahBayar.TabIndex = 6;
            JumlahBayar.Text = "Jumlah Bayar";
            // 
            // MetodeBayar
            // 
            MetodeBayar.AutoSize = true;
            MetodeBayar.Location = new Point(12, 255);
            MetodeBayar.Name = "MetodeBayar";
            MetodeBayar.Size = new Size(80, 15);
            MetodeBayar.TabIndex = 7;
            MetodeBayar.Text = "Metode Bayar";
            // 
            // RiwayatPembayaran
            // 
            RiwayatPembayaran.AutoSize = true;
            RiwayatPembayaran.Location = new Point(12, 321);
            RiwayatPembayaran.Name = "RiwayatPembayaran";
            RiwayatPembayaran.Size = new Size(166, 15);
            RiwayatPembayaran.TabIndex = 8;
            RiwayatPembayaran.Text = "Riwayat Pembayaran/Booking";
            // 
            // RiwayatPembayaranDgv
            // 
            RiwayatPembayaranDgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            RiwayatPembayaranDgv.Location = new Point(12, 354);
            RiwayatPembayaranDgv.Name = "RiwayatPembayaranDgv";
            RiwayatPembayaranDgv.Size = new Size(631, 150);
            RiwayatPembayaranDgv.TabIndex = 9;
            // 
            // KonfirmasiPembayaranBtn
            // 
            KonfirmasiPembayaranBtn.Location = new Point(12, 284);
            KonfirmasiPembayaranBtn.Name = "KonfirmasiPembayaranBtn";
            KonfirmasiPembayaranBtn.Size = new Size(281, 23);
            KonfirmasiPembayaranBtn.TabIndex = 10;
            KonfirmasiPembayaranBtn.Text = "Konfirmasi Pembayaran";
            KonfirmasiPembayaranBtn.UseVisualStyleBackColor = true;
            KonfirmasiPembayaranBtn.Click += KonfirmasiPembayaranBtn_Click;
            // 
            // BatalPembayaranBtn
            // 
            BatalPembayaranBtn.Location = new Point(346, 284);
            BatalPembayaranBtn.Name = "BatalPembayaranBtn";
            BatalPembayaranBtn.Size = new Size(281, 23);
            BatalPembayaranBtn.TabIndex = 11;
            BatalPembayaranBtn.Text = "Batal Pembayaran";
            BatalPembayaranBtn.UseVisualStyleBackColor = true;
            BatalPembayaranBtn.Click += BatalPembayaranBtn_Click;
            // 
            // JumlahBayarTxt
            // 
            JumlahBayarTxt.Location = new Point(105, 224);
            JumlahBayarTxt.Name = "JumlahBayarTxt";
            JumlahBayarTxt.Size = new Size(339, 23);
            JumlahBayarTxt.TabIndex = 12;
            JumlahBayarTxt.TextChanged += JumlahBayarBtn_TextChanged;
            // 
            // StatusBookingTxt
            // 
            StatusBookingTxt.Location = new Point(105, 195);
            StatusBookingTxt.Name = "StatusBookingTxt";
            StatusBookingTxt.Size = new Size(339, 23);
            StatusBookingTxt.TabIndex = 13;
            // 
            // TotalTagihanTxt
            // 
            TotalTagihanTxt.Location = new Point(105, 164);
            TotalTagihanTxt.Name = "TotalTagihanTxt";
            TotalTagihanTxt.Size = new Size(339, 23);
            TotalTagihanTxt.TabIndex = 14;
            // 
            // TanggalJamTxt
            // 
            TanggalJamTxt.Location = new Point(105, 131);
            TanggalJamTxt.Name = "TanggalJamTxt";
            TanggalJamTxt.Size = new Size(339, 23);
            TanggalJamTxt.TabIndex = 15;
            // 
            // LapanganTxt
            // 
            LapanganTxt.Location = new Point(105, 103);
            LapanganTxt.Name = "LapanganTxt";
            LapanganTxt.Size = new Size(339, 23);
            LapanganTxt.TabIndex = 16;
            // 
            // NamaPemesanTxt
            // 
            NamaPemesanTxt.Location = new Point(105, 71);
            NamaPemesanTxt.Name = "NamaPemesanTxt";
            NamaPemesanTxt.Size = new Size(339, 23);
            NamaPemesanTxt.TabIndex = 17;
            // 
            // IdBookingTxt
            // 
            IdBookingTxt.Location = new Point(105, 42);
            IdBookingTxt.Name = "IdBookingTxt";
            IdBookingTxt.Size = new Size(339, 23);
            IdBookingTxt.TabIndex = 18;
            // 
            // MetodeBayarCmb
            // 
            MetodeBayarCmb.FormattingEnabled = true;
            MetodeBayarCmb.Location = new Point(105, 252);
            MetodeBayarCmb.Name = "MetodeBayarCmb";
            MetodeBayarCmb.Size = new Size(339, 23);
            MetodeBayarCmb.TabIndex = 19;
            // 
            // CariBtn
            // 
            CariBtn.Location = new Point(462, 42);
            CariBtn.Name = "CariBtn";
            CariBtn.Size = new Size(165, 23);
            CariBtn.TabIndex = 20;
            CariBtn.Text = "Cari";
            CariBtn.UseVisualStyleBackColor = true;
            CariBtn.Click += CariBtn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(262, 17);
            label1.Name = "label1";
            label1.Size = new Size(133, 15);
            label1.TabIndex = 21;
            label1.Text = "Konfirmasi Pembayaran";
            label1.Click += label1_Click;
            // 
            // KembaliBtn
            // 
            KembaliBtn.Location = new Point(653, 42);
            KembaliBtn.Name = "KembaliBtn";
            KembaliBtn.Size = new Size(120, 23);
            KembaliBtn.TabIndex = 22;
            KembaliBtn.Text = "Kembali";
            KembaliBtn.UseVisualStyleBackColor = true;
            KembaliBtn.Click += KembaliBtn_Click;
            // 
            // PaymentForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 487);
            Controls.Add(KembaliBtn);
            Controls.Add(label1);
            Controls.Add(CariBtn);
            Controls.Add(MetodeBayarCmb);
            Controls.Add(IdBookingTxt);
            Controls.Add(NamaPemesanTxt);
            Controls.Add(LapanganTxt);
            Controls.Add(TanggalJamTxt);
            Controls.Add(TotalTagihanTxt);
            Controls.Add(StatusBookingTxt);
            Controls.Add(JumlahBayarTxt);
            Controls.Add(BatalPembayaranBtn);
            Controls.Add(KonfirmasiPembayaranBtn);
            Controls.Add(RiwayatPembayaranDgv);
            Controls.Add(RiwayatPembayaran);
            Controls.Add(MetodeBayar);
            Controls.Add(JumlahBayar);
            Controls.Add(StatusBooking);
            Controls.Add(TotalTagihan);
            Controls.Add(TanggalJam);
            Controls.Add(Lapangan);
            Controls.Add(NamaPemesan);
            Controls.Add(IdBooking);
            Name = "PaymentForm";
            Text = "PaymentForm";
            Load += PaymentForm_Load;
            ((System.ComponentModel.ISupportInitialize)RiwayatPembayaranDgv).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label IdBooking;
        private Label NamaPemesan;
        private Label Lapangan;
        private Label TanggalJam;
        private Label TotalTagihan;
        private Label StatusBooking;
        private Label JumlahBayar;
        private Label MetodeBayar;
        private Label RiwayatPembayaran;
        private DataGridView RiwayatPembayaranDgv;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Button KonfirmasiPembayaranBtn;
        private Button BatalPembayaranBtn;
        private TextBox JumlahBayarTxt;
        private TextBox StatusBookingTxt;
        private TextBox TotalTagihanTxt;
        private TextBox TanggalJamTxt;
        private TextBox LapanganTxt;
        private TextBox NamaPemesanTxt;
        private TextBox IdBookingTxt;
        private ComboBox MetodeBayarCmb;
        private Button CariBtn;
        private Label label1;
        private Button KembaliBtn;
    }
}
