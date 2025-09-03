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
        readonly SqlConnection con = new SqlConnection(Program.ConnectionString);
        public Patients()
        {
            InitializeComponent();
        }

        private void Patients_Load(object sender, EventArgs e)
        {
            DisplayPatients();
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
    }
}
