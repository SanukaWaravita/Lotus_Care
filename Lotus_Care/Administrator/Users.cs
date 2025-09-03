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
using static Lotus_Care.Administrator.AdministratorDashboard;

namespace Lotus_Care.Administrator
{
    public partial class Users : Form
    {
        readonly SqlConnection con = new SqlConnection(Program.ConnectionString);
        public Users()
        {
            InitializeComponent();
        }
        public enum userFunction
        {
            Add,
            Update_Delete
        }
        private void Users_Load(object sender, EventArgs e)
        {
            DisplayUsers();
        }
        internal void DisplayUsers()
        {
            try
            {
                con.Open();
                string Query = "select * from Users";
                SqlDataAdapter sda = new SqlDataAdapter(Query, con);
                SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(sda);
                var ds = new DataSet();
                sda.Fill(ds);
                UsersDatagridView.DataSource = ds.Tables[0];
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void UsersDatagridView_Click(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void UsersDatagridView_Click(object sender, EventArgs e)
        {
            try
            {
                String userid = UsersDatagridView.SelectedRows[0].Cells[0].Value.ToString();
                String username = UsersDatagridView.SelectedRows[0].Cells[1].Value.ToString();
                String password = UsersDatagridView.SelectedRows[0].Cells[2].Value.ToString();
                String role = UsersDatagridView.SelectedRows[0].Cells[3].Value.ToString();
                String fullname = UsersDatagridView.SelectedRows[0].Cells[4].Value.ToString();
                String contactno = UsersDatagridView.SelectedRows[0].Cells[5].Value.ToString();
                String gender = UsersDatagridView.SelectedRows[0].Cells[6].Value.ToString();
                String email = UsersDatagridView.SelectedRows[0].Cells[7].Value.ToString();
                String status = UsersDatagridView.SelectedRows[0].Cells[8].Value.ToString();

                SelectedUserDetails selectedUsers = new SelectedUserDetails(
                    this,
                    userid,
                    username,
                    password,
                    role,
                    fullname,
                    contactno,
                    gender,
                    email,
                    status,
                    userFunction.Update_Delete);
                selectedUsers.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
        }

        private void AddUsersBtn_Click(object sender, EventArgs e)
        {
            SelectedUserDetails selectedUser = new SelectedUserDetails(this, userFunction.Add);
            selectedUser.Show();
        }
    }
}
