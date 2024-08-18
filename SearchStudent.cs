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

namespace college_management
{
    public partial class SearchStudent : Form
    {
        public SearchStudent()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source=DEVA\\SQLEXPRESS;database=college;integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from NewAdmission where NAID = "+textBox1.Text+"";
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();

            DA.Fill(DS);

            dataGridView1.DataSource = DS.Tables[0];
        }

        private void SearchStudent_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source=DEVA\\SQLEXPRESS;database=college;integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT NewAdmission.NAID AS Student_ID, NewAdmission.fname AS Full_Name, NewAdmission.mname AS Mother_Name, NewAdmission.gender AS Gender, NewAdmission.dob AS Date_Of_Birth, NewAdmission.email AS Email_ID, NewAdmission.prog AS Programming_Language, NewAdmission.sname AS School_Name, NewAdmission.duration AS Course_Duration, NewAdmission.address AS Address, fees.fees AS Fees FROM NewAdmission INNER JOIN fees ON NewAdmission.NAID = fees.NAID";
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();

            DA.Fill(DS);
         
            dataGridView1.DataSource = DS.Tables[0];
        }
    }
}
