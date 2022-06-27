using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AljenFormProject.Modules
{
    public partial class MenuGenel : Form
    {
        public MenuGenel()
        {
            InitializeComponent();
        }



        private void button2_Click(object sender, EventArgs e)
        {
            Tanımlama tnm = new Tanımlama();
            tnm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Editör editör = new Editör();
            editör.ShowDialog();
        }

        private void MenuGenel_FormClosing(object sender, FormClosingEventArgs e)
        {
            Login login = (Login)Application.OpenForms["Login"];
            login.Show();
        }
    }
}
