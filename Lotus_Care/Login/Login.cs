using Lotus_Care.Administrator;
using Lotus_Care.CommonCode;
using Lotus_Care.Doctor;
using Lotus_Care.Nurse;
using Lotus_Care.Receptionist;
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
        public UserRole UserRole { get; private set; } // Encapsulation
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
                string roleFromDb = AuthService.ValidateUser(username, password);

                if (string.IsNullOrEmpty(roleFromDb))
                {
                    MessageBox.Show("Invalid Username or Password");
                    return; // Early exit technique to avoid running unnecessary code
                }

                // CONVERT STRING FROM DB TO ENUM
                if (!Enum.TryParse(roleFromDb, true, out UserRole parsedRole))
                {
                    MessageBox.Show("Unknown role: " + roleFromDb);
                    return;
                }
                UserRole = parsedRole; // Storing the role
                this.DialogResult = DialogResult.OK; // Telling Program.cs that login succeeded
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
