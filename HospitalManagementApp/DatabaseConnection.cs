using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace HospitalManagementApp
{
    internal class DatabaseConnection
    {
        public SqlConnection connection()
        {
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-BVU6OHO;Initial Catalog=TheHospitalProject;Integrated Security=True;Encrypt=False");
            connection.Open();
            return connection;  
        }
    }
}
