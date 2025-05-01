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
    public partial class SecretaryLoginFrm : Form
    {
        public SecretaryLoginFrm()
        {
            InitializeComponent();
        }

        DatabaseConnection database = new DatabaseConnection();

        
        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select * From Table_Secretarys where secretaryIdentityNumber=@p1 and secretaryPassword=@p2",database.connection());
            cmd.Parameters.AddWithValue("@p1", txtIdentityNumber.Text);
            cmd.Parameters.AddWithValue("@p2", txtPassword.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                SecretaryDashboardFrm secretaryDashboardFrm = new SecretaryDashboardFrm();  
                secretaryDashboardFrm.idNumber= txtIdentityNumber.Text;
                secretaryDashboardFrm.Show();
            }
            else
            {
                MessageBox.Show("Invalid ID number or password, please try again.");
            }

            database.connection().Close();
        }
    }
}
