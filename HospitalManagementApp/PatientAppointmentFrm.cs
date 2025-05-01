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
using System.Xml.Linq;

namespace HospitalManagementApp
{
    public partial class PatientAppointmentFrm : Form
    {
        public PatientAppointmentFrm()
        {
            InitializeComponent();
        }
        DatabaseConnection database = new DatabaseConnection();
        public string id;
        private void PatientAppointmentFrm_Load(object sender, EventArgs e)
        {
            lblIdentityNumber.Text = id;

            SqlCommand cmd = new SqlCommand("Select patientName,patientSurName From Table_Patients where patientIdentityNumber=@p1", database.connection());
            cmd.Parameters.AddWithValue("@p1", lblIdentityNumber.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            
            while (dr.Read())
            {
                lblName.Text= dr[0] + " " + dr[1];
            }
            database.connection().Close();

            //Appointment History
            
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Table_Appointments where patientIdNumber=@p1", database.connection());
            da.SelectCommand.Parameters.AddWithValue("@p1",lblIdentityNumber.Text);
            da.Fill(dt);
            dataGridView1.DataSource= dt;

            //Branch
            SqlCommand cmd2 = new SqlCommand("Select departmentName from Table_Departments",database.connection());
            SqlDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
                cmbBranch.Items.Add(dr2[0]);
            }
            database.connection().Close();
            
        }

        private void cmbBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select doctorName,doctorSurName from Table_Doctors where doctorBranch=@p1", database.connection());
            cmd.Parameters.AddWithValue("@p1",cmbBranch.SelectedItem.ToString());
            SqlDataReader dr = cmd.ExecuteReader(); 
            while (dr.Read())
            {
                cmbDoctor.Items.Clear();
                cmbDoctor.Items.Add(dr[0] +" "+ dr[1]);
            }
            database.connection().Close();
        }

        private void cmbDoctor_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Table_Appointments where appointmentBranch=@p1 and appointmentDoctor=@p2 and appointmentStatus=@p3", database.connection());
            da.SelectCommand.Parameters.AddWithValue("@p1",cmbBranch.Text);
            da.SelectCommand.Parameters.AddWithValue("@p2", cmbDoctor.Text);
            da.SelectCommand.Parameters.AddWithValue("@p3", 0);
            da.Fill(dt);
            dataGridView2.DataSource = dt;   

        }

        private void lnkEditInformation_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UpdateInformationFrm updateInformationFrm = new UpdateInformationFrm();
            updateInformationFrm.idNumber = lblIdentityNumber.Text;
            updateInformationFrm.ShowDialog();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int selected = dataGridView2.SelectedCells[0].RowIndex;
            txtId.Text = dataGridView2.Rows[selected].Cells[0].Value.ToString();
        }

        private void btnBookAppointment_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Update Table_Appointments Set " +
                "appointmentStatus=1,patientIdNumber=@p1,patientComplaint=@p2 where appointmentId=@p3",database.connection());

            cmd.Parameters.AddWithValue("@p1",lblIdentityNumber.Text);
            cmd.Parameters.AddWithValue("@p2", rchtxtComplaint.Text);
            cmd.Parameters.AddWithValue("@p3", txtId.Text);

            cmd.ExecuteNonQuery();
            database.connection().Close();
            MessageBox.Show("Appointment successfully booked.","Alert",MessageBoxButtons.OK,MessageBoxIcon.Warning);

        }
    }
}
