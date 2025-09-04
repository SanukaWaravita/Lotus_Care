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
    public partial class Patients : Form
    {
        private readonly UserRole _role;
        readonly SqlConnection con = new SqlConnection(Program.ConnectionString);
        public Patients(UserRole role)
        {
            InitializeComponent();
            _role = role;
        }
        private void Patients_Load(object sender, EventArgs e)
        {
            DisplayPatients();

            if (_role == UserRole.Nurse)
            {
                AddBtn.Visible = false; // Hide the "New Patient" button
                PatientsDataGridView.ReadOnly = true; // Make DataGridView read-only
            }
            else
            {
                AddBtn.Visible = true;
                PatientsDataGridView.ReadOnly = false;
            }
        }
        internal void DisplayPatients()
        {
            try
            {
                con.Open();
                string Query = "SELECT * FROM Patients";
                SqlDataAdapter sda = new SqlDataAdapter(Query, con);
                SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(sda);
                var ds = new DataSet();
                sda.Fill(ds);
                PatientsDataGridView.DataSource = ds.Tables[0];
                con.Close();
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void PatientsDataGridView_Click(object sender, EventArgs e)
        {
            if (_role == UserRole.Nurse)
            {
                return; // Nurses cannot open SelectedPatientDetails
            }
            try
            {
                String patientid = PatientsDataGridView.SelectedRows[0].Cells[0].Value.ToString();
                String fullname = PatientsDataGridView.SelectedRows[0].Cells[1].Value.ToString();
                String dob = PatientsDataGridView.SelectedRows[0].Cells[2].Value.ToString();
                String gender = PatientsDataGridView.SelectedRows[0].Cells[3].Value.ToString();
                String contactno = PatientsDataGridView.SelectedRows[0].Cells[4].Value.ToString();
                String address = PatientsDataGridView.SelectedRows[0].Cells[5].Value.ToString();
                String emergencycontact = PatientsDataGridView.SelectedRows[0].Cells[6].Value.ToString();
                String dateregistered = PatientsDataGridView.SelectedRows[0].Cells[7].Value.ToString();

                SelectedPatientDetails selectedPatients = new SelectedPatientDetails(
                    this, 
                    patientid,
                    fullname,
                    dob,
                    gender,
                    contactno,
                    address,
                    emergencycontact,
                    dateregistered,
                    RecordFunction.Update_Delete,
                    _role);
                selectedPatients.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            SelectedPatientDetails selectedPatient = new SelectedPatientDetails(this, RecordFunction.Add, _role);
            selectedPatient.Show();
        }
    }
}
