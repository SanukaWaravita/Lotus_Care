using Lotus_Care.CommonCode;
using Lotus_Care.CommonForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lotus_Care.Administrator
{
    public partial class AdministratorDashboard : Form
    {
        private readonly UserRole _role;
        public AdministratorDashboard(UserRole role)
        {
            InitializeComponent();
            _role = role;
        }

        private void AdministratorDashboard_Load(object sender, EventArgs e)
        {

        }

        private void UsersBtn_Click(object sender, EventArgs e)
        {
            Users users = new Users();
            users.Show();
        }

        private void PatientsBtn_Click(object sender, EventArgs e)
        {
            Patients patients = new Patients(_role);
            patients.Show();
        }
    }
}
