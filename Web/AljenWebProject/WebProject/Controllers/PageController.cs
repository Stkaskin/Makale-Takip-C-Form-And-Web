using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProject.Models;
using WebProject.Manager;
using static WebProject.Manager.ApiSystemManager;

namespace WebProject.Controllers
{
    public class PageController : Controller
    {
        MakaleEntities db = new MakaleEntities();
        // GET: Page
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Makale()
        {

            return View();
        }
        public ActionResult Sayfa(int? id)
        {
            if (id != null)
            {


                Models.Makale makales = db.Makale.Find(id);
                if (makales != null)
                {
                    return View(makales);
                }
                else
                {
                    return RedirectToAction("makale", "Page");
                }
            }
            else
            {
                return RedirectToAction("makale", "Page");
            }

        }
        public ActionResult newmakale(Models.Makale makale)
        {
            if (kontrolgiris(1) == -1) { return RedirectToAction("login", "page"); }

            return View();
        }
        [HttpPost, ActionName("newmakale")]
        public ActionResult newmakalesend(Models.Makale makale)
        {
            if (kontrolgiris(1) == -1) { return RedirectToAction("login", "page"); }
            if (Request.Files.Count > 0)
            {

                string[] bilgi = new string[2];
                bilgi = (string[])Session["User"];
                int id = Convert.ToInt32(bilgi[0]);

                if (makale != null)
                {
                    makale.yazar = id.ToString();
                    makale.zaman = DateTime.Now;
                    makale.revizyon = "0";
                    makale.onay = 0;
                    makale.ad = "";
                    db.Makale.Add(makale);
                    db.SaveChanges();
                    Makaleİslem mi = new Makaleİslem();
                    mi.baseditörid = db.Editör.Where(x => x.yetki == 1).FirstOrDefault().id;
                    mi.makaleid = makale.id;
                    mi.yazarislem = DateTime.Now;
                    mi.yazarid = id;

                    db.Makaleİslem.Add(mi);
                    db.SaveChanges();


                    string exname; string filename; string srcname;

                    exname = Path.GetExtension(Request.Files[0].FileName);
                    filename = makale.yazar + "-" + makale.id + "-" + DateTime.Now.Year + "." + DateTime.Now.Month + "." + DateTime.Now.Day;
                    srcname = "~/Images/" + filename + exname;
                    Request.Files[0].SaveAs(Server.MapPath(srcname));
                    makale.yol = "/Images/" + filename + exname;
                    db.SaveChanges();

                    sms sms = new sms();
                    sms.gonderen = "";
                    sms.giden = "";
                    sms.id = -1;

                    ApiSystemManager mngr = new ApiSystemManager();
                    mngr.yazarmail(sms);
                }
            }

            return RedirectToAction("makaleler", "page");
        }

        public ActionResult Makaleİncele(int? id)
        {
            if (kontrolgiris(9) == -1) { return RedirectToAction("login", "page"); }
            if (id != null)
            {

                var list = db.Makale.Find(id);
                return View(list);
            }
            else return RedirectToAction("Makaleler", "Page");


        }

