using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace college_management
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            menuStrip1.Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void aboutUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutUs au=new AboutUs();
            au.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            String username=textBox1.Text;
            String password= textBox2.Text;
            if(username=="student"&& password=="student")
            {
                menuStrip1.Visible = true;
                panel1.Visible = false;
            }
            else
            {
                MessageBox.Show("Invalid UserId or Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void newAdmissionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            New_Admission na=new New_Admission();
            na.Show();
        }

        private void upgradeSemesterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpgradeSemester us=new UpgradeSemester();
            us.Show();
        }

        private void feesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Fees fs=new Fees();
            fs.Show();
        }

        private void searchStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
             SearchStudent ss =new SearchStudent(); 
            ss.Show();
        }
   

        private void individualDetailsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            StudentIndividualDetail sid = new StudentIndividualDetail();
            sid.Show();
        }

        private void addTeacherInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddTeacher at = new AddTeacher();  
            at.Show();
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchTeacher st = new SearchTeacher();
            st.Show();
        }

        private void removeStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveStudent rs = new RemoveStudent();
            rs.Show();
        }

        private void exitSystemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure ? This will Delete your UNSAVED Data","Confirmation Dialog!",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning)==DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void salaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Salary s=new Salary();
            s.Show();
        }
    }
}
