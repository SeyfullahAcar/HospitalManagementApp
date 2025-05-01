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
    public partial class ManageBranchFrm : Form
    {
        public ManageBranchFrm()
        {
            InitializeComponent();
        }
        
        DatabaseConnection database = new DatabaseConnection(); 
        private void ManageBranchFrm_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Table_Departments",database.connection());
            da.Fill(dt);
            dataGridView1.DataSource= dt;
            database.connection().Close();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("insert into Table_Departments (departmentName) values (@p1)",database.connection());
            cmd.Parameters.AddWithValue("@p1",txtBranchName.Text);
            cmd.ExecuteNonQuery();
            database.connection().Close();
            MessageBox.Show("The new branch record has been successfully added.","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
            
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int selected = dataGridView1.SelectedCells[0].RowIndex;
            txtId.Text = dataGridView1.Rows[selected].Cells[0].Value.ToString();
            txtBranchName.Text = dataGridView1.Rows[selected].Cells[1].Value.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("delete from Table_Departments where departmentId=@p1",database.connection());
            cmd.Parameters.AddWithValue("@p1",txtId.Text);
            cmd.ExecuteNonQuery();
            database.connection().Close();
            MessageBox.Show("The branch record has been successfully deleted.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Update Table_Departments set departmentName=@p1 where departmentId=@p2", database.connection());
            cmd.Parameters.AddWithValue("@p1",txtBranchName.Text);
            cmd.Parameters.AddWithValue("@p2", txtId.Text);
            cmd.ExecuteNonQuery();
            database.connection().Close();
            MessageBox.Show("The branch record has been successfully updated.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
