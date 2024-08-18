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
    public partial class UpgradeSemester : Form
    {
        public UpgradeSemester()
        {
            InitializeComponent();
        }

        private void btnUpgrade_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Semester Upgrade Warning!", "Confirm?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                using (SqlConnection con = new SqlConnection("data source=DEVA\\SQLEXPRESS;database=college;integrated security=True"))
                {
                    con.Open();

                    string query = "UPDATE NewAdmission SET semester = @NewSemester WHERE semester = @OldSemester";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@NewSemester", comboBoxTo.Text);
                        cmd.Parameters.AddWithValue("@OldSemester", comboBoxFrom.Text);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Upgrade Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No records were updated.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Upgrade Cancelled", "Cancel", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void UpgradeSemester_Load(object sender, EventArgs e)
        {

        }
    }
}
