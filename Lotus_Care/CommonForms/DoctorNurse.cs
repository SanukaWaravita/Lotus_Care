using Lotus_Care.Administrator;
using Lotus_Care.CommonCode;
using Lotus_Care.Receptionist;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lotus_Care.CommonForms
{
    public partial class DoctorNurse : Form
    {
        private readonly UserRole _role;
        public DoctorNurse(UserRole role)
        {
            InitializeComponent();
            _role = role;
        }

        private void DoctorNurse_Load(object sender, EventArgs e)
        {
            
        }

        private void PatientBtn_Click(object sender, EventArgs e)
        {
            Patients patientsForm = new Patients(_role);
            patientsForm.Show();
        }

        private void DiagnosisBtn_Click(object sender, EventArgs e)
        {

        }

        private void PrescriptionBtn_Click(object sender, EventArgs e)
        {

        }

        private void PatientProgressBtn_Click(object sender, EventArgs e)
        {

        }

        private void LogoutBtn_Click(object sender, EventArgs e)
        {
            // Close this dashboard, Program.cs loop will bring back login
            this.Close();
        }
    }
}
