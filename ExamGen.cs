using Microsoft.Reporting.WinForms;
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

namespace Examination_GUI
{
    public partial class ExamGen : Form
    {
        SqlConnection con = new SqlConnection();
        DataTable dt;

        public ExamGen()
        {
            InitializeComponent();

            con = new SqlConnection(GlobalVars.ConnectionString);

            SqlCommand cmd = new SqlCommand("Instructor_Courses_Names", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ins_id", GlobalVars.InsID);
            SqlDataAdapter da = new SqlDataAdapter(cmd); 
             dt = new DataTable();
            da.Fill(dt);

            for(int i = 0; i < dt.Rows.Count; i++)
            {
                comboBox1.Items.Add(dt.Rows[i][1].ToString());
            }
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            InstructorMenu instructorMenu = new InstructorMenu();
            this.Hide();
            instructorMenu.ShowDialog();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            int cid = -1;

            cid = int.Parse(dt.Rows[comboBox1.SelectedIndex][0].ToString());

            SqlCommand cmd = new SqlCommand("[GenerateExam]", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@crs_id",cid);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt2 = new DataTable();
            da.Fill(dt2);

            int examId;
            if (dt2.Rows.Count > 0)
            {
              int.TryParse(dt2.Rows[0][0].ToString(),out examId);
                if (examId > 0)
                {
                    if (examId > 0)
                    {
                        reportViewer1.ProcessingMode = ProcessingMode.Local;
                        reportViewer1.LocalReport.ReportPath = GlobalVars.RDlFolder + "Report5.rdl";
                        ReportParameter[] parameters = new ReportParameter[1];
                        parameters[0] = new ReportParameter("exam_id", "-1"); // Default value
                        reportViewer1.LocalReport.SetParameters(parameters);


                        cmd = new SqlCommand("Exno_Questions_freeform", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@exam_id", examId);

                         da = new SqlDataAdapter(cmd);
                        DataTable dt3 = new DataTable();
                        da.Fill(dt3);

                        reportViewer1.LocalReport.DataSources.Clear();
                        ReportDataSource rds = new ReportDataSource("DataSet1", dt3);

                        reportViewer1.LocalReport.DataSources.Add(rds);
                        reportViewer1.RefreshReport();
                    }
                }



            }
        }
    }
}
