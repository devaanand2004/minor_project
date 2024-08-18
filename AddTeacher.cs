using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace college_management
{
    public partial class AddTeacher : Form
    {
        public AddTeacher()
        {
            InitializeComponent();
        }

        private void AddTeacher_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source=DEVA\\SQLEXPRESS;database=college;integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select max(tID) from teacher";
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            DA.Fill(DS);
            con.Close();
            Int64 abc = Convert.ToInt64(DS.Tables[0].Rows[0][0]);
            label12.Text = (abc + 1).ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            String gender = "";
            bool isChecked = radioFemale.Checked;
            if (isChecked)
            {
                gender = radioFemale.Text;

            }
            else
            {
                gender = radioMale.Text;
            }

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source=DEVA\\SQLEXPRESS;database=college;integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into teacher (fname,gender,dob,mobile,email,semester,prog,yer,adr) values('"+txtFName.Text+"','"+gender+"','"+dateTimePickerDOB.Text+"',"+txtMoblieNo.Text+",'"+txtEMail.Text+"','"+txtSemester.Text+"','"+ txtProgramming.Text+"','"+txtDuration.Text+"','"+txtAddress.Text+"')";
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();

            DA.Fill(DS);

            MessageBox.Show("Data Saved.Remember the Teacher ID", "Data", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtFName.Clear();
            
            txtAddress.Clear();
            txtMoblieNo.Clear();
            radioFemale.Checked = false;
            radioMale.Checked = false;
            txtProgramming.ResetText();
            txtSemester.ResetText();
            txtEMail.Clear();
           
            txtDuration.ResetText();
        }
    }
}
