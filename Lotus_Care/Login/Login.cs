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

            string query = "SELECT Role FROM Users WHERE Username=@username AND Password=@password";

            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand(query, con);

                // Using Parameters to prevent SQL injection
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                string userRole = "";

                if (reader.Read())
                {
                    userRole = reader["Role"].ToString();
                }
                else
                {
                    MessageBox.Show("Invalid username or password!");
                }

                reader.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (cmd != null)
                {
                    cmd.Dispose();
                }
                con.Close();
                con.Dispose();
            }
        }
    }
}
