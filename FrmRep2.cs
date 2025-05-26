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
    public partial class FrmRep2 : Form
    {
         SqlConnection con;

        public FrmRep2()
        {
            InitializeComponent();
        }

        private void FrmRep2_Load(object sender, EventArgs e)
        {
            int def =10;
            if (this.Owner != null)
            {
                if(this.Owner.Name == "StudentMenu") {

                    def = GlobalVars.Std;
                    btnEnter.Visible = false;
                    textBox1.Visible = false;
                    label1.Text = "Courses for student with ID: " + def.ToString();
                }
            }
            else
            {
                Console.WriteLine("No Owner");
            }
            // Initialize the connection
            con = new SqlConnection(GlobalVars.ConnectionString);

            // Report viewer settings
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = GlobalVars.RDlFolder + "Report2.rdl";

            SqlCommand cmd = new SqlCommand("StID_Courses", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@st_id", def); // Default student ID

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            ReportDataSource rds = new ReportDataSource("DataSet1", dt);

            // Add the report parameter to the ReportViewer
            ReportParameter[] parameters = new ReportParameter[1];
            parameters[0] = new ReportParameter("st_id", def.ToString()); // Default value

            reportViewer1.LocalReport.SetParameters(parameters);
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.RefreshReport();
        }



        private void btnEnter_Click(object sender, EventArgs e)
        {
            int stId;
            int.TryParse(textBox1.Text, out stId);
            label1.Text = stId.ToString();

            if (stId > 0)
            {
                reportViewer1.ProcessingMode = ProcessingMode.Local;
                reportViewer1.LocalReport.ReportPath = GlobalVars.RDlFolder + "Report2.rdl";

                SqlCommand cmd = new SqlCommand("StID_Courses", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@st_id", stId);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                reportViewer1.LocalReport.DataSources.Clear();
                ReportDataSource rds = new ReportDataSource("DataSet1", dt);

                reportViewer1.LocalReport.DataSources.Add(rds);
                reportViewer1.RefreshReport();
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            StudentMenu studentMenu = new StudentMenu();
            this.Hide();
            this.Owner.Show();
           // studentMenu.ShowDialog();
        }
    }
}