        private string hkmpdf(HttpRequestBase file, HttpServerUtilityBase server, int id, int makaleid, int hakemid)
        {

            string exname; string filename; string srcname;

            exname = Path.GetExtension(file.Files[0].FileName);
            filename = "hkm" + hakemid + "mkl" + makaleid + "mid" + id + "dt" + DateTime.Now.Year + "." + DateTime.Now.Month + "." + DateTime.Now.Day;
            srcname = "~/Images/" + filename + exname;
            file.Files[0].SaveAs(server.MapPath(srcname));
            //  mi.hakem1pdf = "/Images/" + filename + exname;
            return filename = "/Images/" + filename + exname;

        }
        public class gunsay
        {
            public int? id { get; set; }
            public int gun { get; set; }
        }
        public ActionResult davetler()
        {
            if (kontrolgiris(3) == -1) { return RedirectToAction("login", "page"); }
            string[] bilgi = new string[2];
            List<Makale> m = new List<Makale>();
            List<gunsay> gunsay = new List<gunsay>();



            bilgi = (string[])Session["user"];
            if (bilgi[1] == "3")
            {

                int id = Convert.ToInt32(bilgi[0]);
                List<Makaleİslem> list = db.Makaleİslem.Where(x => x.hakemid1 == id || x.hakemid2 == id || x.hakemid3 == id).ToList();
                list = list.Where(x => x.hakem1cevap == 0 || x.hakem2cevap == 0 || x.hakem3cevap == 0).ToList();

                List<Makaleİslem> listtut = list.ToList();
                for (int i = 0; i < listtut.Count; i++)
                {
            
                    Makale makalem= db.Makale.Find(listtut[i].makaleid);
                  int a = 1;
                    if (makalem.onay == 7 || makalem.onay == 8 || makalem.onay == 9)
                    {
                        list.Remove(listtut[i]);
                      
                    }

                }

                foreach (var item in list)
                {
                    if ((item.hakemid1 == id && item.hakem1cevap == 0) || (item.hakemid2 == id && item.hakem2cevap == 0) || (item.hakemid3 == id && item.hakem3cevap == 0))
                    {
                        gunsay g = new gunsay();
                        g.id = item.makaleid;
                        m.AddRange(db.Makale.Where(x => x.id == item.makaleid).ToList());
                        if (item.hakemid1 == id)
                        {

                            g.gun = (item.hakemid1islem.Value.AddDays(10) - DateTime.Now).Days;

                        }
                        else if (item.hakemid2 == id)
                        {

                            g.gun = (item.hakemid2islem.Value.AddDays(10) - DateTime.Now).Days;


                        }
                        else
                        {

                            g.gun = (item.hakemid3islem.Value.AddDays(10) - DateTime.Now).Days;


                        }
                        gunsay.Add(g);
                    }


                }
            }
            ViewBag.gunsay = gunsay;
            return View(m);
        }
        public ActionResult davetsecim(int id, int cevap)
        {
            if (kontrolgiris(3) == -1) { return RedirectToAction("login", "page"); }
            string[] bilgi = new string[2];
            bilgi = (string[])Session["user"];
            int ids = Convert.ToInt32(bilgi[0]);
            Makaleİslem mi = new Makaleİslem();
            Makale makale;
            mi = db.Makaleİslem.Where(x => x.makaleid == id).FirstOrDefault();
            if (cevap == 1)
            {
                if (mi.hakemid1 == ids)
                {
                    mi.hakem1cevap = 1;
                    mi.hakemid1islem = DateTime.Now;


                }
                else if (mi.hakemid2 == ids) { mi.hakem2cevap = 1; mi.hakemid2islem = DateTime.Now; }
                else if (mi.hakemid3 == ids) { mi.hakem3cevap = 1; mi.hakemid3islem = DateTime.Now; }

            }
            else if (cevap == 2)
            {
                if (mi.hakemid1 == ids) { mi.hakem1cevap = -1; mi.hakemid1 = null; mi.hakemid1islem = null; }
                else if (mi.hakemid2 == ids) { mi.hakem2cevap = -1; mi.hakemid2 = null; mi.hakemid1islem = null; }
                else if (mi.hakemid3 == ids)
                {
                    mi.hakem3cevap = -1; mi.hakemid3 = null; mi.hakemid1islem = null;

                }
                makale = db.Makale.Find(mi.makaleid);
                makale.onay = 1;

            }
            db.SaveChanges();
            return RedirectToAction("davetler", "page");
        }
        public ActionResult tercih(int? tercihkodu, int id, string metin, int puan)
        {
            if (kontrolgiris(3) == -1) { return RedirectToAction("login", "page"); }
            string[] bilgi = new string[2]; bilgi = (string[])Session["user"];
            Makaleİslem mi = db.Makaleİslem.Where(x => x.makaleid == id).FirstOrDefault();
            int gelenid = Convert.ToInt32(bilgi[0]);
            if (mi.hakemid1 == gelenid)
            {
                mi.hakem1cevap = 2;
                mi.hakem1rapor = metin;
                mi.hakemid1islem = DateTime.Now;
                mi.hakem1puan = puan;
                mi.hakem1pdf = hkmpdf(Request, Server, mi.id, (int)mi.makaleid, (int)mi.hakemid1);

            }
            else if (mi.hakemid2 == gelenid)
            {
                mi.hakem2cevap = 2;
                mi.hakem2rapor = metin;
                mi.hakemid2islem = DateTime.Now;
                mi.hakem2puan = puan;
                mi.hakem2pdf = hkmpdf(Request, Server, mi.id, (int)mi.makaleid, (int)mi.hakemid2);
            }
            else if (mi.hakemid3 == gelenid)
            {
                mi.hakem3cevap = 2;
                mi.hakem3rapor = metin;
                mi.hakemid3islem = DateTime.Now;
                mi.hakem3puan = puan;
                mi.hakem3pdf = hkmpdf(Request, Server, mi.id, (int)mi.makaleid, (int)mi.hakemid3);

            }
            db.SaveChanges();
            //Control 
            if (mi.hakem1cevap == 2 && mi.hakem2cevap == 2 && mi.hakem3cevap == 2)
            {
                if (mi.hakem1cevap != 0 && mi.hakem2cevap != 0 && mi.hakem3cevap != 0)
                {
                    Makale mkl = db.Makale.Find(mi.makaleid);
                    if ((mi.hakem1puan + mi.hakem2puan + mi.hakem3puan) / 3 >= 75)
                    {
                        mkl.onay = 3;
                    }
                    else
                    {
                        mkl.onay = 4;
                    }
                    db.SaveChanges();
                }
            }

            return RedirectToAction("makaleler", "page");
        }

