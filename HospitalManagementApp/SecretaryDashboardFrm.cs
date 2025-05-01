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
using System.Security.Cryptography;

namespace HospitalManagementApp
{
    public partial class SecretaryDashboardFrm : Form
    {
        public SecretaryDashboardFrm()
        {
            InitializeComponent();
        }
        DatabaseConnection database = new DatabaseConnection();
        public string idNumber;
       
        private void SecretaryDashboardFrm_Load(object sender, EventArgs e)
        {
            lblIdentityNumber.Text = idNumber;         
            // Name Surname

            SqlCommand cmd = new SqlCommand("Select secretaryNameSurName From Table_Secretarys where secretaryIdentityNumber =@p1", database.connection());
            cmd.Parameters.AddWithValue("@p1",idNumber);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lblSecretaryName.Text = dr[0].ToString();
            }
            database.connection().Close();

            // Load branches into the data grid

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Table_Departments ", database.connection());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            //Load branches into the data grid

            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("Select (doctorName+' '+doctorSurName) as 'Doktorlar',doctorBranch From Table_Doctors ", database.connection());
            da2.Fill(dt2);
            dataGridView2.DataSource = dt2;

            //Transferring the branch to the combobox

            SqlCommand cmd3 = new SqlCommand("Select departmentName From Table_Departments ",database.connection());
            SqlDataReader dr3= cmd3.ExecuteReader();
            while (dr3.Read())
            {
                cmbBranch.Items.Add(dr3[0].ToString());
            }
            database.connection().Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("insert into Table_Appointments" +
                "(appointmentDate,appointmentTime,appointmentBranch,appointmentDoctor)" +
                "values (@p1,@p2,@p3,@p4)",database.connection());

            cmd.Parameters.AddWithValue("@p1", mtbDate.Text);
            cmd.Parameters.AddWithValue("@p2", mtbTime.Text);
            cmd.Parameters.AddWithValue("@p3", cmbBranch.Text);
            cmd.Parameters.AddWithValue("@p4", cmbDoctor.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Your appointment has been successfully created.","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);

        }

        private void cmbBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbDoctor.Items.Clear();
            SqlCommand cmd = new SqlCommand("Select doctorName,doctorSurName From Table_Doctors where doctorBranch=@p1", database.connection());
            cmd.Parameters.AddWithValue("p1", cmbBranch.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            
            while (dr.Read())
            {
                
                cmbDoctor.Items.Add(dr[0] + " " + dr[1]);
                
            }
            database.connection().Close();
        }

        private void btnCrtAnnouncement_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("insert into Table_Announcements (announcements) values (@p1)",database.connection());
            cmd.Parameters.AddWithValue("@p1", rchtxtAnnouncement.Text);
            cmd.ExecuteNonQuery();            
            database.connection().Close();
            MessageBox.Show("Announcement has been successfully created.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnDoctorPanel_Click(object sender, EventArgs e)
        {
            ManageDoctorsFrm manageDoctorsFrm = new ManageDoctorsFrm();
            manageDoctorsFrm.Show();
        }

        private void btnBranchPanel_Click(object sender, EventArgs e)
        {
            ManageBranchFrm manageBranchFrm = new ManageBranchFrm();
            manageBranchFrm.Show();
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            
            AppointmentOverviewFrm appointmentOverviewFrm = new AppointmentOverviewFrm();                      
            appointmentOverviewFrm.Show();
           
        }

        private void btnAnnouncements_Click(object sender, EventArgs e)
        {
            AnnouncementsFrm announcementsFrm = new AnnouncementsFrm();
            announcementsFrm.Show();
        }

        

        
    }
}
