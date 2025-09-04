namespace Lotus_Care.CommonForms
{
    partial class Patients
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
            this.PatientsDataGridView = new System.Windows.Forms.DataGridView();
            this.AddBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PatientsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // PatientsDataGridView
            // 
            this.PatientsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PatientsDataGridView.Location = new System.Drawing.Point(47, 67);
            this.PatientsDataGridView.Name = "PatientsDataGridView";
            this.PatientsDataGridView.RowHeadersWidth = 51;
            this.PatientsDataGridView.RowTemplate.Height = 24;
            this.PatientsDataGridView.Size = new System.Drawing.Size(683, 250);
            this.PatientsDataGridView.TabIndex = 0;
            this.PatientsDataGridView.Click += new System.EventHandler(this.PatientsDataGridView_Click);
            // 
            // AddBtn
            // 
            this.AddBtn.Location = new System.Drawing.Point(284, 358);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(188, 52);
            this.AddBtn.TabIndex = 1;
            this.AddBtn.Text = "New Patient";
            this.AddBtn.UseVisualStyleBackColor = true;
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // Patients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.AddBtn);
            this.Controls.Add(this.PatientsDataGridView);
            this.Name = "Patients";
            this.Text = "Patients";
            this.Load += new System.EventHandler(this.Patients_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PatientsDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView PatientsDataGridView;
        private System.Windows.Forms.Button AddBtn;
    }
}