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
    public partial class Tanımlama : Form
    {
        string talaneditor = "Alan Editörü";
        string tyazar = "Yazar";
        string thakem = "Hakem";
        string taktif = "Aktif";
        string tpasif = "Pasif";
        string tSonArama = null;

        MakaleEntities db = new MakaleEntities();
        public Tanımlama()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (Cyetki.SelectedIndex == 0)
            {
                Yazar item = new Yazar();
                item.ad = Tad.Text;

                item.mail = Tmail.Text;
                //99999
                item.sonislem = 1;
                //99999
                //     yazar.tur = "";


                db.Yazar.Add(item);
                db.SaveChanges();
            }
            else if (Cyetki.SelectedIndex == 1)
            {
                Database.Editör item = new Database.Editör();
                item.ad = Tad.Text;

                item.mail = Tmail.Text;
                //99999
                item.sonislem = DateTime.Now;
                //99999
                item.tel = "";
                //9999
                item.yetki = 2;


                //   item.yasaklama = ((Cyasak.SelectedIndex + 1) % 1).ToString();
                db.Editör.Add(item);
                db.SaveChanges();

            }

            else if (Cyetki.SelectedIndex == 2)
            {
                Database.Hakem item = new Hakem();
                item.ad = Tad.Text;

                item.alan = "random";


              
                //    item.yasaklama =((Cyasak.SelectedIndex + 1) % 1).ToString();
                db.Hakem.Add(item);
                db.SaveChanges();
            }
            else if (Cyetki.SelectedIndex == 3)
            {

            }
            Analistetutucu = startF(listem);
            aramafonksiyon(null);
            string sonarama = tSonArama;
            aramafonksiyon(talaneditor);
            aramafonksiyon(sonarama);
        }

        List<liste> Analistetutucu = new List<liste>();
        List<liste> listem = new List<liste>();
        private void aramayap()
        {

        }
        private void Tanımlama_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Hepsi");
            comboBox1.Items.Add(taktif);
            comboBox1.Items.Add(tpasif);


            listem = startF(listem).ToList();

            bindigatama();
            comboBox1.SelectedIndex = 0;



        }
        private List<liste> startF(List<liste> liste)
        {//liste çekilir ve ana listeye eklenir addbindigs ler yapılır
            listem.Clear();
            var list = from a in db.Editör
                       where a.yetki != 1
                       select new liste
                       {
                           id = a.id,
                           ad = a.ad,
                           tel = a.tel != null ? a.tel : "",
                           mail = a.mail != null ? a.mail : "",
                           iş = talaneditor,
                           aktif = a.aktif == null ||a.aktif==0  ? tpasif : taktif
                       };
            var list2 = from a in db.Hakem
                        select new liste
                        {
                            id = a.id,
                            ad = a.ad,
                            tel = "GİZLİ",

                            mail = a.mail != null ? a.mail : "",
                            iş = thakem,
                            aktif = a.aktif == null || a.aktif == 0 ? tpasif : taktif
                        };
            var list3 = from a in db.Yazar
                        select new liste
                        {
                            id = a.id,
                            ad = a.ad,
                            tel = a.tel != null ? a.tel : "",
                            mail = a.mail != null ? a.mail : "",
                            iş = tyazar,
                            aktif = a.aktif == null || a.aktif == 0 ? tpasif : taktif
                        };


            liste.AddRange(list);
            liste.AddRange(list2);
            liste.AddRange(list3);


            dataGridView1.DataSource = liste;
            Analistetutucu = liste;
            bindigatama();
         //   aramafonksiyon(tSonArama);
            return liste;
        }
        private void bindigatama()
        {
            Tad.DataBindings.Clear();
            Tid.DataBindings.Clear();
            Ttel.DataBindings.Clear();
            Tmail.DataBindings.Clear();
            Tad.DataBindings.Add("Text", dataGridView1.DataSource, "ad");
            Tid.DataBindings.Add("Text", dataGridView1.DataSource, "id");
            Ttel.DataBindings.Add("Text", dataGridView1.DataSource, "tel");
            Tmail.DataBindings.Add("Text", dataGridView1.DataSource, "mail");
        }
        public class liste
        {
            public string iş { get; set; }
            public int id { get; set; }
            public string ad { get; set; }
            public string tel { get; set; }
            public string mail { get; set; }
         
            public string aktif { get; set; }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Tid.Text != null && Tid.Text != "")
            {
                int id = Convert.ToInt32(Tid.Text);

                if (Cyetki.SelectedIndex == 0)
                {
                    Yazar item = db.Yazar.Find(id);
                    item.ad = Tad.Text;
                    item.soyad = Soyadtxt.Text;
                    item.mail = Tmail.Text;
                    item.tel = Ttel.Text;

                    item.sonislem = 1;
                    //99999
                    //     yazar.tur = "";
                 

                    db.SaveChanges();
                }
                else if (Cyetki.SelectedIndex == 1)
                {
                    Database.Editör item = db.Editör.Find(id);
                    item.ad = Tad.Text;
                    item.soyad = Soyadtxt.Text;
                    item.mail = Tmail.Text;
                    //99999
                    item.sonislem = DateTime.Now;
                    //99999
                    item.tel = "";
                    //9999
                    item.yetki = 2;

                    //9999 9999 
          
                    //   item.yasaklama = ((Cyasak.SelectedIndex + 1) % 1).ToString();

                    db.SaveChanges();

                }

                else if (Cyetki.SelectedIndex == 2)
                {
                    Database.Hakem item = db.Hakem.Find(id);
                    item.ad = Tad.Text;
                    item.soyad = Soyadtxt.Text;
                    item.alan = "random";


               
                    //    item.yasaklama =((Cyasak.SelectedIndex + 1) % 1).ToString();
                    //
                    db.SaveChanges();
                }
                else if (Cyetki.SelectedIndex == 3)
                {

                }
              

            }

            Analistetutucu = startF(listem);
            aramafonksiyon(null);
            string sonarama = tSonArama;
            aramafonksiyon(talaneditor);
            aramafonksiyon(sonarama);
        }
        public class degistirmeclassi
        {
            public int makaleid { get; set; }
            public int makaleislemid { get; set; }

        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (Tid.Text != null && Tid.Text != "")
            {
                int id = Convert.ToInt32(Tid.Text);
                string isim = dataGridView1.CurrentRow.Cells["iş"].Value.ToString();
                if (isim == tyazar)
                {
                    Yazar item = db.Yazar.Find(id);
                    item.aktif = 0;
                    db.SaveChanges();
                    var asa = from a in db.Makale
                              join b in db.Makaleİslem on a.id equals b.makaleid
                              where b.yazarid == item.id && a.onay != 7 && a.onay != 8 && a.onay != 9
                              select new degistirmeclassi
                              {
                                  makaleid = a.id,
                                  makaleislemid = b.id
                              };
                    List<degistirmeclassi> aa = asa.ToList();
                    asa = null;
                    for (int i = 0; i < aa.ToList().Count ; i++)
                    {
                        Makale m = db.Makale.Find(aa[i].makaleid);
                        m.onay = 7;
                        db.SaveChanges();
                        Makaleİslem mi = db.Makaleİslem.Find(aa[i].makaleislemid);
                        mi.yazarid = null;
                        mi.yazarislem = null;
                        db.SaveChanges();
                    }
                   
                       
                    

                }
                else if (isim == talaneditor)
                {
                    Database.Editör item = db.Editör.Find(id);
                    item.aktif = 0;
                    db.SaveChanges();
                    List<degistirmeclassi> aa = (from a in db.Makale
                               join b in db.Makaleİslem on a.id equals b.makaleid
                               where b.alaneditörid == item.id && a.onay != 7 && a.onay != 8 && a.onay != 9
                               select new degistirmeclassi
                               {
                                   makaleid = a.id,
                                   makaleislemid = b.id
                               }).ToList();


                    for (int i = 0; i < aa.Count; i++)
                    {
                        Makale m = db.Makale.Find(aa[i].makaleid);
                        m.onay = 1;
                        db.SaveChanges();
                        Makaleİslem mi = db.Makaleİslem.Find(aa[i].makaleislemid);
                        mi.alaneditörid = null;
                        mi.alaneditörislem = null;
                        mi.alaneditorrapor = null;
                        mi.alaneditorcevap = null;
                        db.SaveChanges();

                    }
                }

                else if (isim == thakem)
                {
                    Database.Hakem item = db.Hakem.Find(id);
                    item.aktif = 0;
                    db.SaveChanges();
                    List<degistirmeclassi> aa = (from a in db.Makale
                              join b in db.Makaleİslem on a.id equals b.makaleid
                              where (b.hakemid1 == item.id || b.hakemid2 == item.id || b.hakemid3 == item.id) && a.onay != 7 && a.onay != 8 && a.onay != 9
                              select new degistirmeclassi
                              {
                                  makaleid = a.id,
                                  makaleislemid = b.id
                           
                              }).ToList();

                    for (int i = 0; i < aa.Count; i++)
                    {



                        Makaleİslem mi = db.Makaleİslem.Find(aa[i].makaleislemid);
                     if (item.id == mi.hakemid1) {
                            mi.hakemid1 = null;
                            mi.hakem1cevap = null;
                            mi.hakem1pdf = null;
                            mi.hakem1puan = null;
                            mi.hakemid1islem = null;
                            mi.hakem1rapor = null;

                        }
                     else if (item.id == mi.hakemid2) {
                            mi.hakemid2 = null;
                            mi.hakem2cevap = null;
                            mi.hakem2pdf = null;
                            mi.hakem2puan = null;
                            mi.hakemid2islem = null;
                            mi.hakem2rapor = null;
                     

                        }
                     else if (item.id == mi.hakemid3) { }
                        mi.hakemid3 = null;
                        mi.hakem3cevap = null;
                        mi.hakem3pdf = null;
                        mi.hakem3puan = null;
                        mi.hakemid3islem = null;
                        mi.hakem3rapor = null;

                    }
                    db.SaveChanges();
                }
               
         

            }
            Analistetutucu = startF(listem);
            aramafonksiyon(null);
            string sonarama=tSonArama; 
            aramafonksiyon(talaneditor);
            aramafonksiyon(sonarama);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            aramafonksiyon(null);
        }
        private void aramafonksiyon(string gelen)
        {
            listem = Analistetutucu;
            if (gelen != null)
            {
                listem = listem.Where(x => x.iş == gelen).ToList();
            }
            if (comboBox1.SelectedItem != null && comboBox1.SelectedIndex!=0)
            {
                string chooseCB = comboBox1.SelectedItem.ToString() == tpasif ? tpasif : taktif;
                listem = listem.Where(x => x.aktif == chooseCB).ToList();
            }
            tSonArama = gelen;

            dataGridView1.DataSource = listem;
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            aramafonksiyon(talaneditor);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            aramafonksiyon(tyazar);

        }

        private void button7_Click(object sender, EventArgs e)
        {
            aramafonksiyon(thakem);
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            // comboBox1 is readonly
            e.SuppressKeyPress = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            aramafonksiyon(tSonArama);
        }
        private void combogetir()
        {
            if (dataGridView1.SelectedRows != null)
            {
                string aktif = dataGridView1.CurrentRow.Cells["aktif"].Value.ToString();
                string isim = dataGridView1.CurrentRow.Cells["iş"].Value.ToString();
          
                Cyetki.SelectedIndex = isim == tyazar ? 0 : isim == talaneditor ? 1 : 2;
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            combogetir();
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
     //       combogetir();
     
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            combogetir();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
      //      combogetir();
        }
    }
}
