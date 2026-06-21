namespace GuiRentalFutsal
{
    partial class ScheduleForm
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
            cmbLapangan = new ComboBox();
            dtpTanggal = new DateTimePicker();
            cmbJamMulai = new ComboBox();
            cmbDurasi = new ComboBox();
            btnCekJadwal = new Button();
            btnRefresh = new Button();
            lblStatus = new Label();
            dgvSchedule = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colTanggal = new DataGridViewTextBoxColumn();
            colLapangan = new DataGridViewTextBoxColumn();
            colJam = new DataGridViewTextBoxColumn();
            colDurasi = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            btnKembali = new Button();
            lblLapangan = new Label();
            lblTanggal = new Label();
            lblJamMulai = new Label();
            lblDurasi = new Label();
            lblHasilCek = new Label();
            lblJadwal = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvSchedule).BeginInit();
            SuspendLayout();
            // 
            // cmbLapangan
            // 
            cmbLapangan.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbLapangan.FormattingEnabled = true;
            cmbLapangan.Location = new Point(115, 55);
            cmbLapangan.Name = "cmbLapangan";
            cmbLapangan.Size = new Size(250, 28);
            cmbLapangan.TabIndex = 0;
            cmbLapangan.SelectedIndexChanged += cmbLapangan_SelectedIndexChanged;
            // 
            // dtpTanggal
            // 
            dtpTanggal.Format = DateTimePickerFormat.Short;
            dtpTanggal.Location = new Point(115, 89);
            dtpTanggal.Name = "dtpTanggal";
            dtpTanggal.Size = new Size(250, 27);
            dtpTanggal.TabIndex = 1;
            dtpTanggal.ValueChanged += dtpTanggal_ValueChanged;
            // 
            // cmbJamMulai
            // 
            cmbJamMulai.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbJamMulai.FormattingEnabled = true;
            cmbJamMulai.Location = new Point(115, 122);
            cmbJamMulai.Name = "cmbJamMulai";
            cmbJamMulai.Size = new Size(250, 28);
            cmbJamMulai.TabIndex = 2;
            // 
            // cmbDurasi
            // 
            cmbDurasi.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDurasi.FormattingEnabled = true;
            cmbDurasi.Location = new Point(115, 156);
            cmbDurasi.Name = "cmbDurasi";
            cmbDurasi.Size = new Size(250, 28);
            cmbDurasi.TabIndex = 3;
            cmbDurasi.SelectedIndexChanged += cmbDurasi_SelectedIndexChanged;
            // 
            // btnCekJadwal
            // 
            btnCekJadwal.Location = new Point(115, 222);
            btnCekJadwal.Name = "btnCekJadwal";
            btnCekJadwal.Size = new Size(250, 29);
            btnCekJadwal.TabIndex = 4;
            btnCekJadwal.Text = "Cek Ketersediaan";
            btnCekJadwal.UseVisualStyleBackColor = true;
            btnCekJadwal.Click += btnCekJadwal_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(115, 257);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(250, 29);
            btnRefresh.TabIndex = 5;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // lblStatus
            // 
            lblStatus.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            lblStatus.BorderStyle = BorderStyle.FixedSingle;
            lblStatus.Location = new Point(12, 319);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(353, 25);
            lblStatus.TabIndex = 6;
            lblStatus.Text = "-";
            lblStatus.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dgvSchedule
            // 
            dgvSchedule.AllowUserToAddRows = false;
            dgvSchedule.AllowUserToDeleteRows = false;
            dgvSchedule.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvSchedule.AutoGenerateColumns = false;
            dgvSchedule.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSchedule.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSchedule.Columns.AddRange(new DataGridViewColumn[] { colId, colTanggal, colLapangan, colJam, colDurasi, colStatus });
            dgvSchedule.Location = new Point(371, 32);
            dgvSchedule.MultiSelect = false;
            dgvSchedule.Name = "dgvSchedule";
            dgvSchedule.ReadOnly = true;
            dgvSchedule.RowHeadersWidth = 51;
            dgvSchedule.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSchedule.Size = new Size(679, 406);
            dgvSchedule.TabIndex = 7;
            // 
            // colId
            // 
            colId.HeaderText = "ID";
            colId.MinimumWidth = 6;
            colId.Name = "colId";
            colId.ReadOnly = true;
            // 
            // colTanggal
            // 
            colTanggal.HeaderText = "Tanggal";
            colTanggal.MinimumWidth = 6;
            colTanggal.Name = "colTanggal";
            colTanggal.ReadOnly = true;
            // 
            // colLapangan
            // 
            colLapangan.HeaderText = "Lapangan";
            colLapangan.MinimumWidth = 6;
            colLapangan.Name = "colLapangan";
            colLapangan.ReadOnly = true;
            // 
            // colJam
            // 
            colJam.HeaderText = "Jam";
            colJam.MinimumWidth = 6;
            colJam.Name = "colJam";
            colJam.ReadOnly = true;
            // 
            // colDurasi
            // 
            colDurasi.HeaderText = "Durasi";
            colDurasi.MinimumWidth = 6;
            colDurasi.Name = "colDurasi";
            colDurasi.ReadOnly = true;
            // 
            // colStatus
            // 
            colStatus.HeaderText = "Status";
            colStatus.MinimumWidth = 6;
            colStatus.Name = "colStatus";
            colStatus.ReadOnly = true;
            // 
            // btnKembali
            // 
            btnKembali.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnKembali.Location = new Point(10, 407);
            btnKembali.Name = "btnKembali";
            btnKembali.Size = new Size(94, 29);
            btnKembali.TabIndex = 8;
            btnKembali.Text = "Kembali";
            btnKembali.UseVisualStyleBackColor = true;
            btnKembali.Click += btnKembali_Click;
            // 
            // lblLapangan
            // 
            lblLapangan.AutoSize = true;
            lblLapangan.Location = new Point(10, 58);
            lblLapangan.Name = "lblLapangan";
            lblLapangan.Size = new Size(97, 20);
            lblLapangan.TabIndex = 9;
            lblLapangan.Text = "Lapangan     :";
            // 
            // lblTanggal
            // 
            lblTanggal.AutoSize = true;
            lblTanggal.Location = new Point(10, 94);
            lblTanggal.Name = "lblTanggal";
            lblTanggal.Size = new Size(96, 20);
            lblTanggal.TabIndex = 10;
            lblTanggal.Text = "Tanggal        :";
            // 
            // lblJamMulai
            // 
            lblJamMulai.AutoSize = true;
            lblJamMulai.Location = new Point(10, 125);
            lblJamMulai.Name = "lblJamMulai";
            lblJamMulai.Size = new Size(95, 20);
            lblJamMulai.TabIndex = 11;
            lblJamMulai.Text = "Jam Mulai    :";
            // 
            // lblDurasi
            // 
            lblDurasi.AutoSize = true;
            lblDurasi.Location = new Point(10, 159);
            lblDurasi.Name = "lblDurasi";
            lblDurasi.Size = new Size(94, 20);
            lblDurasi.TabIndex = 12;
            lblDurasi.Text = "Durasi          :";
            // 
            // lblHasilCek
            // 
            lblHasilCek.AutoSize = true;
            lblHasilCek.Location = new Point(10, 299);
            lblHasilCek.Name = "lblHasilCek";
            lblHasilCek.Size = new Size(77, 20);
            lblHasilCek.TabIndex = 13;
            lblHasilCek.Text = "Hasil Cek :";
            // 
            // lblJadwal
            // 
            lblJadwal.Anchor = AnchorStyles.Top;
            lblJadwal.AutoSize = true;
            lblJadwal.Location = new Point(596, 9);
            lblJadwal.Name = "lblJadwal";
            lblJadwal.Size = new Size(234, 20);
            lblJadwal.TabIndex = 14;
            lblJadwal.Text = "Jadwal Booking pada Tanggal Ini :";
            // 
            // ScheduleForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1056, 448);
            Controls.Add(lblJadwal);
            Controls.Add(lblHasilCek);
            Controls.Add(lblDurasi);
            Controls.Add(lblJamMulai);
            Controls.Add(lblTanggal);
            Controls.Add(lblLapangan);
            Controls.Add(btnKembali);
            Controls.Add(dgvSchedule);
            Controls.Add(lblStatus);
            Controls.Add(btnRefresh);
            Controls.Add(btnCekJadwal);
            Controls.Add(cmbDurasi);
            Controls.Add(cmbJamMulai);
            Controls.Add(dtpTanggal);
            Controls.Add(cmbLapangan);
            FormBorderStyle = FormBorderStyle.Sizable;
            MaximizeBox = true;
            MinimumSize = new Size(900, 430);
            Name = "ScheduleForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cek Jadwal Lapangan";
            Load += ScheduleForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvSchedule).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbLapangan;
        private DateTimePicker dtpTanggal;
        private ComboBox cmbJamMulai;
        private ComboBox cmbDurasi;
        private Button btnCekJadwal;
        private Button btnRefresh;
        private Label lblStatus;
        private DataGridView dgvSchedule;
        private Button btnKembali;
        private Label lblLapangan;
        private Label lblTanggal;
        private Label lblJamMulai;
        private Label lblDurasi;
        private Label lblHasilCek;
        private Label lblJadwal;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colTanggal;
        private DataGridViewTextBoxColumn colLapangan;
        private DataGridViewTextBoxColumn colJam;
        private DataGridViewTextBoxColumn colDurasi;
        private DataGridViewTextBoxColumn colStatus;
    }
}
