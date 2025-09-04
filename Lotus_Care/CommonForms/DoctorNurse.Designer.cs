namespace Lotus_Care.CommonForms
{
    partial class DoctorNurse
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
            this.label1 = new System.Windows.Forms.Label();
            this.PatientBtn = new System.Windows.Forms.Button();
            this.DiagnosisBtn = new System.Windows.Forms.Button();
            this.PrescriptionBtn = new System.Windows.Forms.Button();
            this.PatientProgressBtn = new System.Windows.Forms.Button();
            this.LogoutBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // PatientBtn
            // 
            this.PatientBtn.Location = new System.Drawing.Point(118, 76);
            this.PatientBtn.Name = "PatientBtn";
            this.PatientBtn.Size = new System.Drawing.Size(141, 65);
            this.PatientBtn.TabIndex = 1;
            this.PatientBtn.Text = "Patients";
            this.PatientBtn.UseVisualStyleBackColor = true;
            this.PatientBtn.Click += new System.EventHandler(this.PatientBtn_Click);
            // 
            // DiagnosisBtn
            // 
            this.DiagnosisBtn.Location = new System.Drawing.Point(118, 162);
            this.DiagnosisBtn.Name = "DiagnosisBtn";
            this.DiagnosisBtn.Size = new System.Drawing.Size(141, 65);
            this.DiagnosisBtn.TabIndex = 1;
            this.DiagnosisBtn.Text = "Diagnosis";
            this.DiagnosisBtn.UseVisualStyleBackColor = true;
            this.DiagnosisBtn.Click += new System.EventHandler(this.DiagnosisBtn_Click);
            // 
            // PrescriptionBtn
            // 
            this.PrescriptionBtn.Location = new System.Drawing.Point(118, 252);
            this.PrescriptionBtn.Name = "PrescriptionBtn";
            this.PrescriptionBtn.Size = new System.Drawing.Size(141, 65);
            this.PrescriptionBtn.TabIndex = 1;
            this.PrescriptionBtn.Text = "Prescription";
            this.PrescriptionBtn.UseVisualStyleBackColor = true;
            this.PrescriptionBtn.Click += new System.EventHandler(this.PrescriptionBtn_Click);
            // 
            // PatientProgressBtn
            // 
            this.PatientProgressBtn.Location = new System.Drawing.Point(118, 339);
            this.PatientProgressBtn.Name = "PatientProgressBtn";
            this.PatientProgressBtn.Size = new System.Drawing.Size(141, 65);
            this.PatientProgressBtn.TabIndex = 1;
            this.PatientProgressBtn.Text = "PatientProgress";
            this.PatientProgressBtn.UseVisualStyleBackColor = true;
            this.PatientProgressBtn.Click += new System.EventHandler(this.PatientProgressBtn_Click);
            // 
            // LogoutBtn
            // 
            this.LogoutBtn.Location = new System.Drawing.Point(536, 339);
            this.LogoutBtn.Name = "LogoutBtn";
            this.LogoutBtn.Size = new System.Drawing.Size(120, 65);
            this.LogoutBtn.TabIndex = 2;
            this.LogoutBtn.Text = "Logout";
            this.LogoutBtn.UseVisualStyleBackColor = true;
            this.LogoutBtn.Click += new System.EventHandler(this.LogoutBtn_Click);
            // 
            // DoctorNurse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.LogoutBtn);
            this.Controls.Add(this.PatientProgressBtn);
            this.Controls.Add(this.PrescriptionBtn);
            this.Controls.Add(this.DiagnosisBtn);
            this.Controls.Add(this.PatientBtn);
            this.Controls.Add(this.label1);
            this.Name = "DoctorNurse";
            this.Text = "DoctorNurse";
            this.Load += new System.EventHandler(this.DoctorNurse_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button PatientBtn;
        private System.Windows.Forms.Button DiagnosisBtn;
        private System.Windows.Forms.Button PrescriptionBtn;
        private System.Windows.Forms.Button PatientProgressBtn;
        private System.Windows.Forms.Button LogoutBtn;
    }
}