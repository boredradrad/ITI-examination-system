using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Examination_GUI
{
    public partial class FrmRep6 : Form
    {
        SqlConnection con;
        DataTable dt2;
        DataTable dt3;

        public FrmRep6()
        {
            InitializeComponent();
        }

        private void FrmRep6_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(GlobalVars.ConnectionString);
            if (this.Owner != null)
            {
                if (this.Owner.Name == "StudentMenu")
                {
                   labelStId.Text = "Student ID: " + GlobalVars.Std;
                   textBoxStId.Visible = false;


                    SqlCommand sqlCommand = new SqlCommand("GetCoursesNames", con);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da2 = new SqlDataAdapter(sqlCommand);
                    dt2 = new DataTable();
                    da2.Fill(dt2);

                    sqlCommand = new SqlCommand("Student_Taken_Exams", con);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@st_id",GlobalVars.Std);
                    da2 = new SqlDataAdapter(sqlCommand);
                    dt3 = new DataTable();
                    da2.Fill(dt3);

                    int cst;
                    DataRow drr;
                    for (int i = 0; i < dt3.Rows.Count; i++)
                    {
                        drr = dt3.Rows[i];
                        if (int.TryParse(drr[0].ToString(), out cst))
                            comboBox1.Items.Add(dt2.Rows[cst - 1][0].ToString());
                    }

                    labelCrsId.Text = "Select Course";
                    textBoxCrsId.Visible = false;
                    comboBox1.Visible = true;

                }
            }
            else
            {
                Console.WriteLine("No Owner");
            }
          //  LoadReport(1, 10); // Default values
        }

      

        private void LoadReport(int crsId, int stId)
        {
            try
            {
                
                con = new SqlConnection(GlobalVars.ConnectionString);
                con.Open();

                SqlCommand cmd = new SqlCommand("Exno_Questions_freeform_solved", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@crs_id", SqlDbType.Int).Value = crsId;
                cmd.Parameters.Add("@st_id", SqlDbType.Int).Value = stId;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                reportViewer1.ProcessingMode = ProcessingMode.Local;
                reportViewer1.LocalReport.ReportPath = GlobalVars.RDlFolder + "Report6.rdl";
                reportViewer1.LocalReport.DataSources.Clear();

                ReportDataSource rds = new ReportDataSource("DataSet1", dt);
                reportViewer1.LocalReport.DataSources.Add(rds);

                // Update report parameters
                ReportParameter[] parameters = new ReportParameter[]
                {
                    new ReportParameter("crs_id", crsId.ToString()),
                    new ReportParameter("st_id", stId.ToString())
                };

                reportViewer1.LocalReport.SetParameters(parameters);
                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (con != null && con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StudentMenu studentMenu = new StudentMenu();
            this.Hide();
            this.Owner.Show();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            try
            {
                //Db 1
                //Network 2 
            int crsId = 1, stId = 10; // Default values
            if (this?.Owner?.Name == "StudentMenu") 
            {
                stId = GlobalVars.Std;
                int indd = comboBox1.SelectedIndex;
                crsId = int.Parse(dt3.Rows[comboBox1.SelectedIndex][0].ToString());
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(textBoxCrsId.Text) && int.TryParse(textBoxCrsId.Text, out int userCrsId))
                    crsId = userCrsId;
                if (!string.IsNullOrWhiteSpace(textBoxStId.Text) && int.TryParse(textBoxStId.Text, out int userStId))
                    stId = userStId;
            }
            LoadReport(crsId, stId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}

