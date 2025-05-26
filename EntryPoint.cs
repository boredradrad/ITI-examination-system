using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examination_GUI
{
    public partial class EntryPoint : Form
    {
        public EntryPoint()
        {
            InitializeComponent();
        }

        private void InstBtn_Click(object sender, EventArgs e)
        {
            InstructorMainPage instructorMainPage = new InstructorMainPage();
            this.Hide();
            instructorMainPage.Show();
            
        }

        private void StdBtn_Click(object sender, EventArgs e)
        {

            StudentMainPage studentMainPage = new StudentMainPage();
            this.Hide();
            studentMainPage.Show();

        }
    }
}
