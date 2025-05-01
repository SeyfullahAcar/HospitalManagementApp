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
    public partial class PatientLoginFrm : Form
    {
        public PatientLoginFrm()
        {
            InitializeComponent();
        }
        DatabaseConnection database = new DatabaseConnection();
        private void lnkSignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PatientRegistrationFrm registrationFrm = new PatientRegistrationFrm();
            registrationFrm.Show();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select * from Table_Patients Where patientIdentityNumber=@p1 and patientPassword=@p2", database.connection());
            cmd.Parameters.AddWithValue("@p1", mtbIdNumber.Text);
            cmd.Parameters.AddWithValue("@p2", txtPassword.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                PatientAppointmentFrm patientAppointmentFrm = new PatientAppointmentFrm();
                patientAppointmentFrm.id =mtbIdNumber.Text;
                patientAppointmentFrm.Show();
            }
            else
            {
                MessageBox.Show("Invalid ID number or password, please try again.");
            }

            database.connection().Close();
        }

        
    }
}
