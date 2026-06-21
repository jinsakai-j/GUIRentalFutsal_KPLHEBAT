namespace GuiRentalFutsal
{
    partial class DashboardForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            btnField = new Button();
            btnBooking = new Button();
            btnSchedule = new Button();
            btnPayment = new Button();
            btnReport = new Button();
            btnExit = new Button();
            label3 = new Label();
            tableLayoutPanelMenu = new TableLayoutPanel();
            tableLayoutPanelMenu.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 20F);
            label1.Location = new Point(201, 33);
            label1.Name = "label1";
            label1.Size = new Size(352, 31);
            label1.TabIndex = 0;
            label1.Text = "FUTSAL RENTAL SYSTEM";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F);
            label2.Location = new Point(220, 74);
            label2.Name = "label2";
            label2.Size = new Size(317, 28);
            label2.TabIndex = 1;
            label2.Text = "Sistem Penyewaan Lapangan Futsal";
            // 
            // btnField
            // 
            btnField.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btnField.Location = new Point(23, 16);
            btnField.Name = "btnField";
            btnField.Size = new Size(274, 36);
            btnField.TabIndex = 2;
            btnField.Text = "Kelola Lapangan";
            btnField.UseVisualStyleBackColor = true;
            btnField.Click += btnField_Click;
            // 
            // btnBooking
            // 
            btnBooking.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btnBooking.Location = new Point(323, 16);
            btnBooking.Name = "btnBooking";
            btnBooking.Size = new Size(274, 36);
            btnBooking.TabIndex = 3;
            btnBooking.Text = "Buat Booking";
            btnBooking.UseVisualStyleBackColor = true;
            btnBooking.Click += btnBooking_Click;
            // 
            // btnSchedule
            // 
            btnSchedule.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btnSchedule.Location = new Point(23, 85);
            btnSchedule.Name = "btnSchedule";
            btnSchedule.Size = new Size(274, 36);
            btnSchedule.TabIndex = 4;
            btnSchedule.Text = "Cek Jadwal";
            btnSchedule.UseVisualStyleBackColor = true;
            btnSchedule.Click += btnSchedule_Click;
            // 
            // btnPayment
            // 
            btnPayment.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btnPayment.Location = new Point(323, 85);
            btnPayment.Name = "btnPayment";
            btnPayment.Size = new Size(274, 36);
            btnPayment.TabIndex = 5;
            btnPayment.Text = "Pembayaran";
            btnPayment.UseVisualStyleBackColor = true;
            btnPayment.Click += btnPayment_Click;
            // 
            // btnReport
            // 
            btnReport.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btnReport.Location = new Point(23, 154);
            btnReport.Name = "btnReport";
            btnReport.Size = new Size(274, 36);
            btnReport.TabIndex = 6;
            btnReport.Text = "Laporan";
            btnReport.UseVisualStyleBackColor = true;
            btnReport.Click += btnReport_Click;
            // 
            // btnExit
            // 
            btnExit.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btnExit.Location = new Point(323, 154);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(274, 36);
            btnExit.TabIndex = 7;
            btnExit.Text = "Keluar";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F);
            label3.Location = new Point(59, 386);
            label3.Name = "label3";
            label3.Size = new Size(76, 19);
            label3.TabIndex = 8;
            label3.Text = "KPLHEBAT ";
            // 
            // tableLayoutPanelMenu
            // 
            tableLayoutPanelMenu.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanelMenu.ColumnCount = 2;
            tableLayoutPanelMenu.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanelMenu.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanelMenu.Controls.Add(btnField, 0, 0);
            tableLayoutPanelMenu.Controls.Add(btnBooking, 1, 0);
            tableLayoutPanelMenu.Controls.Add(btnSchedule, 0, 1);
            tableLayoutPanelMenu.Controls.Add(btnPayment, 1, 1);
            tableLayoutPanelMenu.Controls.Add(btnReport, 0, 2);
            tableLayoutPanelMenu.Controls.Add(btnExit, 1, 2);
            tableLayoutPanelMenu.Location = new Point(90, 140);
            tableLayoutPanelMenu.Name = "tableLayoutPanelMenu";
            tableLayoutPanelMenu.Padding = new Padding(20, 0, 20, 0);
            tableLayoutPanelMenu.RowCount = 3;
            tableLayoutPanelMenu.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanelMenu.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanelMenu.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanelMenu.Size = new Size(620, 208);
            tableLayoutPanelMenu.TabIndex = 9;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(tableLayoutPanelMenu);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.Sizable;
            MaximizeBox = true;
            MinimumSize = new Size(640, 420);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            tableLayoutPanelMenu.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Button btnField;
        private Button btnBooking;
        private Button btnSchedule;
        private Button btnPayment;
        private Button btnReport;
        private Button btnExit;
        private Label label3;
        private TableLayoutPanel tableLayoutPanelMenu;
    }
}