        public ActionResult mesajsayfasi()
        {
            if (kontrolgiris(2) == -1) { return RedirectToAction("login", "page"); }
            return View();
        }
        private int kontrolgiris(int girisyapanyetki)
        {

            string[] bilgi = new string[2];

            bilgi = (string[])Session["user"];
            if (bilgi == null)
            {
                return -1;
            }
            else if (bilgi[1] == girisyapanyetki.ToString() || bilgi[0] == 9.ToString())
                return 1;
            else return 1;


        }

        public ActionResult Makaleler(int? onaytipi)
        {

            if (kontrolgiris(9) == -1) { return RedirectToAction("login", "page"); }
            List<Models.Makale> m = new List<Makale>();
            string[] bilgi = new string[2];

            bilgi = (string[])Session["user"];
            int id = Convert.ToInt32(bilgi[0]);
            if (bilgi[1] == "1")
            {

                m = db.Makale.Where(x => x.yazar == id + "").ToList();


            }
            else if (bilgi[1] == "2")
            {
                var list = db.Makaleİslem.Where(x => x.alaneditörid == id).ToList();
                foreach (var item in list)
                {
                    m.AddRange(db.Makale.Where(x => x.id == item.makaleid).ToList());

                }
            }
            else if (bilgi[1] == "3")
            {




            
                List<Makaleİslem> list = db.Makaleİslem.Where(x => x.hakemid1 == id || x.hakemid2 == id || x.hakemid3 == id).ToList();
                list = list.Where(x => x.hakem1cevap == 0 || x.hakem2cevap == 0 || x.hakem3cevap == 0).ToList();

                List<Makaleİslem> listtut = list.ToList();
                for (int i = 0; i < listtut.Count; i++)
                {

                    Makale makalem = db.Makale.Find(listtut[i].makaleid);
                    int a = 1;
                    if (makalem.onay == 7 || makalem.onay == 8 || makalem.onay == 9)
                    {
                        list.Remove(listtut[i]);

                    }

                
            }



                foreach (var item in list)
                {
                    int hakemkod = (item.hakemid1 == id ? 1 : item.hakemid2 == id ? 2 : 3);

                    if ((item.hakemid2 == id && item.hakem2cevap != 0) || (item.hakemid1 == id && item.hakem1cevap != 0) || (item.hakemid3 == id && item.hakem3cevap != 0))
                    {
                        Makale mkl = db.Makale.Where(x => x.id == item.makaleid).FirstOrDefault();
                        if (hakemkod == 1) { mkl.onay = (item.hakem1cevap == 1 ? 2 : mkl.onay); }
                        else if (hakemkod == 2)
                        {
                            mkl.onay = (item.hakem2cevap == 1 ? 2 : mkl.onay);
                        }
                        else { mkl.onay = (item.hakem3cevap == 1 ? 2 : mkl.onay); }
                        m.Add(mkl);

                    }


                }
                foreach (var li in list)
                {

                    if (li.hakemid1 == id && li.hakem1cevap == 2)
                    {
                        m.Where(x => x.id == li.makaleid).FirstOrDefault().onay = 6;

                    }
                    else if (li.hakemid2 == id && li.hakem2cevap == 2)
                    {
                        m.Where(x => x.id == li.makaleid).FirstOrDefault().onay = 6;
                    }
                    else if (li.hakemid3 == id && li.hakem3cevap == 2)
                    {
                        m.Where(x => x.id == li.makaleid).FirstOrDefault().onay = 6;
                    }


                }

            }

            if (onaytipi != null)
            {
                m = m.Where(x => x.onay == (int)onaytipi).ToList();
            }




            return View(m);
        }



