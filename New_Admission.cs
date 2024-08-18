using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;

namespace college_management
{
    public partial class New_Admission : Form
    {
        public New_Admission()
        {
            InitializeComponent();
        }

        private void New_Admission_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source=DEVA\\SQLEXPRESS;database=college;integrated security=True";
            SqlCommand cmd = new SqlCommand();  
            cmd.Connection = con;
            cmd.CommandText = "select max(NAID) from NewAdmission";
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            DA.Fill(DS);
            con.Close();
            Int64 abc = Convert.ToInt64(DS.Tables[0].Rows[0][0]);
            label13.Text = (abc + 1).ToString();
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
        }

       

        private void btnsave_Click_1(object sender, EventArgs e)
        {
            string name = txtFullName.Text;
            string mname = txtMotherName.Text;
            string gender = "";
            bool isChecked = radioButtonMale.Checked;
            if (isChecked)
            {
                gender = radioButtonMale.Text;
            }
            else
            {
                gender = radioButtonFemale.Text;
            }

            string dob = dateTimePickerDOB.Text;
            Int64 moblie = Int64.Parse(txtMoblie.Text);
            string email = txtEmail.Text;
            string semester = txtSemester.Text;
            string program = txtProgramming.Text;
            string sname = txtSchool.Text;
            string duration = txtDuration.Text;
            string add = txtAddress.Text;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source=DEVA\\SQLEXPRESS;database=college;integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            
            cmd.CommandText = "insert into NewAdmission(fname,mname,gender,dob,moblie,email,semester,prog,sname,duration,address) values('" + name + "','" + mname + "','" + gender + "','" + dob + "'," + moblie + ",'" + email + "','" + semester + "','" + program + "','" + sname + "','" + duration + "','" + add + "')";
           
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            DA.Fill(DS);
            con.Close();
            MessageBox.Show("Data Saved.Remember the Registration ID", "Data", MessageBoxButtons.OK, MessageBoxIcon.Hand);

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtFullName.Clear();
            txtMotherName.Clear();
            txtAddress.Clear();
            txtMoblie.Clear();
            radioButtonFemale.Checked = false;
            radioButtonMale.Checked = false;
            txtProgramming.ResetText();
            txtSemester.ResetText();
            txtEmail.Clear();
            txtSchool.Clear();
            txtDuration.ResetText();
        }
    }
}
