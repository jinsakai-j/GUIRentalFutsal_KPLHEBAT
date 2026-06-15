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
            btnField.Anchor = AnchorStyles.None;
            btnField.AutoSize = true;
            btnField.Location = new Point(135, 163);
            btnField.Name = "btnField";
            btnField.Size = new Size(163, 36);
            btnField.TabIndex = 2;
            btnField.Text = "Kelola Lapangan";
            btnField.UseVisualStyleBackColor = true;
            btnField.Click += btnField_Click;
            // 
            // btnBooking
            // 
            btnBooking.Anchor = AnchorStyles.None;
            btnBooking.AutoSize = true;
            btnBooking.Location = new Point(454, 163);
            btnBooking.Name = "btnBooking";
            btnBooking.Size = new Size(163, 36);
            btnBooking.TabIndex = 3;
            btnBooking.Text = "Buat Booking";
            btnBooking.UseVisualStyleBackColor = true;
            btnBooking.Click += btnBooking_Click;
            // 
            // btnSchedule
            // 
            btnSchedule.Anchor = AnchorStyles.None;
            btnSchedule.AutoSize = true;
            btnSchedule.Location = new Point(135, 226);
            btnSchedule.Name = "btnSchedule";
            btnSchedule.Size = new Size(163, 36);
            btnSchedule.TabIndex = 4;
            btnSchedule.Text = "Cek Jadwal";
            btnSchedule.UseVisualStyleBackColor = true;
            btnSchedule.Click += btnSchedule_Click;
            // 
            // btnPayment
            // 
            btnPayment.Anchor = AnchorStyles.None;
            btnPayment.AutoSize = true;
            btnPayment.Location = new Point(454, 226);
            btnPayment.Name = "btnPayment";
            btnPayment.Size = new Size(163, 36);
            btnPayment.TabIndex = 5;
            btnPayment.Text = "Pembayaran";
            btnPayment.UseVisualStyleBackColor = true;
            btnPayment.Click += btnPayment_Click;
            // 
            // btnReport
            // 
            btnReport.Anchor = AnchorStyles.None;
            btnReport.AutoSize = true;
            btnReport.Location = new Point(135, 284);
            btnReport.Name = "btnReport";
            btnReport.Size = new Size(163, 36);
            btnReport.TabIndex = 6;
            btnReport.Text = "Laporan";
            btnReport.UseVisualStyleBackColor = true;
            btnReport.Click += btnReport_Click;
            // 
            // btnExit
            // 
            btnExit.Anchor = AnchorStyles.None;
            btnExit.AutoSize = true;
            btnExit.Location = new Point(454, 284);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(163, 36);
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
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(btnExit);
            Controls.Add(btnReport);
            Controls.Add(btnPayment);
            Controls.Add(btnSchedule);
            Controls.Add(btnBooking);
            Controls.Add(btnField);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
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
    }
}
