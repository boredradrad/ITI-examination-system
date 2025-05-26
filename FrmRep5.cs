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
using Microsoft.Reporting.WinForms;

namespace Examination_GUI
{
    public partial class FrmRep5 : Form
    {
       SqlConnection con;

        public FrmRep5()
        {
            InitializeComponent();
        }

        private void FrmRep5_Load(object sender, EventArgs e)
        {

            // Initialize the connection
            con = new SqlConnection(GlobalVars.ConnectionString);

            SqlCommand sqlCommand = new SqlCommand("GetExamIDsByCourse", con);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@ins_id", GlobalVars.InsID);
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            DataTable dt2 = new DataTable();
            adapter.Fill(dt2);

            for(int i = 0; i < dt2.Rows.Count; i++)
            {
                comboBox1.Items.Add(dt2.Rows[i][0]);
            }



            // Report viewer settings
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = GlobalVars.RDlFolder + "Report5.rdl";

            SqlCommand cmd = new SqlCommand("Exno_Questions_freeform", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@exam_id", 10); // Default exam ID

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            ReportDataSource rds = new ReportDataSource("DataSet1", dt);

            // Add the report parameter to the ReportViewer
            ReportParameter[] parameters = new ReportParameter[1];
            parameters[0] = new ReportParameter("exam_id", "10"); // Default value

            reportViewer1.LocalReport.SetParameters(parameters);
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.RefreshReport();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            int examId;
            //int.TryParse(textBox1.Text, out examId);
            //label1.Text = examId.ToString();

            int.TryParse(comboBox1.SelectedItem.ToString(), out examId);
            if (examId > 0)
            {
                reportViewer1.ProcessingMode = ProcessingMode.Local;
                reportViewer1.LocalReport.ReportPath = GlobalVars.RDlFolder + "Report5.rdl";

                SqlCommand cmd = new SqlCommand("Exno_Questions_freeform", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@exam_id", examId);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                reportViewer1.LocalReport.DataSources.Clear();
                ReportDataSource rds = new ReportDataSource("DataSet1", dt);

                reportViewer1.LocalReport.DataSources.Add(rds);
                reportViewer1.RefreshReport();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InstructorMenu instructorMenu = new InstructorMenu();
            this.Hide();
            instructorMenu.ShowDialog();
        }
    }
}
