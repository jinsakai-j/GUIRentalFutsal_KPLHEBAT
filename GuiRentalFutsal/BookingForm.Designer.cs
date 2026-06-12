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
            lHarga = new Label();
            lStatus = new Label();
            pilihTanggal = new DateTimePicker();
            cekJadwal = new Button();
            buatBooking = new Button();
            reset = new Button();
            keluar = new Button();
            cmbLapangan = new ComboBox();
            btnRefreshFields = new Button();
            Id = new DataGridViewTextBoxColumn();
            gPemesan = new DataGridViewTextBoxColumn();
            gNoHp = new DataGridViewTextBoxColumn();
            gLapangan = new DataGridViewTextBoxColumn();
            gTanggal = new DataGridViewTextBoxColumn();
            gJam = new DataGridViewTextBoxColumn();
            gTotal = new DataGridViewTextBoxColumn();
            gStatus = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // Nama
            // 
            Nama.AutoSize = true;
            Nama.Location = new Point(37, 23);
            Nama.Margin = new Padding(2, 0, 2, 0);
            Nama.Name = "Nama";
            Nama.Size = new Size(90, 15);
            Nama.TabIndex = 0;
            Nama.Text = "Nama Pemesan";
            Nama.Click += label1_Click;
            // 
            // NoHp
            // 
            NoHp.AutoSize = true;
            NoHp.Location = new Point(37, 45);
            NoHp.Margin = new Padding(2, 0, 2, 0);
            NoHp.Name = "NoHp";
            NoHp.Size = new Size(40, 15);
            NoHp.TabIndex = 1;
            NoHp.Text = "No hp";
            // 
            // lapangan
            // 
            lapangan.AutoSize = true;
            lapangan.Location = new Point(37, 70);
            lapangan.Margin = new Padding(2, 0, 2, 0);
            lapangan.Name = "lapangan";
            lapangan.Size = new Size(59, 15);
            lapangan.TabIndex = 2;
            lapangan.Text = "Lapangan";
            // 
            // tanggal
            // 
            tanggal.AutoSize = true;
            tanggal.Location = new Point(37, 92);
            tanggal.Margin = new Padding(2, 0, 2, 0);
            tanggal.Name = "tanggal";
            tanggal.Size = new Size(49, 15);
            tanggal.TabIndex = 3;
            tanggal.Text = "Tanggal";
            // 
            // jam
            // 
            jam.AutoSize = true;
            jam.Location = new Point(37, 115);
            jam.Margin = new Padding(2, 0, 2, 0);
            jam.Name = "jam";
            jam.Size = new Size(61, 15);
            jam.TabIndex = 4;
            jam.Text = "Jam mulai";
            // 
            // durasi
            // 
            durasi.AutoSize = true;
            durasi.Location = new Point(37, 137);
            durasi.Margin = new Padding(2, 0, 2, 0);
            durasi.Name = "durasi";
            durasi.Size = new Size(39, 15);
            durasi.TabIndex = 5;
            durasi.Text = "durasi";
            durasi.Click += label6_Click;
            // 
            // harga
            // 
            harga.AutoSize = true;
            harga.Location = new Point(34, 161);
            harga.Margin = new Padding(2, 0, 2, 0);
            harga.Name = "harga";
            harga.Size = new Size(66, 15);
            harga.TabIndex = 6;
            harga.Text = "Total harga";
            // 
            // status
            // 
            status.AutoSize = true;
            status.Location = new Point(34, 181);
            status.Margin = new Padding(2, 0, 2, 0);
            status.Name = "status";
            status.Size = new Size(68, 15);
            status.TabIndex = 7;
            status.Text = "Status Awal";
            // 
            // tNama
            // 
            tNama.Location = new Point(213, 23);
            tNama.Margin = new Padding(2);
            tNama.Name = "tNama";
            tNama.Size = new Size(211, 23);
            tNama.TabIndex = 8;
            tNama.TextChanged += tNama_TextChanged;
            // 
            // tNoHp
            // 
            tNoHp.Location = new Point(213, 45);
            tNoHp.Margin = new Padding(2);
            tNoHp.Name = "tNoHp";
            tNoHp.Size = new Size(211, 23);
            tNoHp.TabIndex = 9;
            tNoHp.TextChanged += tNoHp_TextChanged;
            // 
            // tJam
            // 
            tJam.Location = new Point(213, 115);
            tJam.Margin = new Padding(2);
            tJam.Name = "tJam";
            tJam.Size = new Size(211, 23);
            tJam.TabIndex = 12;
            tJam.TextChanged += tJam_TextChanged;
            // 
            // tDurasi
            // 
            tDurasi.Location = new Point(213, 137);
            tDurasi.Margin = new Padding(2);
            tDurasi.Name = "tDurasi";
            tDurasi.Size = new Size(211, 23);
            tDurasi.TabIndex = 13;
            tDurasi.TextChanged += tDurasi_TextChanged;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Id, gPemesan, gNoHp, gLapangan, gTanggal, gJam, gTotal, gStatus });
            dataGridView1.Location = new Point(18, 214);
            dataGridView1.Margin = new Padding(2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(660, 184);
            dataGridView1.TabIndex = 16;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // lHarga
            // 
            lHarga.AutoSize = true;
            lHarga.Location = new Point(213, 161);
            lHarga.Margin = new Padding(2, 0, 2, 0);
            lHarga.Name = "lHarga";
            lHarga.Size = new Size(38, 15);
            lHarga.TabIndex = 17;
            lHarga.Text = "label1";
            lHarga.Click += lHarga_Click;
            // 
            // lStatus
            // 
            lStatus.AutoSize = true;
            lStatus.Location = new Point(213, 181);
            lStatus.Margin = new Padding(2, 0, 2, 0);
            lStatus.Name = "lStatus";
            lStatus.Size = new Size(38, 15);
            lStatus.TabIndex = 18;
            lStatus.Text = "label2";
            lStatus.Click += lStatus_Click;
            // 
            // pilihTanggal
            // 
            pilihTanggal.Location = new Point(213, 92);
            pilihTanggal.Margin = new Padding(2);
            pilihTanggal.Name = "pilihTanggal";
            pilihTanggal.Size = new Size(211, 23);
            pilihTanggal.TabIndex = 19;
            pilihTanggal.ValueChanged += pilihTanggal_ValueChanged;
            // 
            // cekJadwal
            // 
            cekJadwal.Location = new Point(531, 30);
            cekJadwal.Margin = new Padding(2);
            cekJadwal.Name = "cekJadwal";
            cekJadwal.Size = new Size(78, 20);
            cekJadwal.TabIndex = 20;
            cekJadwal.Text = "Cek Jadwal";
            cekJadwal.UseVisualStyleBackColor = true;
            cekJadwal.Click += cekJadwal_Click;
            // 
            // buatBooking
            // 
            buatBooking.Location = new Point(531, 70);
            buatBooking.Margin = new Padding(2);
            buatBooking.Name = "buatBooking";
            buatBooking.Size = new Size(90, 20);
            buatBooking.TabIndex = 21;
            buatBooking.Text = "Buat Booking";
            buatBooking.UseVisualStyleBackColor = true;
            buatBooking.Click += buatBooking_Click;
            // 
            // reset
            // 
            reset.Location = new Point(531, 112);
            reset.Margin = new Padding(2);
            reset.Name = "reset";
            reset.Size = new Size(78, 20);
            reset.TabIndex = 22;
            reset.Text = "Reset";
            reset.UseVisualStyleBackColor = true;
            reset.Click += reset_Click;
            // 
            // keluar
            // 
            keluar.Location = new Point(531, 149);
            keluar.Margin = new Padding(2);
            keluar.Name = "keluar";
            keluar.Size = new Size(78, 20);
            keluar.TabIndex = 23;
            keluar.Text = "Kembali";
            keluar.UseVisualStyleBackColor = true;
            keluar.Click += keluar_Click;
            // 
            // cmbLapangan
            // 
            cmbLapangan.FormattingEnabled = true;
            cmbLapangan.Location = new Point(213, 69);
            cmbLapangan.Margin = new Padding(2);
            cmbLapangan.Name = "cmbLapangan";
            cmbLapangan.Size = new Size(211, 23);
            cmbLapangan.TabIndex = 24;
            cmbLapangan.SelectedIndexChanged += cmbLapangan_SelectedIndexChanged;
            // 
            // btnRefreshFields
            // 
            btnRefreshFields.Location = new Point(515, 181);
            btnRefreshFields.Name = "btnRefreshFields";
            btnRefreshFields.Size = new Size(117, 23);
            btnRefreshFields.TabIndex = 25;
            btnRefreshFields.Text = "Refresh Lapangan";
            btnRefreshFields.UseVisualStyleBackColor = true;
            btnRefreshFields.Click += btnRefreshFields_Click;
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
            // gNoHp
            // 
            gNoHp.HeaderText = "No. Hp";
            gNoHp.Name = "gNoHp";
            gNoHp.ReadOnly = true;
            // 
            // gLapangan
            // 
            gLapangan.HeaderText = "Lapangan";
            gLapangan.MinimumWidth = 8;
            gLapangan.Name = "gLapangan";
            gLapangan.ReadOnly = true;
            // 
            // gTanggal
            // 
            gTanggal.HeaderText = "Tanggal";
            gTanggal.Name = "gTanggal";
            gTanggal.ReadOnly = true;
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
            // BookingForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(699, 419);
            Controls.Add(btnRefreshFields);
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
            Margin = new Padding(2);
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
        private Label lHarga;
        private Label lStatus;
        private DateTimePicker pilihTanggal;
        private Button cekJadwal;
        private Button buatBooking;
        private Button reset;
        private Button keluar;
        private ComboBox cmbLapangan;
        private Button btnRefreshFields;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn gPemesan;
        private DataGridViewTextBoxColumn gNoHp;
        private DataGridViewTextBoxColumn gLapangan;
        private DataGridViewTextBoxColumn gTanggal;
        private DataGridViewTextBoxColumn gJam;
        private DataGridViewTextBoxColumn gTotal;
        private DataGridViewTextBoxColumn gStatus;
    }
}