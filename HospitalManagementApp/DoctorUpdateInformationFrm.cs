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
using System.Security.Policy;
namespace HospitalManagementApp
{
    public partial class DoctorUpdateInformationFrm : Form
    {
        public DoctorUpdateInformationFrm()
        {
            InitializeComponent();
        }
        DatabaseConnection database = new DatabaseConnection(); 
        public string id;
        private void DoctorUpdateInformationFrm_Load(object sender, EventArgs e)
        {
            mtbIdNumber.Text = id;

            SqlCommand cmd = new SqlCommand("Select * from Table_Doctors where doctorIdentityNumber=@p1",database.connection());
            cmd.Parameters.AddWithValue("@p1",id);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                txtName.Text = dr["doctorName"].ToString();
                txtSurName.Text = dr["doctorSurName"].ToString();
                cmbBranch.Text = dr["doctorBranch"].ToString();
                txtPassword.Text = dr["doctorPassword"].ToString(); 
            }
            database.connection().Close();

            //Transferring the branch to the combobox

            SqlCommand cmd2 = new SqlCommand("Select departmentName from Table_Departments", database.connection());
            SqlDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
                cmbBranch.Items.Add(dr2["departmentName"].ToString());
            }
            database.connection().Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Update Table_Doctors Set " +
                "doctorName=@p1,doctorSurName=@p2,doctorBranch=@p3,doctorPassword=@p4 where doctorIdentityNumber=@p5",database.connection());
            cmd.Parameters.AddWithValue("@p1",txtName.Text);
            cmd.Parameters.AddWithValue("@p2", txtSurName.Text);
            cmd.Parameters.AddWithValue("@p3", cmbBranch.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@p4", txtPassword.Text);
            cmd.Parameters.AddWithValue("@p5", id);
            cmd.ExecuteNonQuery();
            database.connection().Close();
            MessageBox.Show("Your information has been successfully updated.","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}
