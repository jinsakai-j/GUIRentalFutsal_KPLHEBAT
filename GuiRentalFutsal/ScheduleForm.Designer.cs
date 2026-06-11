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
            cmbField = new ComboBox();
            dtpScheduleDate = new DateTimePicker();
            cmbStartTime = new ComboBox();
            cmbDuration = new ComboBox();
            btnCheckAvailability = new Button();
            lblAvailabilityResult = new Label();
            dgvSchedule = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colField = new DataGridViewTextBoxColumn();
            colStartTime = new DataGridViewTextBoxColumn();
            colEndTime = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            btnBack = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvSchedule).BeginInit();
            SuspendLayout();
            // 
            // cmbField
            // 
            cmbField.FormattingEnabled = true;
            cmbField.Items.AddRange(new object[] { "Lapangan A Vinyl", "Lapangan B Sintetis", "Lapangan C Rumput" });
            cmbField.Location = new Point(115, 55);
            cmbField.Name = "cmbField";
            cmbField.Size = new Size(250, 28);
            cmbField.TabIndex = 0;
            cmbField.SelectedIndexChanged += cmbField_SelectedIndexChanged;
            // 
            // dtpScheduleDate
            // 
            dtpScheduleDate.Location = new Point(115, 89);
            dtpScheduleDate.Name = "dtpScheduleDate";
            dtpScheduleDate.Size = new Size(250, 27);
            dtpScheduleDate.TabIndex = 1;
            dtpScheduleDate.ValueChanged += dtpScheduleDate_ValueChanged;
            // 
            // cmbStartTime
            // 
            cmbStartTime.FormattingEnabled = true;
            cmbStartTime.Items.AddRange(new object[] { "08:00", "09:00", "10:00", "11:00", "12:00", "13:00", "14:00", "15:00", "16:00", "17:00", "18:00", "19:00", "20:00", "21:00", "22:00" });
            cmbStartTime.Location = new Point(115, 122);
            cmbStartTime.Name = "cmbStartTime";
            cmbStartTime.Size = new Size(250, 28);
            cmbStartTime.TabIndex = 2;
            cmbStartTime.SelectedIndexChanged += cmbStartTime_SelectedIndexChanged;
            // 
            // cmbDuration
            // 
            cmbDuration.FormattingEnabled = true;
            cmbDuration.Items.AddRange(new object[] { "1 Jam", "2 Jam", "3 Jam", "4 Jam ", "5 Jam", "6 Jam", "Full Day" });
            cmbDuration.Location = new Point(115, 156);
            cmbDuration.Name = "cmbDuration";
            cmbDuration.Size = new Size(250, 28);
            cmbDuration.TabIndex = 3;
            cmbDuration.SelectedIndexChanged += cmbDuration_SelectedIndexChanged;
            // 
            // btnCheckAvailability
            // 
            btnCheckAvailability.Location = new Point(115, 222);
            btnCheckAvailability.Name = "btnCheckAvailability";
            btnCheckAvailability.Size = new Size(250, 29);
            btnCheckAvailability.TabIndex = 4;
            btnCheckAvailability.Text = "Cek Ketersediaan";
            btnCheckAvailability.UseVisualStyleBackColor = true;
            btnCheckAvailability.Click += btnCheckAvailability_Click;
            // 
            // lblAvailabilityResult
            // 
            lblAvailabilityResult.BorderStyle = BorderStyle.FixedSingle;
            lblAvailabilityResult.Location = new Point(12, 319);
            lblAvailabilityResult.Name = "lblAvailabilityResult";
            lblAvailabilityResult.Size = new Size(353, 25);
            lblAvailabilityResult.TabIndex = 5;
            lblAvailabilityResult.Text = "-";
            lblAvailabilityResult.Click += lblAvailabilityResult_Click;
            // 
            // dgvSchedule
            // 
            dgvSchedule.AllowUserToAddRows = false;
            dgvSchedule.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSchedule.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSchedule.Columns.AddRange(new DataGridViewColumn[] { colId, colField, colStartTime, colEndTime, colStatus });
            dgvSchedule.Location = new Point(371, 32);
            dgvSchedule.Name = "dgvSchedule";
            dgvSchedule.ReadOnly = true;
            dgvSchedule.RowHeadersWidth = 51;
            dgvSchedule.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSchedule.Size = new Size(679, 406);
            dgvSchedule.TabIndex = 6;
            dgvSchedule.CellContentClick += dgvSchedule_CellContentClick;
            // 
            // colId
            // 
            colId.HeaderText = "ID";
            colId.MinimumWidth = 6;
            colId.Name = "colId";
            colId.ReadOnly = true;
            // 
            // colField
            // 
            colField.HeaderText = "Lapangan";
            colField.MinimumWidth = 6;
            colField.Name = "colField";
            colField.ReadOnly = true;
            // 
            // colStartTime
            // 
            colStartTime.HeaderText = "Jam Mulai";
            colStartTime.MinimumWidth = 6;
            colStartTime.Name = "colStartTime";
            colStartTime.ReadOnly = true;
            // 
            // colEndTime
            // 
            colEndTime.HeaderText = "Jam Selesai";
            colEndTime.MinimumWidth = 6;
            colEndTime.Name = "colEndTime";
            colEndTime.ReadOnly = true;
            // 
            // colStatus
            // 
            colStatus.HeaderText = "Status";
            colStatus.MinimumWidth = 6;
            colStatus.Name = "colStatus";
            colStatus.ReadOnly = true;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(10, 407);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(94, 29);
            btnBack.TabIndex = 7;
            btnBack.Text = "Kembali";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 58);
            label1.Name = "label1";
            label1.Size = new Size(97, 20);
            label1.TabIndex = 8;
            label1.Text = "Lapangan     :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(10, 94);
            label2.Name = "label2";
            label2.Size = new Size(96, 20);
            label2.TabIndex = 9;
            label2.Text = "Tanggal        :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(10, 125);
            label3.Name = "label3";
            label3.Size = new Size(95, 20);
            label3.TabIndex = 10;
            label3.Text = "Jam Mulai    :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(10, 159);
            label4.Name = "label4";
            label4.Size = new Size(94, 20);
            label4.TabIndex = 11;
            label4.Text = "Durasi          :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(10, 299);
            label5.Name = "label5";
            label5.Size = new Size(77, 20);
            label5.TabIndex = 12;
            label5.Text = "Hasil Cek :\n";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(596, 9);
            label6.Name = "label6";
            label6.Size = new Size(234, 20);
            label6.TabIndex = 13;
            label6.Text = "Jadwal Booking pada Tanggal Ini :\n";
            // 
            // ScheduleForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1056, 448);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnBack);
            Controls.Add(dgvSchedule);
            Controls.Add(lblAvailabilityResult);
            Controls.Add(btnCheckAvailability);
            Controls.Add(cmbDuration);
            Controls.Add(cmbStartTime);
            Controls.Add(dtpScheduleDate);
            Controls.Add(cmbField);
            Name = "ScheduleForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cek Jadwal Lapangan";
            ((System.ComponentModel.ISupportInitialize)dgvSchedule).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbField;
        private DateTimePicker dtpScheduleDate;
        private ComboBox cmbStartTime;
        private ComboBox cmbDuration;
        private Button btnCheckAvailability;
        private Label lblAvailabilityResult;
        private DataGridView dgvSchedule;
        private Button btnBack;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colField;
        private DataGridViewTextBoxColumn colStartTime;
        private DataGridViewTextBoxColumn colEndTime;
        private DataGridViewTextBoxColumn colStatus;
    }
}