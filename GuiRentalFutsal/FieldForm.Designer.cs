namespace GuiRentalFutsal
{
    partial class FieldForm
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            Tx = new Label();
            label5 = new Label();
            bttn_Tambah = new Button();
            bttn_Update = new Button();
            bttn_Hapus = new Button();
            bttn_Reset = new Button();
            Txt_IDLapangan = new TextBox();
            Txt_NamaLapangan = new TextBox();
            Txt_HargaPerJam = new TextBox();
            cmbBox_Status = new ComboBox();
            GridView_Lapangan = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            Nama_Lapangan = new DataGridViewTextBoxColumn();
            Harga_perjam = new DataGridViewTextBoxColumn();
            Aktif = new DataGridViewTextBoxColumn();
            bttn_Kembali = new Button();
            label4 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            ((System.ComponentModel.ISupportInitialize)GridView_Lapangan).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F);
            label1.ImageAlign = ContentAlignment.TopCenter;
            label1.Location = new Point(74, 21);
            label1.Name = "label1";
            label1.Size = new Size(302, 35);
            label1.TabIndex = 0;
            label1.Text = "KELOLA DATA LAPANGAN";
            label1.TextAlign = ContentAlignment.TopCenter;
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(74, 73);
            label2.Name = "label2";
            label2.Size = new Size(97, 20);
            label2.TabIndex = 1;
            label2.Text = "ID Lapangan ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(74, 104);
            label3.Name = "label3";
            label3.Size = new Size(118, 20);
            label3.TabIndex = 2;
            label3.Text = "Nama Lapangan";
            // 
            // Tx
            // 
            Tx.AutoSize = true;
            Tx.Location = new Point(74, 136);
            Tx.Name = "Tx";
            Tx.Size = new Size(82, 20);
            Tx.TabIndex = 3;
            Tx.Text = "Harga/Jam";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(74, 175);
            label5.Name = "label5";
            label5.Size = new Size(84, 20);
            label5.TabIndex = 4;
            label5.Text = "Status Aktif";
            // 
            // bttn_Tambah
            // 
            bttn_Tambah.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            bttn_Tambah.Location = new Point(74, 232);
            bttn_Tambah.Name = "bttn_Tambah";
            bttn_Tambah.Size = new Size(94, 29);
            bttn_Tambah.TabIndex = 5;
            bttn_Tambah.Text = "Tambah";
            bttn_Tambah.UseVisualStyleBackColor = true;
            bttn_Tambah.Click += bttn_Tambah_Click;
            // 
            // bttn_Update
            // 
            bttn_Update.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            bttn_Update.Location = new Point(201, 232);
            bttn_Update.Name = "bttn_Update";
            bttn_Update.Size = new Size(94, 29);
            bttn_Update.TabIndex = 6;
            bttn_Update.Text = "Update";
            bttn_Update.UseVisualStyleBackColor = true;
            bttn_Update.Click += bttn_Update_Click;
            // 
            // bttn_Hapus
            // 
            bttn_Hapus.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            bttn_Hapus.Location = new Point(335, 232);
            bttn_Hapus.Name = "bttn_Hapus";
            bttn_Hapus.Size = new Size(94, 29);
            bttn_Hapus.TabIndex = 7;
            bttn_Hapus.Text = "Hapus";
            bttn_Hapus.UseVisualStyleBackColor = true;
            bttn_Hapus.Click += bttn_Hapus_Click;
            // 
            // bttn_Reset
            // 
            bttn_Reset.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            bttn_Reset.Location = new Point(464, 232);
            bttn_Reset.Name = "bttn_Reset";
            bttn_Reset.Size = new Size(94, 29);
            bttn_Reset.TabIndex = 8;
            bttn_Reset.Text = "Reset";
            bttn_Reset.UseVisualStyleBackColor = true;
            bttn_Reset.Click += bttn_Reset_Click;
            // 
            // Txt_IDLapangan
            // 
            Txt_IDLapangan.Location = new Point(272, 73);
            Txt_IDLapangan.Name = "Txt_IDLapangan";
            Txt_IDLapangan.Size = new Size(167, 27);
            Txt_IDLapangan.TabIndex = 9;
            Txt_IDLapangan.TextChanged += Txt_IDLapangan_TextChanged;
            // 
            // Txt_NamaLapangan
            // 
            Txt_NamaLapangan.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Txt_NamaLapangan.Location = new Point(272, 106);
            Txt_NamaLapangan.Name = "Txt_NamaLapangan";
            Txt_NamaLapangan.Size = new Size(167, 27);
            Txt_NamaLapangan.TabIndex = 10;
            Txt_NamaLapangan.TextChanged += Txt_NamaLapangan_TextChanged;
            // 
            // Txt_HargaPerJam
            // 
            Txt_HargaPerJam.Location = new Point(272, 139);
            Txt_HargaPerJam.Name = "Txt_HargaPerJam";
            Txt_HargaPerJam.Size = new Size(167, 27);
            Txt_HargaPerJam.TabIndex = 11;
            Txt_HargaPerJam.TextChanged += Txt_HargaPerJam_TextChanged;
            // 
            // cmbBox_Status
            // 
            cmbBox_Status.FormattingEnabled = true;
            cmbBox_Status.Location = new Point(272, 172);
            cmbBox_Status.Name = "cmbBox_Status";
            cmbBox_Status.Size = new Size(167, 28);
            cmbBox_Status.TabIndex = 12;
            cmbBox_Status.SelectedIndexChanged += cmbBox_Status_SelectedIndexChanged;
            // 
            // GridView_Lapangan
            // 
            GridView_Lapangan.AllowUserToAddRows = false;
            GridView_Lapangan.AllowUserToDeleteRows = false;
            GridView_Lapangan.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            GridView_Lapangan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            GridView_Lapangan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GridView_Lapangan.Columns.AddRange(new DataGridViewColumn[] { ID, Nama_Lapangan, Harga_perjam, Aktif });
            GridView_Lapangan.Location = new Point(29, 284);
            GridView_Lapangan.Name = "GridView_Lapangan";
            GridView_Lapangan.ReadOnly = true;
            GridView_Lapangan.RowHeadersWidth = 51;
            GridView_Lapangan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            GridView_Lapangan.Size = new Size(747, 205);
            GridView_Lapangan.TabIndex = 13;
            GridView_Lapangan.CellContentClick += GridView_Lapangan_CellContentClick;
            // 
            // ID
            // 
            ID.HeaderText = "ID";
            ID.MinimumWidth = 6;
            ID.Name = "ID";
            ID.ReadOnly = true;
            // 
            // Nama_Lapangan
            // 
            Nama_Lapangan.HeaderText = "Nama Lapangan";
            Nama_Lapangan.MinimumWidth = 6;
            Nama_Lapangan.Name = "Nama_Lapangan";
            Nama_Lapangan.ReadOnly = true;
            // 
            // Harga_perjam
            // 
            Harga_perjam.HeaderText = "Harga/Jam";
            Harga_perjam.MinimumWidth = 6;
            Harga_perjam.Name = "Harga_perjam";
            Harga_perjam.ReadOnly = true;
            // 
            // Aktif
            // 
            Aktif.HeaderText = "Aktif";
            Aktif.MinimumWidth = 6;
            Aktif.Name = "Aktif";
            Aktif.ReadOnly = true;
            // 
            // bttn_Kembali
            // 
            bttn_Kembali.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            bttn_Kembali.Location = new Point(41, 517);
            bttn_Kembali.Name = "bttn_Kembali";
            bttn_Kembali.Size = new Size(94, 29);
            bttn_Kembali.TabIndex = 14;
            bttn_Kembali.Text = "Kembali";
            bttn_Kembali.UseVisualStyleBackColor = true;
            bttn_Kembali.Click += bttn_Kembali_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(216, 73);
            label4.Name = "label4";
            label4.Size = new Size(12, 20);
            label4.TabIndex = 15;
            label4.Text = ":";
            label4.Click += label4_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(216, 109);
            label6.Name = "label6";
            label6.Size = new Size(12, 20);
            label6.TabIndex = 16;
            label6.Text = ":";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(216, 142);
            label7.Name = "label7";
            label7.Size = new Size(12, 20);
            label7.TabIndex = 17;
            label7.Text = ":";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(216, 175);
            label8.Name = "label8";
            label8.Size = new Size(12, 20);
            label8.TabIndex = 18;
            label8.Text = ":";
            // 
            // FieldForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 563);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(bttn_Kembali);
            Controls.Add(GridView_Lapangan);
            Controls.Add(cmbBox_Status);
            Controls.Add(Txt_HargaPerJam);
            Controls.Add(Txt_NamaLapangan);
            Controls.Add(Txt_IDLapangan);
            Controls.Add(bttn_Reset);
            Controls.Add(bttn_Hapus);
            Controls.Add(bttn_Update);
            Controls.Add(bttn_Tambah);
            Controls.Add(label5);
            Controls.Add(Tx);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.Sizable;
            MaximizeBox = true;
            MinimumSize = new Size(720, 520);
            Name = "FieldForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FieldForm";
            Load += FieldForm_Load;
            ((System.ComponentModel.ISupportInitialize)GridView_Lapangan).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label Tx;
        private Label label5;
        private Button bttn_Tambah;
        private Button bttn_Update;
        private Button bttn_Hapus;
        private Button bttn_Reset;
        private TextBox Txt_IDLapangan;
        private TextBox Txt_NamaLapangan;
        private TextBox Txt_HargaPerJam;
        private ComboBox cmbBox_Status;
        private DataGridView GridView_Lapangan;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn Nama_Lapangan;
        private DataGridViewTextBoxColumn Harga_perjam;
        private DataGridViewTextBoxColumn Aktif;
        private Button bttn_Kembali;
        private Label label4;
        private Label label6;
        private Label label7;
        private Label label8;
    }
}
