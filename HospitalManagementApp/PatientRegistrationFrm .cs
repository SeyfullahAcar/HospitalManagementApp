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
    public partial class PatientRegistrationFrm : Form
    {
        public PatientRegistrationFrm()
        {
            InitializeComponent();
        }

        DatabaseConnection database = new DatabaseConnection();
        private void btnSignUp_Click(object sender, EventArgs e)
        {
            SqlCommand addCommand = new SqlCommand("insert into " +
                "Table_Patients" +
                "(patientName,patientSurName,patientIdentityNumber" +
                ",patientPhoneNumber,patientPassword,patientGender)" +
                "values(@p1,@p2,@p3,@p4,@p5,@p6)",database.connection());

            addCommand.Parameters.AddWithValue("@p1", txtName.Text);
            addCommand.Parameters.AddWithValue("@p2", txtSurName.Text);
            addCommand.Parameters.AddWithValue("@p3", mtbIdNumber.Text);
            addCommand.Parameters.AddWithValue("@p4", mtbPhoneNumber.Text);
            addCommand.Parameters.AddWithValue("@p5", txtPassword.Text);
            addCommand.Parameters.AddWithValue("@p6", cmbGender.Text);
            addCommand.ExecuteNonQuery();
            database.connection().Close();
            MessageBox.Show("Your registration has been completed, your password: " +
                             ""+txtPassword.Text,"Information",MessageBoxButtons.OK,MessageBoxIcon.Information);


        }

        private void PatientRegistrationFrm_Load(object sender, EventArgs e)
        {

        }
    }
}
