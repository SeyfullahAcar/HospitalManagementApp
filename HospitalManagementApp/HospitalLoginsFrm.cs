using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalManagementApp
{
    public partial class HospitalLoginsFrm : Form
    {
        public HospitalLoginsFrm()
        {
            InitializeComponent();

            
        }
        
       

        private void btnPatientLogin_Click(object sender, EventArgs e)
        {
            PatientLoginFrm frmPatientLogin = new PatientLoginFrm(); 
            frmPatientLogin.ShowDialog();
            this.Close();

           
        }

        private void btnDoctorLogin_Click(object sender, EventArgs e)
        {
            DoctorLoginFrm frmDoctorLogin = new DoctorLoginFrm();
            frmDoctorLogin.ShowDialog();
            this.Close();

        }

        private void btnSecretaryLogin_Click(object sender, EventArgs e)
        {
            SecretaryLoginFrm frmSecretaryLogin = new SecretaryLoginFrm();
            frmSecretaryLogin.ShowDialog();
            this.Close();
        }

        private void HospitalLoginsFrm_Load(object sender, EventArgs e)
        {
           
        }
    }
}
