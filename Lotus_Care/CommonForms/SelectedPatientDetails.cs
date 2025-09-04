using Lotus_Care.Administrator;
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

namespace Lotus_Care.CommonForms
{
    public partial class SelectedPatientDetails : Form
    {
        Patients parentform;
        private readonly RecordFunction _Function;
        private readonly UserRole _role;
        readonly SqlConnection Con = new SqlConnection(Program.ConnectionString);
        public SelectedPatientDetails(
            Patients parent,
            String patientID,
            String fullName,
            String dob,
            String gender,
            String contactNo,
            String address,
            String emergencyContact,
            String dateRegistered,
            RecordFunction Function,
            UserRole role)
        {
            InitializeComponent();
            parentform = parent;
            _Function = Function;
            _role = role;

            txtPatientId.Text = patientID;
            txtFullName.Text = fullName;
            DOBDatePicker.Text = dob;
            ComboGender.Text = gender;
            txtContactNo.Text = contactNo;
            txtAddress.Text = address;
            txtEmergencyContact.Text = emergencyContact;
            DateRegisteredDatePicker.Text = dateRegistered;
        }
        public SelectedPatientDetails(Patients parent, RecordFunction Function, UserRole role)
        {
            InitializeComponent();
            parentform = parent;
            _Function = Function;
            _role = role;
        }
        private void SelectedPatientDetails_Load(object sender, EventArgs e)
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
        
        // UPDATE BUTTON
        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtPatientId.Text) ||
                    string.IsNullOrEmpty(txtFullName.Text) ||
                    string.IsNullOrEmpty(DOBDatePicker.Text) ||
                    string.IsNullOrEmpty(ComboGender.Text) ||
                    string.IsNullOrEmpty(txtContactNo.Text) ||
                    string.IsNullOrEmpty(txtAddress.Text) ||
                    string.IsNullOrEmpty(txtEmergencyContact.Text) ||
                    string.IsNullOrEmpty(DateRegisteredDatePicker.Text))
                {
                    MessageBox.Show("Missing Information");
                }
                else
                {
                    Con.Open();
                    string query = @"UPDATE Patients 
                                        SET FullName=@fullname,
                                            DOB=@dob,
                                            Gender=@gender,
                                            ContactNo=@contactno,
                                            Address=@address,
                                            EmergencyContact=@emergencycontact,
                                            DateRegistered=@dateregistered
                                        WHERE PatientID=@patientid";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.Parameters.AddWithValue("@patientid", txtPatientId.Text);
                    cmd.Parameters.AddWithValue("@fullname", txtFullName.Text);
                    cmd.Parameters.AddWithValue("@dob", DOBDatePicker.Value.Date);
                    cmd.Parameters.AddWithValue("@gender", ComboGender.Text);
                    cmd.Parameters.AddWithValue("@contactno", txtContactNo.Text);
                    cmd.Parameters.AddWithValue("@address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@emergencycontact", txtEmergencyContact.Text);
                    cmd.Parameters.AddWithValue("@dateregistered", DateRegisteredDatePicker.Value);
                    cmd.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("Record Update Successfully");
                    parentform?.DisplayPatients();
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
            txtFullName.Clear();
            ComboGender.ResetText();
            txtContactNo.Clear();
            txtAddress.Clear();
            txtEmergencyContact.Clear();
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtFullName.Text) ||
                    string.IsNullOrEmpty(DOBDatePicker.Text) ||
                    string.IsNullOrEmpty(ComboGender.Text) ||
                    string.IsNullOrEmpty(txtContactNo.Text) ||
                    string.IsNullOrEmpty(txtAddress.Text) ||
                    string.IsNullOrEmpty(DateRegisteredDatePicker.Text))
                {
                    MessageBox.Show("Missing Information");
                }
                else
                {
                    Con.Open();
                    string query = @"INSERT into Patients (FullName, DOB, Gender, ContactNo, Address, EmergencyContact, DateRegistered)
                                        VALUES (@fullname, @dob, @gender, @contactno, @address, @emergencycontact, @dateregistered)";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.Parameters.AddWithValue("@fullname", txtFullName.Text);
                    cmd.Parameters.AddWithValue("@dob", DOBDatePicker.Value.Date);
                    cmd.Parameters.AddWithValue("@gender", ComboGender.Text);
                    cmd.Parameters.AddWithValue("@contactno", txtContactNo.Text);
                    cmd.Parameters.AddWithValue("@address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@emergencycontact", txtEmergencyContact.Text);
                    cmd.Parameters.AddWithValue("@dateregistered", DateRegisteredDatePicker.Value);
                    cmd.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("Record Added Successfully");
                    parentform?.DisplayPatients();

                    txtFullName.Clear();
                    ComboGender.ResetText();
                    txtContactNo.Clear();
                    txtAddress.Clear();
                    txtEmergencyContact.Clear();
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
        }
    }
}
