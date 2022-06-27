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
    public partial class Editör : Form
    {
        MakaleEntities db = new MakaleEntities();
        List<Hakem> hakems1 = new List<Hakem>();
        List<Hakem> hakems2 = new List<Hakem>();
        List<Hakem> hakems3 = new List<Hakem>();
        public int makaleid=-1;
        public Editör()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
         
            MakaleSecim sec = new MakaleSecim();
            
          sec.ShowDialog();
            if (makaleid > 0)
            {
                doldur();
            }
        }

        private void doldur()
        {
           
            var liste = (from a in db.Makaleİslem
                         join b in db.Yazar on a.yazarid equals b.id
                         join c in db.Makale on a.makaleid equals c.id
                         

                         where makaleid==a.makaleid
                         select new
                         {
                          ID=a.id,Yazar= b.ad,Konu=c.baslik,c.onay,zaman=c.zaman
                         }
                         ).FirstOrDefault();
            Lyazarad.Text = liste.Yazar;
            Lkonu.Text = liste.Konu;
            Lzaman.Text = liste.zaman.ToString();

            panel1.Enabled = false;
            if (liste.onay == 0) {
                var list = db.Editör.Where(x => x.yetki == 2).ToList();
                Calaneditor.DataSource = list;
                Calaneditor.ValueMember = "id";
                Calaneditor.DisplayMember = "ad";
                Calaneditor.Enabled = button1.Enabled = true;panel1.Enabled = true;
                label2.Text = "Alan Editörü Ataması Bekleniyor...";
         

            }
            else if (liste.onay!=9)
            {
                //Bu fonksiyon var ya bu fonksiyon
                // arama içinde arama linq
                Calaneditor.Text = db.Editör.Where(x=>x.id==db.Makaleİslem.Where(y=>y.id==liste.ID).FirstOrDefault().alaneditörid).FirstOrDefault().ad;
                Calaneditor.Enabled = button1.Enabled = false;
                if (liste.onay==1) { label2.Text = "Hakem Ataması Bekleniyor"; }
                else if (liste.onay == 2) { label2.Text = "Onaylandı"; }
                else if (liste.onay == 3) { label2.Text = "Red edildi"; }
                else if (liste.onay == 4) { label2.Text = "Revizyon bekleniyor"; }
            
               
            }
            else if (liste.onay==9) { Calaneditor.Enabled = button1.Enabled = false; panel1.Enabled = false; label2.Text = "Baş Editör \nTarafından \nRed Edildi "; }
            //kontrolAlaneditör();
            //kontrolHakemKontrol();
            }


        //private void kontrolHakemKontrol()
        //{
       
        //    Makaleİslem kontrol = db.Makaleİslem.Where(x => x.makaleid == makaleid).FirstOrDefault();
        //    if (kontrol.hakemid1 == null)
        //    {
        //        var list = db.Hakem.ToList();
        //        Chakem1.DataSource = list;
        //        Chakem1.ValueMember = "id";
        //        Chakem1.DisplayMember = "ad";
        //    }
        //    if (kontrol.hakemid2 == null)
        //    {
        //        var list = db.Hakem.ToList();
        //        Chakem2.DataSource = list;
        //        Chakem2.ValueMember = "id";
        //        Chakem2.DisplayMember = "ad";
        //    }
        //    if (kontrol.hakemid3 == null)
        //    {
        //        var list = db.Hakem.ToList();
        //        Chakem3.DataSource = list;
        //        Chakem3.ValueMember = "id";
        //        Chakem3.DisplayMember = "ad";
        //    }
        //}

        private void kontrolAlaneditör()
        {
            
            Makaleİslem kontrol = db.Makaleİslem.Where(x=>x.makaleid==makaleid).FirstOrDefault();
            if (kontrol.alaneditörid == null)
            {
                var list = db.Editör.Where(x => x.yetki == 2).ToList();
                Calaneditor.DataSource = list;
                Calaneditor.ValueMember = "id";
                Calaneditor.DisplayMember = "ad";
            }
            else
            {
                Calaneditor.Items.Add(db.Editör.Where(x=>x.id== kontrol.alaneditörid));
                Calaneditor.SelectedValue = kontrol.id;
            }
        }

        private void Editör_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {if (makaleid > 0) { 
            Makaleİslem item = db.Makaleİslem.Where(x=>x.makaleid==makaleid).FirstOrDefault();
            item.alaneditörid = (int)Calaneditor.SelectedValue;
            item.alaneditörislem = DateTime.Now;
            item.baseditörislem = DateTime.Now;
            Makale mkl = db.Makale.Find(item.makaleid);
            mkl.onay = 1;
            
            db.SaveChanges(); doldur();
            }
        }

        //private void button3_Click(object sender, EventArgs e)
        //{
        //    //Makaleİslem item = db.Makaleİslem.Where(x => x.makaleid == makaleid).FirstOrDefault();
        //    //item.hakemid1 = (int)Chakem1.SelectedValue;
        //    //item.hakemid1islem = 1;
        //    //item.hakemid2 = (int)Chakem2.SelectedValue;
        //    //item.hakemid2islem = 1;
        //    //item.hakemid3 = (int)Chakem3.SelectedValue;
        //    //item.hakemid3islem = 1;
        //    ////0 red 1 bekleme 2 onay
        //    //item.hakem1cevap = item.hakem2cevap = item.hakem3cevap = 1;
        //    //db.SaveChanges();
        //}

        private void button2_Click(object sender, EventArgs e)
        {
            if (makaleid > 0) { 
            Makale makale = new Makale();
            makale = db.Makale.Find(makaleid);
            makale.onay = 9;
            Makaleİslem makaleİslem = new Makaleİslem();
            makaleİslem = db.Makaleİslem.Where(x=>x.makaleid==makaleid).FirstOrDefault();
       
            makaleİslem.alaneditörid =makaleİslem.hakemid1 = makaleİslem.hakemid1 = makaleİslem.hakemid1 = null;
            db.SaveChanges();
            if (makaleid > 0)
            {
                doldur();
            }
            }
        }
    }
}
