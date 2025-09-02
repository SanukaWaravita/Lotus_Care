using Lotus_Care.Administrator;
using Lotus_Care.Doctor;
using Lotus_Care.Nurse;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lotus_Care
{
    public partial class Login : Form
    {
        readonly SqlConnection con = new SqlConnection(Program.ConnectionString);
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim(); // Username textbox
            string password = txtPassword.Text.Trim(); // Password textbook

            try
            {
                var AuthService = new Logic.AuthService(Program.ConnectionString);
                string userRole = AuthService.ValidateUser(username, password);

                if (userRole == null)
                {
                    MessageBox.Show("Invalid Username or Password");
                    return; // Early exit technique to avoid running unnecessary code
                }

                this.Hide();

                if (userRole == "Admin")
                {
                    AdministratorDashboard adminDash = new AdministratorDashboard();
                    adminDash.ShowDialog();
                }
                else if (userRole == "Doctor")
                {
                    DoctorDashboard docDash = new DoctorDashboard();
                    docDash.ShowDialog();
                }
                else if (userRole == "Nurse")
                {
                    NurseDashboard nurseDash = new NurseDashboard();
                    nurseDash.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Unknown role: " + userRole);
                }

                this.Close();
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                txtUsername.Clear();
                txtPassword.Clear();
            }
        }

        private void LeaveBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
