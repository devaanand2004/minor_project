using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace college_management
{
    public partial class RemoveStudent : Form
    {
        public RemoveStudent()
        {
            InitializeComponent();
        }

        private void RemoveStudent_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source=DEVA\\SQLEXPRESS;database=college;integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from NewAdmission";
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();

            DA.Fill(DS);
            dataGridViewDELStudent.DataSource = DS.Tables[0];
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("This will DELETE Your Data !! ", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (result == DialogResult.OK)
            {
                try
                {
                    using (SqlConnection con = new SqlConnection("data source=DEVA\\SQLEXPRESS;database=college;integrated security=True"))
                    {
                        con.Open();
                        string sql = "DELETE FROM NewAdmission WHERE NAID = @NAID";
                        SqlCommand cmd = new SqlCommand(sql, con);
                        // Assuming NAID is an integer, you should validate the input before using it.
                        cmd.Parameters.AddWithValue("@NAID", Convert.ToInt32(txtRegID.Text));

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Deletion Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // Refresh your DataGridView if needed
                        }
                        else
                        {
                            MessageBox.Show("No records deleted.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }
    }
}
