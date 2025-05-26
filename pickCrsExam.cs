using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Examination_GUI
{
    public partial class pickCrsExam : Form
    {

        SqlConnection con;
        SqlDataAdapter daCourses = new SqlDataAdapter();
        DataTable dtCourses = new DataTable();
        string selectedCrsString = "";
        public pickCrsExam()
        {
            InitializeComponent();
        }

        private void pickCrsExam_Load_1(object sender, EventArgs e)
        {
            
            
            con = new SqlConnection(GlobalVars.ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("StID_Courses", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@st_id", GlobalVars.Std);
            daCourses = new SqlDataAdapter(cmd);
            dtCourses.Clear();
            daCourses.Fill(dtCourses);

            if (dtCourses.Rows.Count > 0)
            {
                label4.Text = dtCourses.Rows[0][0].ToString(); // name col
                label5.Text = GlobalVars.Std.ToString();
                comboBox1.Items.Clear();
                Console.WriteLine(dtCourses.Rows.Count);
                for (int i = 0; i < dtCourses.Rows.Count; i++)
                {
                    comboBox1.Items.Add(dtCourses.Rows[i][3].ToString());
                }

                if (comboBox1.Items.Count > 0)
                {
                    comboBox1.SelectedIndex = 0;
                    selectedCrsString = comboBox1.SelectedItem.ToString().Trim().TrimEnd();
                }
                else
                {
                    button1.Visible = false;
                }
            }
            else
            {
                label4.Text = "No data found";
                label5.Text = "No data found";
            }
            
        } 
        private void button1_Click_1(object sender, EventArgs e)
        {
            selectedCrsString = comboBox1.SelectedItem.ToString().Trim().TrimEnd();
            Console.WriteLine(selectedCrsString);
            takeExam tE = new takeExam(selectedCrsString);
            this.Hide();
            tE.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StudentMenu studentMenu = new StudentMenu();
            Hide();
            studentMenu.ShowDialog();
        }
    }
}