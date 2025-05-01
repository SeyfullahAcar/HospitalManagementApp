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
    public partial class DoctorLoginFrm : Form
    {
        public DoctorLoginFrm()
        {
            InitializeComponent();
        }

        DatabaseConnection database = new DatabaseConnection();
        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlCommand sqlCommand = new SqlCommand("Select * from Table_Doctors where doctorIdentityNumber=@p1 and doctorPassword=@p2",database.connection());
            sqlCommand.Parameters.AddWithValue("@p1",txtIdentityNumber.Text);
            sqlCommand.Parameters.AddWithValue("@p2",txtPassword.Text);
            SqlDataReader dr = sqlCommand.ExecuteReader();  
            if (dr.Read())
            {
                DoctorDashboardFrm doctorDashboardFrm = new DoctorDashboardFrm();
                doctorDashboardFrm.id=txtIdentityNumber.Text;
                doctorDashboardFrm.Show();
            }
            else
            {
                MessageBox.Show("Invalid username or password. Please try again.","Alert",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            database.connection().Close();
        }
    }
}
