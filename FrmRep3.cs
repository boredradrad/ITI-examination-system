using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace Examination_GUI
{
    public partial class FrmRep3 : Form
    {
          SqlConnection con;

        public FrmRep3()
        {
            InitializeComponent();
        }

        private void FrmRep3_Load(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(GlobalVars.ConnectionString);
                con.Open(); // Open connection

                reportViewer1.ProcessingMode = ProcessingMode.Local;
                reportViewer1.LocalReport.ReportPath = GlobalVars.RDlFolder + "Report3.rdl";

                SqlCommand cmd = new SqlCommand("InsID_Courses_NumStudents", con);
                cmd.CommandType = CommandType.StoredProcedure;

                int id = GlobalVars.InsID;
                label1.Text = "Courses for instructor : " + id;
                // Define parameter explicitly
              //  cmd.Parameters.Add("@ins_id", SqlDbType.Int).Value = 10;
                cmd.Parameters.AddWithValue("@ins_id", id);


                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                ReportDataSource rds = new ReportDataSource("DataSet1", dt);
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(rds);

                // Set report parameter
                ReportParameter param = new ReportParameter("ins_id", id.ToString());
                reportViewer1.LocalReport.SetParameters(param);

                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                con.Close(); // Ensure connection is closed
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
