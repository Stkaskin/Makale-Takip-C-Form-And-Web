using AljenFormProject.Database;
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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

     
        private void button1_Click(object sender, EventArgs e)
        {
            MakaleEntities db = new MakaleEntities();
            string t1 = textBox1.Text, t2 = textBox2.Text;
            AljenFormProject.Database.Editör editör= db.Editör.Where(x => x.yetki==1 && x.mail==t1 && x.parola==t2).FirstOrDefault();
            if (editör != null) {
                MenuGenel gnl = new MenuGenel();
                gnl.Show();
                textBox1.Text = null;
                textBox2.Text = null;
       
                this.Hide();
            }
            else { MessageBox.Show("Giriş Başarısız."); }
                }  
        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("HAKEM GİRİS WEB SİTESİNE YÖNLENDİRİLDİNİZ.");
        }

        private void button3_Click(object sender, EventArgs e)
        {

            MessageBox.Show("ALAN EDİTÖR GİRİS WEB SİTESİNE YÖNLENDİRİLDİNİZ.");
        }

    }
}
