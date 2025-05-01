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
    public partial class DoctorDashboardFrm : Form
    {
        public DoctorDashboardFrm()
        {
            InitializeComponent();
        }

        DatabaseConnection database = new DatabaseConnection();
        public string id;
        private void DoctorDashboardFrm_Load(object sender, EventArgs e)
        {
            lblIdentityNumber.Text = id;

            //Name Surname 

            SqlCommand cmd = new SqlCommand("Select doctorName,doctorSurName from Table_Doctors where doctorIdentityNumber=@p1",database.connection());
            cmd.Parameters.AddWithValue("@p1",id);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lblDoctorName.Text = dr[0] + " " + dr[1];
            }
            database.connection().Close();    

            //Appointments

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Table_Appointments where appointmentDoctor=@p1",database.connection());
            da.SelectCommand.Parameters.AddWithValue("@p1",lblDoctorName.Text);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            database.connection().Close();

        }

        private void btnEditInformation_Click(object sender, EventArgs e)
        {
            DoctorUpdateInformationFrm doctorUpdateInformationFrm = new DoctorUpdateInformationFrm();
            doctorUpdateInformationFrm.id = id;
            doctorUpdateInformationFrm.Show();
        }

        private void btnAnnouncements_Click(object sender, EventArgs e)
        {
            AnnouncementsFrm announcementsFrm = new AnnouncementsFrm();
            announcementsFrm.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            
        }
    }
}
