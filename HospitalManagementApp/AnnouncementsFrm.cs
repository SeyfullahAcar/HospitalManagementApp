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
    public partial class AnnouncementsFrm : Form
    {
        public AnnouncementsFrm()
        {
            InitializeComponent();
        }
        DatabaseConnection database = new DatabaseConnection();

        private void AnnouncementsFrm_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Table_Announcements",database.connection());
            da.Fill(dt);
            dataGridView1.DataSource= dt;
            database.connection().Close();

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int selected = dataGridView1.SelectedCells[0].RowIndex;

            string message = dataGridView1.Rows[selected].Cells[1].Value.ToString();

            MessageBox.Show(message,"Announcement details",MessageBoxButtons.OK,MessageBoxIcon.Information);

        }
    }
}
