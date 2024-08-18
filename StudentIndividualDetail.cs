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
    public partial class StudentIndividualDetail : Form
    {
        public StudentIndividualDetail()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void btnShowDetails_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source=DEVA\\SQLEXPRESS;database=college;integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from NewAdmission where NAID = " + textBox1.Text + "";
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();

            DA.Fill(DS);

            if (DS.Tables[0].Rows.Count != 0) 
            {
                labelFullName.Text = DS.Tables[0].Rows[0][1].ToString();
                labelMName.Text = DS.Tables[0].Rows[0][2].ToString();
                labelGender.Text = DS.Tables[0].Rows[0][3].ToString();
                labelDOB.Text = DS.Tables[0].Rows[0][4].ToString();
                labelMobile.Text = DS.Tables[0].Rows[0][5].ToString();
                labelEmail.Text = DS.Tables[0].Rows[0][6].ToString();
                labelStandard.Text = DS.Tables[0].Rows[0][7].ToString();
                labelMedium.Text = DS.Tables[0].Rows[0][8].ToString();
                labelSchoolName.Text = DS.Tables[0].Rows[0][9].ToString();
                labelYear.Text = DS.Tables[0].Rows[0][10].ToString();
                labelAddress.Text = DS.Tables[0].Rows[0][11].ToString();
            }
            else
            {
               MessageBox.Show("NO Record Found ","No Match",MessageBoxButtons.OK ,MessageBoxIcon.Error);

                labelFullName.Text = "______";
                labelMName.Text = "______";
                labelGender.Text = "______";
                labelDOB.Text = "______";
                labelMobile.Text = "______";
                labelEmail.Text = "______";
                labelStandard.Text = "______";
                labelMedium.Text = "______";
                labelSchoolName.Text = "______";
                labelYear.Text = "______";
                labelAddress.Text = "______";
            }
      

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            labelFullName.Text = "______";
            labelMName.Text = "______";
            labelGender.Text = "______";
            labelDOB.Text = "______";
            labelMobile.Text = "______";
            labelEmail.Text = "______";
            labelStandard.Text = "______";
            labelMedium.Text = "______";
            labelSchoolName.Text = "______";
            labelYear.Text = "______";
            labelAddress.Text = "______";
            textBox1.Text = "";
        }
    }
}
