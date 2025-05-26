using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Examination_GUI
{
    public partial class takeExam : Form
    {
        SqlConnection con;
        private int CurrQ = 0;
        private int crs_id = 0;
        string exam_id = "";
        SqlDataAdapter da3 = new SqlDataAdapter();
        DataTable dt3 = new DataTable(); // Keep only the class-level dt3

        public takeExam(string selectedCrsString)
        {
            if (selectedCrsString == "Database")
                crs_id = 1;
            if (selectedCrsString == "Operating systems")
                crs_id = 2;
            if (selectedCrsString == "Object Oriented Programming")
                crs_id = 3;
            if (selectedCrsString == "Network fundamentals")
                crs_id = 4;
            if (selectedCrsString == "Data structures")
                crs_id = 5;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label6.Text = "You Have taken 2 Exams for each enrolled course";
            label5.Text = "Exam Taken Succesfully!";
            button2.Visible = false;
            radioButton1.Text = "";
            radioButton2.Text = "";
            radioButton3.Text = "";
            radioButton4.Text = "";
            label5.Visible = false;
            label6.Visible = false;
            button3.Visible = false;

            // EXEC PickRandomExam @crs_id = 4, @st_id = 5
            con = new SqlConnection(GlobalVars.ConnectionString);
            SqlCommand cmd = new SqlCommand("PickRandomExam", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@st_id", GlobalVars.Std);
            cmd.Parameters.AddWithValue("@crs_id", crs_id);

            SqlDataAdapter da2 = new SqlDataAdapter(cmd);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);

            if (dt2.Rows.Count > 0)
            {
                exam_id = dt2.Rows[0][0].ToString();
                label2.Text = exam_id;
            }
            else
            {

                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;

                radioButton1.Visible = false;
                radioButton2.Visible = false;
                radioButton3.Visible = false;
                radioButton4.Visible = false;
                button1.Visible = false;

                button3.Visible = true;
                label5.Text = "You Have taken 2 Exams for this course";

                label5.Visible = true;
                button1.Visible = false;
                return;
            }


            // arary of questions GetQuestion
            cmd = new SqlCommand("GetQuestion", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@exam_id", int.Parse(exam_id));

            da3 = new SqlDataAdapter(cmd);
            dt3.Clear(); 
            da3.Fill(dt3);

            if (dt3.Rows.Count > 0)
            {
                LoadQuestion(0);
            }
        }

        private void LoadQuestion(int index)
        {
            if (dt3.Rows.Count > index) 
            {
                label4.Text = (CurrQ + 1).ToString();
                label3.Text = dt3.Rows[index][1].ToString();
                radioButton1.Text = dt3.Rows[index][2].ToString();
                radioButton2.Text = dt3.Rows[index][3].ToString();
                radioButton3.Text = "";
                radioButton4.Text = "";

                if (!string.IsNullOrEmpty(dt3.Rows[index][4].ToString()))
                {
                    radioButton3.Text = dt3.Rows[index][4].ToString();
                    radioButton3.Visible = true;
                }
                else
                {
                    radioButton3.Visible = false;
                }

                if (!string.IsNullOrEmpty(dt3.Rows[index][5].ToString()))
                {
                    radioButton4.Text = dt3.Rows[index][5].ToString();
                    radioButton4.Visible = true;
                }
                else
                {
                    radioButton4.Visible = false;
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Console.WriteLine(CurrQ);
            string ans = "";

            if (radioButton1.Checked) ans = "A";
            if (radioButton2.Checked) ans = "B";
            if (radioButton3.Checked) ans = "C";
            if (radioButton4.Checked) ans = "D";

            // EXEC AnswerQuestion @exam_id = 2, @ques_id = 3 , @answer = 'B'
            SqlCommand cmd;
            //Console.WriteLine(int.Parse(exam_id) +"-" + dt3.Rows[CurrQ][0] + ans);
            if (CurrQ < 10)
            {
                cmd = new SqlCommand("AnswerQuestion", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@exam_id", int.Parse(exam_id));
                cmd.Parameters.AddWithValue("@ques_id", int.Parse(dt3.Rows[CurrQ][0].ToString()));
                cmd.Parameters.AddWithValue("@answer", ans);


                SqlDataAdapter d4 = new SqlDataAdapter(cmd);
                DataTable d44 = new DataTable();
                d4.Fill(d44);

                CurrQ++;
                LoadQuestion(CurrQ);
            }
            if (CurrQ==10)
            {
                button1.Visible= false;
                button2.Visible = true;
                // Exam Correction + Course Grading
                cmd = new SqlCommand("Grade_Exam", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@exam_id", int.Parse(exam_id));
                cmd.Parameters.AddWithValue("@std_id", GlobalVars.Std);
                cmd.Parameters.AddWithValue("@crs_id", crs_id);
                
                SqlDataAdapter d4 = new SqlDataAdapter(cmd);
                DataTable dt4 = new DataTable();
                d4.Fill(dt4);
                Console.WriteLine(dt4.Rows[0][0].ToString());

                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;

                label5.Visible = true;

                radioButton1.Visible = false;
                radioButton2.Visible = false;
                radioButton3.Visible = false;
                radioButton4.Visible = false;
                button1.Visible = false;
                

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StudentMenu studentMenu = new StudentMenu();
            Hide(); 
            studentMenu.Show();
            
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            StudentMenu studentMenu = new StudentMenu();
            Hide();
            studentMenu.ShowDialog();
        }
    }
}
