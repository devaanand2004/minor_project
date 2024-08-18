using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace college_management
{
    public partial class Fees : Form
    {
        public Fees()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtRegistrationNo_TextChanged(object sender, EventArgs e)
        {
            if(txtRegistrationNo.Text!="")
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source=DEVA\\SQLEXPRESS;database=college;integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select fname,mname,duration from NewAdmission where NAID=" + txtRegistrationNo.Text + " ";
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();

                DA . Fill(DS);
                if (DS.Tables[0].Rows.Count != 0 )
                {
                    fnameLabel.Text = DS.Tables[0].Rows[0][0].ToString();
                    MnameLabel.Text = DS.Tables[0].Rows[0][1].ToString();
                    durationLabel.Text = DS.Tables[0].Rows[0][2].ToString();
                }
                else
                {
                    fnameLabel.Text = "_____________";
                    MnameLabel.Text = "_____________";
                    durationLabel.Text = "_____________";

                }



            }
            else
            {
                fnameLabel.Text = "_____________";
                MnameLabel.Text = "_____________";
                durationLabel.Text = "_____________";

            }



        }

        private void durationLabel_Click(object sender, EventArgs e)
        {

        }

    

  

        private void btnSubmit_Click_1(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source=DEVA\\SQLEXPRESS;database=college;integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from fees where NAID =" + txtRegistrationNo.Text + "";
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();

            DA.Fill(DS);

            if (DS.Tables[0].Rows.Count == 0)
            {
                SqlConnection con1 = new SqlConnection();
                con1.ConnectionString = "data source=DEVA\\SQLEXPRESS;database=college;integrated security=True";
                SqlCommand cmd1 = new SqlCommand();
                cmd1.Connection = con1;
                cmd1.CommandText = "insert into fees (NAID,fees) values (" + txtRegistrationNo.Text + "," + txtFees.Text + ")";
                SqlDataAdapter DA1 = new SqlDataAdapter(cmd1);
                DataSet DS1 = new DataSet();
                DA1.Fill(DS1);
                if (MessageBox.Show("Fees Submition successfull.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) == DialogResult.OK)
                {
                    txtRegistrationNo.Text = "";
                    txtFees.Text = "";
                    fnameLabel.Text = "_____________";
                    MnameLabel.Text = "_____________";
                    durationLabel.Text = "_____________";
                }





            }
            else
            {
                MessageBox.Show("Fees was Already Submitted !!");
                txtRegistrationNo.Text = "";
                txtFees.Text = "";
                fnameLabel.Text = "_____________";
                MnameLabel.Text = "_____________";
                durationLabel.Text = "_____________";
            }
        }

        private void Fees_Load(object sender, EventArgs e)
        {

        }
    }
    }
