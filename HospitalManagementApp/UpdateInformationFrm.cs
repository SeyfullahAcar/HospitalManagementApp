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
    public partial class UpdateInformationFrm : Form
    {
        public UpdateInformationFrm()
        {
            InitializeComponent();
        }
        public string idNumber;

        DatabaseConnection database = new DatabaseConnection();

        
        private void UpdateInformationFrm_Load(object sender, EventArgs e)
        {
            mtbIdNumber.Text = idNumber.ToString();
            SqlCommand cmd = new SqlCommand("Select * From Table_Patients where patientIdentityNumber=@p1", database.connection());
            cmd.Parameters.AddWithValue("@p1", idNumber);

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                txtName.Text = dr[1].ToString();
                txtSurName.Text = dr[2].ToString();
                mtbIdNumber.Text = dr[3].ToString();
                mtbPhoneNumber.Text = dr[4].ToString();
                txtPassword.Text = dr[5].ToString();
                cmbGender.Text = dr[6].ToString();
            }
            database.connection().Close();    
           
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("update Table_Patients set " +
            "patientName=@p1,patientSurName=@p2," +
            "patientPhoneNumber=@p3,patientPassword=@p4," +
            "patientGender=@p5 where patientIdentityNumber=@p6",database.connection());

            cmd.Parameters.AddWithValue("@p1", txtName.Text);
            cmd.Parameters.AddWithValue("@p2", txtSurName.Text);
            cmd.Parameters.AddWithValue("@p3", mtbPhoneNumber.Text);
            cmd.Parameters.AddWithValue("@p4", txtPassword.Text);
            cmd.Parameters.AddWithValue("@p5", cmbGender.Text);
            cmd.Parameters.AddWithValue("@p6", mtbIdNumber.Text);
            cmd.ExecuteNonQuery();
            database.connection().Close();
            MessageBox.Show("Your information has been updated", "Information",MessageBoxButtons.OK,MessageBoxIcon.Warning);


        }
    }
}
