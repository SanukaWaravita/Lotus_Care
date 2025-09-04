using Lotus_Care.CommonCode;
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
using static Lotus_Care.Administrator.Users;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Lotus_Care.Administrator
{
    public partial class SelectedUserDetails : Form
    {
        Users parentform;
        private readonly RecordFunction _Function;
        readonly SqlConnection Con = new SqlConnection(Program.ConnectionString);
        public SelectedUserDetails(
            Users parent,
            String UserID,
            String Username,
            String Password, 
            String Role, 
            String FullName,
            String ContactNo, 
            String Gender, 
            String Email, 
            String Status,
            RecordFunction Function)
        {
            InitializeComponent();
            parentform = parent;
            _Function = Function;

            txtUserId.Text = UserID;
            txtUsername.Text = Username;
            txtPassword.Text = Password;
            ComboRole.Text = Role;
            txtFullname.Text = FullName;
            txtContactNo.Text = ContactNo;
            ComboGender.Text = Gender;
            txtEmail.Text = Email;
            ComboStatus.Text = Status;
        }
        public SelectedUserDetails(Users parent, RecordFunction Function)
        {
            InitializeComponent();
            parentform = parent;
            _Function = Function;
        }
        private void SelectedUserDetails_Load(object sender, EventArgs e)
        {
            if (_Function == RecordFunction.Add)
            {
                UpdateBtn.Visible = false;
                DeleteBtn.Visible = false;
                AddBtn.Visible = true;
            }
            if (_Function != RecordFunction.Add)
            {
                UpdateBtn.Visible = true;
                DeleteBtn.Visible = true;
                AddBtn.Visible = false;
            }
        }

        private void txtRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        // UPDATE BUTTON
        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtUserId.Text) ||
                    string.IsNullOrEmpty(txtUsername.Text) ||
                    string.IsNullOrEmpty(txtPassword.Text) ||
                    string.IsNullOrEmpty(ComboRole.Text) ||
                    string.IsNullOrEmpty(txtFullname.Text) ||
                    string.IsNullOrEmpty(txtContactNo.Text) ||
                    string.IsNullOrEmpty(ComboGender.Text) ||
                    string.IsNullOrEmpty(txtEmail.Text) ||
                    string.IsNullOrEmpty(ComboStatus.Text))
                {
                    MessageBox.Show("Missing Information");
                }
                else
                {
                    Con.Open();
                    string query = @"UPDATE Users 
                                        SET Username =@username, 
                                            Password= @password, 
                                            Role= @role, 
                                            Fullname=@fullname, 
                                            ContactNo=@contactno, 
                                            Gender=@gender, 
                                            Email=@email, 
                                            Status=@status
                                        WHERE UserID=@userid";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.Parameters.AddWithValue("@userid", txtUserId.Text);
                    cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                    cmd.Parameters.AddWithValue("@password", txtPassword.Text);
                    cmd.Parameters.AddWithValue("@role", ComboRole.Text);
                    cmd.Parameters.AddWithValue("@fullname", txtFullname.Text);
                    cmd.Parameters.AddWithValue("@contactno", txtContactNo.Text);
                    cmd.Parameters.AddWithValue("@gender", ComboGender.Text);
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@status", ComboStatus.Text);
                    cmd.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("Record Update Successfully");
                    parentform?.DisplayUsers();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Con.Close();
            }
            txtUserId.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            ComboRole.ResetText();
            txtFullname.Clear();
            txtContactNo.Clear();
            ComboGender.ResetText();
            txtEmail.Clear();
            ComboStatus.ResetText();
        }
        // DELETE BUTTON
        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtUserId.Text))
                {
                    MessageBox.Show("Enter the User Id");
                    return;
                }

                var result = MessageBox.Show("Are you sure you want to delete this user?",
                                    "Confirm Delete",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    Con.Open();
                    string query = "DELETE from Users WHERE UserID=@userid;";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.Parameters.AddWithValue("@userid", txtUserId.Text);
                    
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Record Deleted Successfully!");
                        parentform?.DisplayUsers();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No records were deleted.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                Con.Close();
            }

            txtUserId.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            ComboRole.ResetText();
            txtFullname.Clear();
            txtContactNo.Clear();
            ComboGender.ResetText();
            txtEmail.Clear();
            ComboStatus.ResetText();
        }
        // ADD BUTTON
        private void AddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtUsername.Text) ||
                    string.IsNullOrEmpty(txtPassword.Text) ||
                    string.IsNullOrEmpty(ComboRole.Text) ||
                    string.IsNullOrEmpty(txtFullname.Text) ||
                    string.IsNullOrEmpty(txtContactNo.Text) ||
                    string.IsNullOrEmpty(ComboGender.Text) ||
                    string.IsNullOrEmpty(txtEmail.Text) ||
                    string.IsNullOrEmpty(ComboStatus.Text))
                {
                    MessageBox.Show("Missing Information");
                }
                else
                {
                    Con.Open();
                    String query = @"INSERT into Users (Username, Password, Role, FullName, ContactNo, Gender, Email, Status)
                                    VALUES (@username, 
                                            @password, 
                                            @role, 
                                            @fullname, 
                                            @contactno, 
                                            @gender, 
                                            @email, 
                                            @status)";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                    cmd.Parameters.AddWithValue("@password", txtPassword.Text);
                    cmd.Parameters.AddWithValue("@role", ComboRole.Text);
                    cmd.Parameters.AddWithValue("@fullname", txtFullname.Text);
                    cmd.Parameters.AddWithValue("@contactno", txtContactNo.Text);
                    cmd.Parameters.AddWithValue("@gender", ComboGender.Text);
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@status", ComboStatus.Text);
                    
                    cmd.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("Record Added Successfully!");
                    parentform?.DisplayUsers();
                    this.Close();
                }
            }catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
            finally
            {
                Con.Close();
            }
        }
    }
}
