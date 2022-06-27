using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebProject.Models;

namespace WebProject.Manager
{
    public class SystemControlManager
    {

        public static void ControlRevizyonTarihOnay()
        {//makale sisteme 10 gün içinde revizyon yapılıp yüklenmediği taktirde red edildi olarak değiştirilecek
            MakaleEntities db = new MakaleEntities();
            var list = db.Makale.Where(x=>x.onay==5).ToList();
            foreach (var item in list)
            {
                Makale mkl = item;
                if (mkl.revizyonzaman.Value.AddDays(10)<DateTime.Now)
                {
                    mkl.onay = 7;
                    db.SaveChanges();
                }
                
             

            }
        }
        public static void ControlHakemOnay()
        {

            MakaleEntities db = new MakaleEntities();
            var islem = db.Makaleİslem.ToList();
            var cevapcontrol = islem.Where(x => x.hakem1cevap == 0 || x.hakem2cevap == 0 || x.hakem3cevap == 0).ToList();
            foreach (var item in cevapcontrol)
            {

             
                Makaleİslem i = new Makaleİslem();
                i = db.Makaleİslem.Find(item.id); 

                if (i.hakem1cevap != null && i.hakemid1islem != null && i.hakem1cevap ==0 && i.hakemid1islem.Value.AddDays(10) < DateTime.Now)
                {
                    i.hakem1cevap = -1; i.hakemid1 = null; i.hakemid1islem = null;
                }

                if (i.hakem2cevap != null && i.hakemid2islem != null && i.hakem2cevap == 0 && i.hakemid2islem.Value.AddDays(10) < DateTime.Now)
                {
                    i.hakem2cevap = -1; i.hakemid2 = null; i.hakemid2islem = null;
                }


                if (i.hakem3cevap != null && i.hakemid3islem != null && i.hakem3cevap == 0 && i.hakemid3islem.Value.AddDays(10) < DateTime.Now)
                {
                    i.hakem3cevap = -1; i.hakemid3 = null; i.hakemid3islem = null;
                }
                if (i.hakem1cevap == -1 || i.hakem2cevap == -1 || i.hakem3cevap == -1)
                {
                    Makale m = db.Makale.Find(i.makaleid); m.onay = 1;
                }
                db.SaveChanges();
                //if (a.zaman.Value.AddDays(10) < DateTime.Now)
                //{

                //    if (i.hakem1cevap == 0) 
                //    {
                //        i.hakem1cevap = -1; i.hakemid1 = null; i.hakemid1islem = null;
                //    }
                //    if (i.hakem2cevap == 0) { i.hakem2cevap = -1; i.hakemid2 = null; i.hakemid2islem = null; }
                //    if (i.hakem3cevap == 0) { i.hakem3cevap = -1; i.hakemid3 = null; i.hakemid3islem = null; }
                //    if (i.hakem1cevap == -1 || i.hakem2cevap == -1 || i.hakem3cevap == -1)
                //    {
                //        Makale m = db.Makale.Find(i.makaleid); m.onay = 1;
                //    }
                //    db.SaveChanges();

                //}




            }
            cevapcontrol = islem.Where(x => x.hakem1cevap == 1 || x.hakem2cevap == 1 || x.hakem3cevap == 1).ToList();
            foreach (var item in cevapcontrol)
            {
                //var a = makalelistesi.Where(x => x.id == item.makaleid).FirstOrDefault();
                Makaleİslem i = new Makaleİslem();
                i = db.Makaleİslem.Find(item.id);


                if (i.hakem1cevap != null && i.hakemid1islem != null  && i.hakem1cevap == 1 && i.hakemid1islem.Value.AddDays(21) < DateTime.Now)
                {
                    i.hakem1cevap = -1; i.hakemid1 = null; i.hakemid1islem = null;
                }

                if (i.hakem2cevap != null && i.hakemid2islem != null && i.hakem2cevap == 1 && i.hakemid2islem.Value.AddDays(21) < DateTime.Now)
                {
                    i.hakem2cevap = -1; i.hakemid2 = null; i.hakemid2islem = null;
                }


                if (i.hakem3cevap != null && i.hakemid3islem != null && i.hakem3cevap == 1 && i.hakemid3islem.Value.AddDays(21) < DateTime.Now)
                {
                    i.hakem3cevap = -1; i.hakemid3 = null; i.hakemid3islem = null;
                }
                if (i.hakem1cevap == -1 || i.hakem2cevap == -1 || i.hakem3cevap == -1)
                {
                    Makale m = db.Makale.Find(i.makaleid); m.onay = 1;
                }
                db.SaveChanges();

                

            }
        }
    }
}