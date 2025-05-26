using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Examination_GUI
{
    public partial class StudentMenu : Form
    {
        
        public StudentMenu()
        {
           

            InitializeComponent();
            
        }

        private void btnReport1_Click(object sender, EventArgs e)
        {
            FrmRep2 frm2 = new FrmRep2();
            this.Hide();
            frm2.Owner = this;
            frm2.ShowDialog();
           
        }

        private void btnReport2_Click(object sender, EventArgs e)
        {
            FrmRep6 frm6 = new FrmRep6();  
            this.Hide();
            frm6.Owner = this;
            frm6.ShowDialog();
        }

        private void btnReport3_Click(object sender, EventArgs e)
        {
            Report4 frm4 = new Report4(); 
            this.Hide();
            frm4.Owner = this;
            frm4.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            EntryPoint er = new EntryPoint();
            this.Hide();
            er.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            pickCrsExam pCE = new pickCrsExam();
            this.Hide();
            pCE.ShowDialog();
        }

        private void StudentMenu_Load(object sender, EventArgs e)
        {
            // Establish connection
            SqlConnection con = new SqlConnection(GlobalVars.ConnectionString);

            // Execute a command of type Stored procedure
            // i.e., EXEC Instructor_Select @ins_id=GlobalVars.InsID
            SqlCommand cmd = new SqlCommand("Student_Select", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@st_id", GlobalVars.Std);

            // Get data rows
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            // Access the fname and lname columns of the retrieved result
            label3.Text = (dt.Rows[0][1].ToString().Trim() + " " + dt.Rows[0][2].ToString());
        }
    }
}
