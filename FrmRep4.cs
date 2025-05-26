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
    public partial class Report4 : Form
    {
         SqlConnection con;

        public Report4()
        {
            InitializeComponent();
        }

        private void FrmRep4_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(GlobalVars.ConnectionString);

           
              SqlCommand sqlCommand = new SqlCommand("GetCoursesNames", con);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da2 = new SqlDataAdapter(sqlCommand);
                    DataTable dt2 = new DataTable();
                    da2.Fill(dt2);

                    foreach (DataRow dr in dt2.Rows) {
                        comboBox1.Items.Add(dr[0].ToString());
                    }

            // Initialize the connection
           

            // Report viewer settings
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = GlobalVars.RDlFolder + "Report4.rdl";

            SqlCommand cmd = new SqlCommand("CrsID_Topic", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@crs_id", 10); // Default course ID

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            ReportDataSource rds = new ReportDataSource("DataSet1", dt);

            // Add the report parameter to the ReportViewer
            ReportParameter[] parameters = new ReportParameter[1];
            parameters[0] = new ReportParameter("crs_id", "10"); // Default value

            reportViewer1.LocalReport.SetParameters(parameters);
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.RefreshReport();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            int crsId =0;
            crsId = comboBox1.SelectedIndex + 1;
      

            if (crsId > 0)
            {
                reportViewer1.ProcessingMode = ProcessingMode.Local;
                reportViewer1.LocalReport.ReportPath = GlobalVars.RDlFolder + "Report4.rdl";

                SqlCommand cmd = new SqlCommand("CrsID_Topic", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@crs_id", crsId);

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

            StudentMenu studentMenu = new StudentMenu();
            this.Hide();
            this.Owner.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
    
           

        }
    }
}
