using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lotus_Care.Logic
{
    internal class AuthService
    {
        private readonly string _connectionString;

        // CONSTRUCTOR
        public AuthService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public string ValidateUser(string username, string password)
        {
            string userRole = null;

            SqlConnection con = new SqlConnection(_connectionString);

            // Parameterized Queries for Database Security
            string query = "SELECT Role FROM Users WHERE Username=@username AND Password=@password";

            SqlCommand cmd = null;

            if (username == "" || password == "")
            {
                MessageBox.Show("Username or Password cannot be empty!");
                return null;
            }
            else
            {
                try
                {
                    cmd = new SqlCommand(query,con);

                    // Parameterized Queries for Database Security
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    con.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        userRole = reader["Role"].ToString();
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
                }

                return userRole;
            }
        }
    }
}
