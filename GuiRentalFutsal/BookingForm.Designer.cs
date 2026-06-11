namespace GuiRentalFutsal
{
    partial class BookingForm
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
            Nama = new Label();
            NoHp = new Label();
            lapangan = new Label();
            tanggal = new Label();
            jam = new Label();
            durasi = new Label();
            harga = new Label();
            status = new Label();
            tNama = new TextBox();
            tNoHp = new TextBox();
            tJam = new TextBox();
            tDurasi = new TextBox();
            dataGridView1 = new DataGridView();
            Id = new DataGridViewTextBoxColumn();
            gPemesan = new DataGridViewTextBoxColumn();
            gLapangan = new DataGridViewTextBoxColumn();
            gJam = new DataGridViewTextBoxColumn();
            gTotal = new DataGridViewTextBoxColumn();
            gStatus = new DataGridViewTextBoxColumn();
            lHarga = new Label();
            lStatus = new Label();
            pilihTanggal = new DateTimePicker();
            cekJadwal = new Button();
            buatBooking = new Button();
            reset = new Button();
            keluar = new Button();
            cmbLapangan = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // Nama
            // 
            Nama.AutoSize = true;
            Nama.Location = new Point(53, 38);
            Nama.Name = "Nama";
            Nama.Size = new Size(134, 25);
            Nama.TabIndex = 0;
            Nama.Text = "Nama Pemesan";
            Nama.Click += label1_Click;
            // 
            // NoHp
            // 
            NoHp.AutoSize = true;
            NoHp.Location = new Point(53, 75);
            NoHp.Name = "NoHp";
            NoHp.Size = new Size(62, 25);
            NoHp.TabIndex = 1;
            NoHp.Text = "No hp";
            // 
            // lapangan
            // 
            lapangan.AutoSize = true;
            lapangan.Location = new Point(53, 117);
            lapangan.Name = "lapangan";
            lapangan.Size = new Size(89, 25);
            lapangan.TabIndex = 2;
            lapangan.Text = "Lapangan";
            // 
            // tanggal
            // 
            tanggal.AutoSize = true;
            tanggal.Location = new Point(53, 154);
            tanggal.Name = "tanggal";
            tanggal.Size = new Size(73, 25);
            tanggal.TabIndex = 3;
            tanggal.Text = "Tanggal";
            // 
            // jam
            // 
            jam.AutoSize = true;
            jam.Location = new Point(53, 191);
            jam.Name = "jam";
            jam.Size = new Size(91, 25);
            jam.TabIndex = 4;
            jam.Text = "Jam mulai";
            // 
            // durasi
            // 
            durasi.AutoSize = true;
            durasi.Location = new Point(53, 228);
            durasi.Name = "durasi";
            durasi.Size = new Size(60, 25);
            durasi.TabIndex = 5;
            durasi.Text = "durasi";
            durasi.Click += label6_Click;
            // 
            // harga
            // 
            harga.AutoSize = true;
            harga.Location = new Point(49, 268);
            harga.Name = "harga";
            harga.Size = new Size(99, 25);
            harga.TabIndex = 6;
            harga.Text = "Total harga";
            // 
            // status
            // 
            status.AutoSize = true;
            status.Location = new Point(49, 302);
            status.Name = "status";
            status.Size = new Size(103, 25);
            status.TabIndex = 7;
            status.Text = "Status Awal";
            // 
            // tNama
            // 
            tNama.Location = new Point(304, 38);
            tNama.Name = "tNama";
            tNama.Size = new Size(150, 31);
            tNama.TabIndex = 8;
            tNama.TextChanged += tNama_TextChanged;
            // 
            // tNoHp
            // 
            tNoHp.Location = new Point(304, 75);
            tNoHp.Name = "tNoHp";
            tNoHp.Size = new Size(150, 31);
            tNoHp.TabIndex = 9;
            tNoHp.TextChanged += tNoHp_TextChanged;
            // 
            // tJam
            // 
            tJam.Location = new Point(304, 191);
            tJam.Name = "tJam";
            tJam.Size = new Size(150, 31);
            tJam.TabIndex = 12;
            tJam.TextChanged += tJam_TextChanged;
            // 
            // tDurasi
            // 
            tDurasi.Location = new Point(304, 228);
            tDurasi.Name = "tDurasi";
            tDurasi.Size = new Size(150, 31);
            tDurasi.TabIndex = 13;
            tDurasi.TextChanged += tDurasi_TextChanged;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Id, gPemesan, gLapangan, gJam, gTotal, gStatus });
            dataGridView1.Location = new Point(26, 356);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(943, 306);
            dataGridView1.TabIndex = 16;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // Id
            // 
            Id.HeaderText = "Id";
            Id.MinimumWidth = 8;
            Id.Name = "Id";
            Id.ReadOnly = true;
            // 
            // gPemesan
            // 
            gPemesan.HeaderText = "Pemesan";
            gPemesan.MinimumWidth = 8;
            gPemesan.Name = "gPemesan";
            gPemesan.ReadOnly = true;
            // 
            // gLapangan
            // 
            gLapangan.HeaderText = "Lapangan";
            gLapangan.MinimumWidth = 8;
            gLapangan.Name = "gLapangan";
            gLapangan.ReadOnly = true;
            // 
            // gJam
            // 
            gJam.HeaderText = "Jam";
            gJam.MinimumWidth = 8;
            gJam.Name = "gJam";
            gJam.ReadOnly = true;
            // 
            // gTotal
            // 
            gTotal.HeaderText = "Total";
            gTotal.MinimumWidth = 8;
            gTotal.Name = "gTotal";
            gTotal.ReadOnly = true;
            // 
            // gStatus
            // 
            gStatus.HeaderText = "status";
            gStatus.MinimumWidth = 8;
            gStatus.Name = "gStatus";
            gStatus.ReadOnly = true;
            // 
            // lHarga
            // 
            lHarga.AutoSize = true;
            lHarga.Location = new Point(304, 268);
            lHarga.Name = "lHarga";
            lHarga.Size = new Size(59, 25);
            lHarga.TabIndex = 17;
            lHarga.Text = "label1";
            lHarga.Click += lHarga_Click;
            // 
            // lStatus
            // 
            lStatus.AutoSize = true;
            lStatus.Location = new Point(304, 302);
            lStatus.Name = "lStatus";
            lStatus.Size = new Size(59, 25);
            lStatus.TabIndex = 18;
            lStatus.Text = "label2";
            lStatus.Click += lStatus_Click;
            // 
            // pilihTanggal
            // 
            pilihTanggal.Location = new Point(304, 154);
            pilihTanggal.Name = "pilihTanggal";
            pilihTanggal.Size = new Size(300, 31);
            pilihTanggal.TabIndex = 19;
            pilihTanggal.ValueChanged += pilihTanggal_ValueChanged;
            // 
            // cekJadwal
            // 
            cekJadwal.Location = new Point(758, 50);
            cekJadwal.Name = "cekJadwal";
            cekJadwal.Size = new Size(112, 34);
            cekJadwal.TabIndex = 20;
            cekJadwal.Text = "Cek Jadwal";
            cekJadwal.UseVisualStyleBackColor = true;
            cekJadwal.Click += cekJadwal_Click;
            // 
            // buatBooking
            // 
            buatBooking.Location = new Point(758, 117);
            buatBooking.Name = "buatBooking";
            buatBooking.Size = new Size(128, 34);
            buatBooking.TabIndex = 21;
            buatBooking.Text = "Buat Booking";
            buatBooking.UseVisualStyleBackColor = true;
            buatBooking.Click += buatBooking_Click;
            // 
            // reset
            // 
            reset.Location = new Point(758, 186);
            reset.Name = "reset";
            reset.Size = new Size(112, 34);
            reset.TabIndex = 22;
            reset.Text = "Reset";
            reset.UseVisualStyleBackColor = true;
            reset.Click += reset_Click;
            // 
            // keluar
            // 
            keluar.Location = new Point(758, 249);
            keluar.Name = "keluar";
            keluar.Size = new Size(112, 34);
            keluar.TabIndex = 23;
            keluar.Text = "Kembali";
            keluar.UseVisualStyleBackColor = true;
            keluar.Click += keluar_Click;
            // 
            // cmbLapangan
            // 
            cmbLapangan.FormattingEnabled = true;
            cmbLapangan.Location = new Point(304, 115);
            cmbLapangan.Name = "cmbLapangan";
            cmbLapangan.Size = new Size(182, 33);
            cmbLapangan.TabIndex = 24;
            cmbLapangan.SelectedIndexChanged += cmbLapangan_SelectedIndexChanged;
            // 
            // BookingForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(998, 699);
            Controls.Add(cmbLapangan);
            Controls.Add(keluar);
            Controls.Add(reset);
            Controls.Add(buatBooking);
            Controls.Add(cekJadwal);
            Controls.Add(pilihTanggal);
            Controls.Add(lStatus);
            Controls.Add(lHarga);
            Controls.Add(dataGridView1);
            Controls.Add(tDurasi);
            Controls.Add(tJam);
            Controls.Add(tNoHp);
            Controls.Add(tNama);
            Controls.Add(status);
            Controls.Add(harga);
            Controls.Add(durasi);
            Controls.Add(jam);
            Controls.Add(tanggal);
            Controls.Add(lapangan);
            Controls.Add(NoHp);
            Controls.Add(Nama);
            Name = "BookingForm";
            Text = "BookingForm";
            Load += BookingForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Nama;
        private Label NoHp;
        private Label lapangan;
        private Label tanggal;
        private Label jam;
        private Label durasi;
        private Label harga;
        private Label status;
        private TextBox tNama;
        private TextBox tNoHp;
        private TextBox tJam;
        private TextBox tDurasi;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn gPemesan;
        private DataGridViewTextBoxColumn gLapangan;
        private DataGridViewTextBoxColumn gJam;
        private DataGridViewTextBoxColumn gTotal;
        private DataGridViewTextBoxColumn gStatus;
        private Label lHarga;
        private Label lStatus;
        private DateTimePicker pilihTanggal;
        private Button cekJadwal;
        private Button buatBooking;
        private Button reset;
        private Button keluar;
        private ComboBox cmbLapangan;
    }
}