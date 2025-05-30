﻿using Microsoft.Reporting.WinForms;
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


namespace Examination_GUI
{
    public partial class InstructorMainPage : Form
    {
        
        SqlConnection con;
        public InstructorMainPage()
        {
            InitializeComponent();
        }

        private void InstructorMainPage_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id;
            if(int.TryParse(textBox1.Text.Trim(), out id))
            {
                con = new SqlConnection(GlobalVars.ConnectionString);
                SqlCommand cmd = new SqlCommand("Instructor_Select", con);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ins_id", id);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if(dt.Rows.Count > 0 && textBox2.Text == (id.ToString() + "@1234"))
                {
                    //Move to Next Page
                    GlobalVars.InsID = id;
                    InstructorMenu instructorMenu = new InstructorMenu();
                    this.Close();
                    instructorMenu.ShowDialog();
                    Warning.Visible = false;
                }    
                else
                {
                    Warning.Visible = true;
                }

            }
            else
            {
                Warning.Visible = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EntryPoint entryPoint = new EntryPoint();
            Hide();
            entryPoint.ShowDialog();
        }
    }
}
