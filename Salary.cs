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
    public partial class Salary : Form
    {
        public Salary()
        {
            InitializeComponent();
        }

        private void txtTeacherID_TextChanged(object sender, EventArgs e)
        {

            if (txtTeacherID.Text != "")
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source=DEVA\\SQLEXPRESS;database=college;integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select fname,mobile,yer from teacher where tID=" + txtTeacherID.Text + " ";
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();

                DA.Fill(DS);
                if (DS.Tables[0].Rows.Count != 0)
                {
                    fNamelabel.Text = DS.Tables[0].Rows[0][0].ToString();
                    MobileNolabel.Text = DS.Tables[0].Rows[0][1].ToString();
                    durationlabel.Text = DS.Tables[0].Rows[0][2].ToString();
                }
                else
                {
                    fNamelabel.Text = "______";
                    MobileNolabel.Text = "______";
                    durationlabel.Text = "______";

                }



            }
            else
            {
                fNamelabel.Text = "______";
                MobileNolabel.Text = "______";
                durationlabel.Text = "______";


            }

        }

        private void btnPay_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source=DEVA\\SQLEXPRESS;database=college;integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from salary where tID =" + txtTeacherID.Text + "";
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();

            DA.Fill(DS);

            if (DS.Tables[0].Rows.Count == 0)
            {
                SqlConnection con1 = new SqlConnection();
                con1.ConnectionString = "data source=DEVA\\SQLEXPRESS;database=college;integrated security=True";
                SqlCommand cmd1 = new SqlCommand();
                cmd1.Connection = con1;
                cmd1.CommandText = "insert into salary (tID,Salary) values (" + txtTeacherID.Text + "," + txtSalary.Text + ")";
                SqlDataAdapter DA1 = new SqlDataAdapter(cmd1);
                DataSet DS1 = new DataSet();
                DA1.Fill(DS1);
                if (MessageBox.Show("Salary Credited successfull.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) == DialogResult.OK)
                {
                    txtTeacherID.Text = "";
                    txtSalary.Text = "";
                    fNamelabel.Text = "______";
                    MobileNolabel.Text = "______";
                    durationlabel.Text = "______";
                }





            }
            else
            {
                MessageBox.Show("Salary was Already PAID !!");
                txtTeacherID.Text = "";
                txtSalary.Text = "";
                fNamelabel.Text = "______";
                MobileNolabel.Text = "______";
                durationlabel.Text = "______";
            }
        }
    }
}
