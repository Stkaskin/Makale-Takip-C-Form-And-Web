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
    public partial class MakaleSecim : Form
    {
        string onaydurum0 = "Alan Editör Ataması";
        string onaydurum1 = "Hakem Ataması";
        string onaydurum2 = "Hakem Onayı";
        string onaydurum3 = "Onay Mesajı";
        string onaydurum4 = "Red Mesajı";
        string onaydurum5 = "Revizyon";
        string onaydurum6 = "Onaylandı";
        string onaydurum7 = "Red Edildi";
        string onaydurum8 = "Editör Red Etti";
        public MakaleSecim()
        {
            InitializeComponent();
        }
        private class makalesecimtablo{
            public int ID { get; set; }
            public int? Makale{ get; set; }
            public string Yazar{ get; set; }
            public string Onay{ get; set; }
        

                
        }
        List<makalesecimtablo> liste = new List<makalesecimtablo>();
        List<makalesecimtablo> listetutucu = new List<makalesecimtablo>();
 private void ilkarama()
        {
         
            MakaleEntities db = new MakaleEntities();
         var listecek = (from a in db.Makaleİslem
                                        join b in db.Yazar on a.yazarid equals b.id
                                        join c in db.Makale on a.makaleid equals c.id
                                       
                                        select new makalesecimtablo
                                        {
                                            ID = a.id,
                                            Makale = a.makaleid,
                                            Yazar = b.ad,
                                            Onay = c.onay != null ? c.onay == 0 ? onaydurum0 : c.onay == 1 ? onaydurum1 : c.onay == 2 ? onaydurum2 : c.onay == 3 ? onaydurum4 : c.onay == 4 ? onaydurum4 : c.onay == 5 ? onaydurum5 : c.onay == 6 ? onaydurum6 : c.onay == 7 ? onaydurum1 : c.onay == 8 ? onaydurum8 : "Baş Editör" : "BOŞ"
                                        }).ToList();
            dataGridView1.DataSource = listecek;
            listetutucu = listecek;

        }
        private void arama(string arama)
        {
            liste = listetutucu;
            if (arama!=null) {
                liste = liste.Where(x => x.Onay == arama).ToList();
            }
            dataGridView1.DataSource = liste;
            Tdatab();
        }
        private void MakaleSecim_Load(object sender, EventArgs e)
        {
            ilkarama();
            Tdatab();
      
            
        }
        private void Tdatab()
        {

           label1.DataBindings.Clear();
           label2.DataBindings.Clear();
           label3.DataBindings.Clear();
           label4.DataBindings.Clear();
   

            label1.DataBindings.Add("Text", dataGridView1.DataSource, "ID");
            label2.DataBindings.Add("Text", dataGridView1.DataSource, "Makale");
            label3.DataBindings.Add("Text", dataGridView1.DataSource, "Yazar");
            label4.DataBindings.Add("Text", dataGridView1.DataSource, "onay");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            if (label2.Text != "") {
                Editör Feditor = (Editör)Application.OpenForms["Editör"];
                Feditor.makaleid = Convert.ToInt32(label2.Text);
            }
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            arama(null);
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            arama(onaydurum0);
          
         
        }

        private void button4_Click(object sender, EventArgs e)
        {
            arama(onaydurum1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            arama(onaydurum3);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            arama(onaydurum4);
        }

        private void button7_Click(object sender, EventArgs e)
        {/*
          
          
            string onaydurum0 = "Alan Editör Ataması";
        string onaydurum1 = "Hakem Ataması";
        string onaydurum2 = "Hakem Onayı";
        string onaydurum3 = "Onay Mesajı";
        string onaydurum4 = "Red Mesajı";
        string onaydurum5 = "Revizyon";
        string onaydurum6 = "Onaylandı";
        string onaydurum7 = "Red Edildi";
        string onaydurum8 = "Editör Red Etti";
          */
            arama(onaydurum5);
        }

        private void button8_Click(object sender, EventArgs e)
        {

            arama(onaydurum2);
        }

        private void button9_Click(object sender, EventArgs e)
        {

        }
    }
}
