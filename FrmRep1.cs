using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
 
namespace Examination_GUI
{
    public partial class FrmRep1 : Form
    {
 
        SqlConnection con;
        public FrmRep1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //Initialize the connection
            con = new SqlConnection(GlobalVars.ConnectionString);
            //Report viewer

            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = GlobalVars.RDlFolder + "Report1.rdl";
            SqlCommand cmd = new SqlCommand("DeptID_Student", con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@dept_id", 10);

            //foreach (SqlParameter param in cmd.Parameters)
            //{
            //    Console.WriteLine($"{param.ParameterName}: {param.Value}");
            //}
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            ReportDataSource rds = new ReportDataSource("DataSet1", dt);
            // Add the report parameter to the ReportViewer
            ReportParameter[] parameters = new ReportParameter[1];
            parameters[0] = new ReportParameter("dept_id", "10"); // Pass the value you want (e.g., 10)
            reportViewer1.LocalReport.SetParameters(parameters);

            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.RefreshReport();
            //this.reportViewer2.RefreshReport();


        }
        private void button1_Click(object sender, EventArgs e)
        {
            int depId;
            int.TryParse(textBox1.Text, out depId);
            label1.Text = depId.ToString();
            if (depId > 0)
            {
                reportViewer1.ProcessingMode = ProcessingMode.Local;
                reportViewer1.LocalReport.ReportPath = GlobalVars.RDlFolder + "Report1.rdl";
                SqlCommand cmd = new SqlCommand("DeptID_Student", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@dept_id", depId);


                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                reportViewer1.LocalReport.DataSources.Clear();
                ReportDataSource rds = new ReportDataSource("DataSet1", dt);

                reportViewer1.LocalReport.DataSources.Add(rds);
                reportViewer1.RefreshReport();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            InstructorMenu instructorMenu = new InstructorMenu();
            this.Hide();
            instructorMenu.ShowDialog();
           
        }

        //private void label1_Click(object sender, EventArgs e)
        //{

        //}
    }
}
