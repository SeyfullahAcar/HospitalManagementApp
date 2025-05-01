using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace HospitalManagementApp
{
    public partial class AppointmentOverviewFrm : Form
    {
        public AppointmentOverviewFrm()
        {
            InitializeComponent();
        }
        DatabaseConnection database = new DatabaseConnection();
        private void AppointmentOverviewFrm_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable(); 
            SqlDataAdapter da = new SqlDataAdapter("Select * from Table_Appointments",database.connection());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            database.connection().Close();
        }
        public string date, time, branch, doctor, status, identityNumber, id;
        
    }
}
