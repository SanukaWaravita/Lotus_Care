namespace Lotus_Care.Administrator
{
    partial class AdministratorDashboard
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
            this.UsersBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.PatientsBtn = new System.Windows.Forms.Button();
            this.AssignmentBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.AppointmentBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // UsersBtn
            // 
            this.UsersBtn.Location = new System.Drawing.Point(241, 53);
            this.UsersBtn.Name = "UsersBtn";
            this.UsersBtn.Size = new System.Drawing.Size(88, 53);
            this.UsersBtn.TabIndex = 0;
            this.UsersBtn.UseVisualStyleBackColor = true;
            this.UsersBtn.Click += new System.EventHandler(this.UsersBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(94, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Users";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(94, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Patients";
            // 
            // PatientsBtn
            // 
            this.PatientsBtn.Location = new System.Drawing.Point(241, 117);
            this.PatientsBtn.Name = "PatientsBtn";
            this.PatientsBtn.Size = new System.Drawing.Size(88, 53);
            this.PatientsBtn.TabIndex = 0;
            this.PatientsBtn.UseVisualStyleBackColor = true;
            // 
            // AssignmentBtn
            // 
            this.AssignmentBtn.Location = new System.Drawing.Point(241, 190);
            this.AssignmentBtn.Name = "AssignmentBtn";
            this.AssignmentBtn.Size = new System.Drawing.Size(88, 53);
            this.AssignmentBtn.TabIndex = 0;
            this.AssignmentBtn.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(94, 199);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Assignment";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(94, 293);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "Appointments";
            // 
            // AppointmentBtn
            // 
            this.AppointmentBtn.Location = new System.Drawing.Point(241, 275);
            this.AppointmentBtn.Name = "AppointmentBtn";
            this.AppointmentBtn.Size = new System.Drawing.Size(88, 53);
            this.AppointmentBtn.TabIndex = 0;
            this.AppointmentBtn.UseVisualStyleBackColor = true;
            // 
            // AdministratorDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AppointmentBtn);
            this.Controls.Add(this.AssignmentBtn);
            this.Controls.Add(this.PatientsBtn);
            this.Controls.Add(this.UsersBtn);
            this.Name = "AdministratorDashboard";
            this.Text = "AdministratorDashboard";
            this.Load += new System.EventHandler(this.AdministratorDashboard_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button UsersBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button PatientsBtn;
        private System.Windows.Forms.Button AssignmentBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button AppointmentBtn;
    }
}