        public ActionResult Login()
        {
            if (kontrolgiris(9) == 1) { return RedirectToAction("Makaleler", "page"); }
            return View();
        }
        [HttpPost, ActionName("Login")]
        public ActionResult Loginplus(string blok1, string blok2)
        {// 1 yazar 2 editör 3 hakem -----4 baş editör 


            string[] bilgi = new string[2];
            bilgi[0] = "-1";
            Yazar yazar = db.Yazar.Where(x => x.mail == blok1 && x.parola == blok2 && x.aktif == 1).FirstOrDefault();
            if (yazar != null) { bilgi[0] = yazar.id.ToString(); bilgi[1] = "1"; }
            else
            {
                Editör Editör = db.Editör.Where(x => x.mail == blok1 && x.parola == blok2 && x.aktif == 1).FirstOrDefault();
                if (Editör != null) { bilgi[0] = Editör.id.ToString(); bilgi[1] = "2"; }
                else
                {
                    Hakem hkm = db.Hakem.Where(x => x.mail == blok1 && x.parola == blok2 && x.aktif == 1).FirstOrDefault();
                    if (hkm != null) { bilgi[0] = hkm.id.ToString(); bilgi[1] = "3"; }
                }
            }


            if (bilgi[0] != "-1")
            {

                Session.Add("user", bilgi);


                return RedirectToAction("makaleler", "page");
            }
            else { Session.Remove("user"); }

            return View();

        }
        public ActionResult Loguot()
        {
            Session.Remove("user");
            return RedirectToAction("login", "page");
        }
        public ActionResult yenipersonel()
        {
            if (kontrolgiris(2) == -1) { return RedirectToAction("login", "page"); }
            return View();
        }
        [HttpPost, ActionName("yenipersonel")]
        public ActionResult yenipersonel(string ad, string soyad, string tel, string adres, string mail, int sayi)
        {
            if (kontrolgiris(2) == -1) { return RedirectToAction("login", "page"); }
            if (sayi == 1)
            {
                Yazar yazar = new Yazar();
                yazar.ad = ad;
                yazar.mail = mail;
                yazar.soyad = soyad;
                yazar.kayit = DateTime.Now;
                yazar.aktif = 1;
                yazar.tel = tel != null ? tel : "";
                db.Yazar.Add(yazar);
                db.SaveChanges();
                return RedirectToAction("makaleler", "page");

            }
            else if (sayi == 2)
            {

                Hakem hakem = new Hakem();
                hakem.ad = ad;
                hakem.mail = mail;
                hakem.soyad = soyad;
                hakem.tarih = DateTime.Now;
                hakem.aktif = 1;
                db.Hakem.Add(hakem);
                db.SaveChanges();
                return RedirectToAction("makaleler", "page");
            }
            return View();
        }
        public ActionResult atama(int? id)
        {
            if (kontrolgiris(2) == -1) { return RedirectToAction("login", "page"); }
            Makaleİslem mi = new Makaleİslem();
            mi = db.Makaleİslem.Where(x => x.makaleid == (int)id).FirstOrDefault();
            ViewBag.hakem1 = ViewBag.hakem2 = ViewBag.hakem3 = 0;
            if (mi.hakemid1 == null) { ViewBag.hakem1 = 1; }
            if (mi.hakemid2 == null) { ViewBag.hakem2 = 1; }
            if (mi.hakemid3 == null) { ViewBag.hakem3 = 1; }


            var categoryList = new List<SelectListItem>
{
    new SelectListItem { Value="0", Text = "All"}
};
            ViewBag.IDatama = id;
            ViewBag.Yol = db.Makale.Find(id).yol;
            categoryList.AddRange(db.Hakem.Where(x => x.id != mi.hakemid1 && x.id != mi.hakemid2 && x.id != mi.hakemid3)
                                    .Select(a => new SelectListItem
                                    {
                                        Value = a.id.ToString(),
                                        Text = a.ad
                                    }));

            ViewBag.CategoryList = categoryList;



            return View();

        }
        public ActionResult atamayap(

            int? hakem1, int? hakem2, int? hakem3, int? id)
        {
            if (kontrolgiris(2) == -1) { return RedirectToAction("login", "page"); }
            Makaleİslem islem = new Makaleİslem();
            islem = db.Makaleİslem.Where(x => x.makaleid == id).FirstOrDefault();
            ApiSystemManager mngr = new ApiSystemManager();
            sms sms = new sms();

            if (islem.hakemid1 == null)
            {
                islem.hakemid1 = hakem1; islem.hakem1cevap = 0; islem.hakemid1islem = DateTime.Now;

                //sms.giden = "ss";
                //sms.gonderen = "aa";
                //sms.id = (int)islem.hakemid1;


                mngr.hakemmail(sms);

            }
            if (islem.hakemid2 == null)
            {
                islem.hakemid2 = hakem2; islem.hakem2cevap = 0; islem.hakemid2islem = DateTime.Now;

                //sms.giden = "ss";
                //sms.gonderen = "aa";
                //sms.id = (int)islem.hakemid3;
                //mngr.hakemmail(sms);
            }
            if (islem.hakemid3 == null)
            {
                islem.hakemid3 = hakem3; islem.hakem3cevap = 0; islem.hakemid3islem = DateTime.Now;

                //sms.giden = "ss";
                //sms.gonderen = "aa";
                //sms.id = (int)islem.hakemid3;
                //mngr.hakemmail(sms);
            }




            islem.alaneditörislem = DateTime.Now;
            islem.alaneditorcevap = 1;
            Makale mkl = db.Makale.Find(id);
            mkl.onay = 2;


            db.SaveChanges();

            return RedirectToAction("makaleler", "page");


        }
        public ActionResult inceleme(int? id)
        {
            if (kontrolgiris(2) == -1) { return RedirectToAction("login", "page"); }
            if (id != null)
            {
                Makaleİslem m = db.Makaleİslem.Where(x => x.makaleid == (int)id).FirstOrDefault();
                Makale mkl = db.Makale.Find(id);
                ViewBag.yol = mkl.yol;
                ViewBag.cevap = mkl.onay;
                return View(m);
            }
            return RedirectToAction("makaleler", "page");

        }
        public ActionResult incelemetercih(int id, string metin, int tercih)
        {
            if (kontrolgiris(2) == -1) { return RedirectToAction("login", "page"); }
            Makaleİslem m = db.Makaleİslem.Where(x => x.makaleid == (int)id).FirstOrDefault();
            m.alaneditorrapor = metin;


            m.alaneditörislem = DateTime.Now;
            Makale mkl = db.Makale.Find(id);


            if (tercih == 0)
            {
                if (mkl.onay == 4) { m.alaneditorcevap = 5; mkl.onay = 7; mkl.revizyonzaman = DateTime.Now; }
                else if (mkl.onay == 3) { m.alaneditorcevap = 6; mkl.onay = 8; }

            }
            if (tercih == 1)
            {
                m.alaneditorcevap = 4; mkl.onay = 5;
            }
            db.SaveChanges();

            return RedirectToAction("makaleler", "page");
        }
        public ActionResult revizyon(int id)
        {
            if (kontrolgiris(1) == -1) { return RedirectToAction("login", "page"); }
            Makale mkl = db.Makale.Find(id);
            if (mkl.onay == 5) { return View(mkl); }
            return View();
        }
        public ActionResult revizyononay(int id)
        {
            if (kontrolgiris(1) == -1) { return RedirectToAction("login", "page"); }

            string exname; string filename; string srcname;
            Makale makale = db.Makale.Find(id);
            exname = Path.GetExtension(Request.Files[0].FileName);
            filename = makale.yazar + "-revizyon-" + makale.id + "-" + DateTime.Now.Year + "." + DateTime.Now.Month + "." + DateTime.Now.Day;
            srcname = "~/Images/" + filename + exname;
            Request.Files[0].SaveAs(Server.MapPath(srcname));
            makale.yol = "/Images/" + filename + exname;



            makale.onay = 2;


            Makaleİslem mi = db.Makaleİslem.Where(x => x.makaleid == id).FirstOrDefault();
            //   mi.baseditörid = db.Editör.Where(x => x.yetki == "1").FirstOrDefault().id;
            mi.makaleid = makale.id;
            mi.yazarislem = DateTime.Now;
            mi.hakem1cevap = 1;
            mi.hakem2cevap = 1;
            mi.hakem3cevap = 1;
            mi.hakemid1islem = mi.hakemid2islem = mi.hakemid3islem = DateTime.Now;


            mi.hakem3puan = mi.hakem2puan = mi.hakem1puan = 0;
            mi.hakem3pdf = mi.hakem2pdf = mi.hakem1pdf = "";


            db.SaveChanges();

            sms sms = new sms();
            sms.gonderen = "";
            sms.giden = "";
            sms.id = -1;

            ApiSystemManager mngr = new ApiSystemManager();
            mngr.yazarmail(sms);
            return RedirectToAction("makaleler", "page");
        }
        public ActionResult detay()
        {

            return View();
        }
        [HttpPost, ActionName("detay")]
        public ActionResult detayara(string mail, int tip)
        {
            if (tip == 0)
            {
                var list = db.Yazar.Where(x => x.mail == mail).FirstOrDefault();
                if (list != null)
                {
                    var liste = db.Makale.Where(x => x.yazar == list.id.ToString()).ToList();
                    List<Makaleİslem> makales = new List<Makaleİslem>();
                    foreach (var item in liste)
                    {
                        makales.Add(db.Makaleİslem.Where(x => x.makaleid == item.id).FirstOrDefault());
                    }
                    ViewBag.makale = liste;
                    return View(makales);
                }
            }
            else if (tip == 1)
            {
                var liste = db.Makale.Where(x => x.mail == mail).ToList(); if (liste != null)
                {
                    List<Makaleİslem> makales = new List<Makaleİslem>();
                    foreach (var item in liste)
                    {
                        makales.Add(db.Makaleİslem.Where(x => x.makaleid == item.id).FirstOrDefault());
                    }
                    ViewBag.makale = liste;
                    return View(makales);
                }
            }
            return View();
        }

        public ActionResult kadro(int? tercih)
        {
            ListKadro list = new ListKadro();

            if (tercih == 1 || tercih == null)
            {
                list.yazars = db.Yazar.ToList();
            }
            if (tercih == 2 || tercih == null || tercih==4) 
            {
               
                list.editors = db.Editör.ToList();
                if (tercih == 2) {list.editors= list.editors.Where(x => x.yetki == 2).ToList(); }
                else if (tercih == 4) { list.editors = list.editors.Where(x => x.yetki == 1).ToList(); }
            }
            if (tercih == 3 || tercih == null) 
            {
                
                
                list.hakems = db.Hakem.ToList(); 
                
            }



            return View(list);

        }
        public class ListKadro
        {

            public List<Editör> editors { get; set; }
            public List<Yazar> yazars { get; set; }
            public List<Hakem> hakems { get; set; }
        }
    }
}