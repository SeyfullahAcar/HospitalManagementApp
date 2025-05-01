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
using System.Collections;
namespace HospitalManagementApp
{
    public partial class ManageDoctorsFrm : Form
    {
        public ManageDoctorsFrm()
        {
            InitializeComponent();
        }

        DatabaseConnection database = new DatabaseConnection();
        private void ManageDoctorsFrm_Load(object sender, EventArgs e)
        {

            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("Select * From Table_Doctors ", database.connection());
            da1.Fill(dt1);
            dataGridView1.DataSource = dt1;

            //Transferring the branch to the combobox

            SqlCommand cmd = new SqlCommand("Select departmentName From Table_Departments ", database.connection());
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cmbBranch.Items.Add(dr[0].ToString());
            }
            database.connection().Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("insert into Table_Doctors " +
                "(doctorName,doctorSurName,doctorIdentityNumber,doctorBranch,doctorPassword)" +
                "values (@p1,@p2,@p3,@p4,@p5)",database.connection());

            cmd.Parameters.AddWithValue("@p1",txtName.Text);
            cmd.Parameters.AddWithValue("@p2", txtSurName.Text);
            cmd.Parameters.AddWithValue("@p3", mtbIdNumber.Text);
            cmd.Parameters.AddWithValue("@p4", cmbBranch.Text);
            cmd.Parameters.AddWithValue("@p5", txtPassword.Text);

            cmd.ExecuteNonQuery();
            database.connection().Close();
            MessageBox.Show("The new doctor record has been successfully created.","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int selected = dataGridView1.SelectedCells[0].RowIndex;
            txtName.Text = dataGridView1.Rows[selected].Cells[1].Value.ToString();
            txtSurName.Text = dataGridView1.Rows[selected].Cells[2].Value.ToString();
            mtbIdNumber.Text = dataGridView1.Rows[selected].Cells[3].Value.ToString();
            cmbBranch.Text = dataGridView1.Rows[selected].Cells[4].Value.ToString();
            txtPassword.Text = dataGridView1.Rows[selected].Cells[5].Value.ToString();


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
             SqlCommand cmd = new SqlCommand("delete from Table_Doctors where doctorIdentityNumber=@p1",database.connection());
             cmd.Parameters.AddWithValue("@p1",mtbIdNumber.Text);
             cmd.ExecuteNonQuery();   
             database.connection().Close();
             MessageBox.Show("The record has been deleted.", "Warning",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("UPDATE Table_Doctors SET " +
                     "doctorName = @p1, doctorSurName = @p2," +
                     "doctorBranch = @p3, doctorPassword = @p4 " +
                     "WHERE doctorIdentityNumber = @p5",database.connection());

            cmd.Parameters.AddWithValue("@p1", txtName.Text);
            cmd.Parameters.AddWithValue("@p2", txtSurName.Text);
            cmd.Parameters.AddWithValue("@p3", cmbBranch.Text);
            cmd.Parameters.AddWithValue("@p4", txtPassword.Text);
            cmd.Parameters.AddWithValue("@p5", mtbIdNumber.Text);

            cmd.ExecuteNonQuery();
            database.connection().Close();
            MessageBox.Show("The doctor record has been updated.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

       
    }
}
