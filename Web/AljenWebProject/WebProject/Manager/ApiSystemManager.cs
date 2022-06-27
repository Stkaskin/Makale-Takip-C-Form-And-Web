using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace WebProject.Manager
{
 
    public class ApiSystemManager
    {
        public class sms
        {
            public string gonderen{ get; set; }
            public string giden { get; set; }
            public string mesaj{ get; set; }
            public int id { get; set; }
            public string subjec { get; set; }
        }
        
        public void sendEmailViaWebApi(sms sms)
        {/*api systemi calısıyor fakat eposta adresi bilinmediği için kullanılmamakta*/
            //string subject = "Email Subject";
            //string body = "Email body";
            //string FromMail = "shahid@reckonbits.com.pk";
            //string emailTo = "reciever@reckonbits.com.pk";
            //MailMessage mail = new MailMessage();
            //SmtpClient SmtpServer = new SmtpClient("mail.reckonbits.com.pk");
            //mail.From = new MailAddress(FromMail);
            //mail.To.Add(emailTo);
            //mail.Subject = subject;
            //mail.Body = body;
            //SmtpServer.Port = 25;
            //SmtpServer.Credentials = new System.Net.NetworkCredential("shahid@reckonbits.com.pk", "your password");
            //SmtpServer.EnableSsl = false;
            //SmtpServer.Send(mail);
        }

        public  void hakemmail(sms sms) 
        {
            string mesaj = "Sayin dergi hakemimiz \n incelenmek üzere bir makale bulunmaktadır . 10 gün içinde onay verdiğiniz takdirde incelemeye başlayabilirsiniz. \n Makaleyi incelemek için sisteme giriş yapın ve davetlere tıklayınız . İlgili adımlar resim uygulamalı...";
            sms.mesaj = mesaj;
            sendEmailViaWebApi(sms);
        }
        public  void yazarmail(sms sms)
        {
            string mesaj = "Sayın dergi yazarımız makaleniz sistemde incelenmek üzere sıraya alınmıştır . Takip için sisteme girin ve makaleler sekmesinden takip ediniz. \n Bu makale size ait değil ise yanıt mesajı atınız ve belirtiniz. Teşekkürler.";
            sms.mesaj = mesaj; 
            sendEmailViaWebApi(sms);
        }
        public  void yazarmailgeridonus(sms sms)
        {
            string mesaj = "Sayın yazarımız sisteme yüklediğiniz makalenin mail adresi yanlış girilmiştir bilginize. "; sms.mesaj = mesaj;
            sendEmailViaWebApi(sms);
        }
        public  void yazarmakalered(sms sms)
        {
            string mesaj = "Sayın yazarımız sisteme yüklediğiniz makale hakemlerimiz tarafından yayınlanmaya uygun görülmemiştir  "; sms.mesaj = mesaj;
            sendEmailViaWebApi(sms);
        }
        public  void yazarmakalerev(sms sms)
        {
            string mesaj = "Sayın yazarımız sisteme yüklediğiniz makale hakemlerimiz tarafından yayınlanmaya tam olarak uygun görülmemiştir . revizyona uygun görülmüş ve 10 gün içinde revizyonlu halini tekrar sisteme yükleyebilirsiniz.";
            sms.mesaj = mesaj;
            sendEmailViaWebApi(sms);
        }
        public  void yazarmakaleonay(sms sms)
        {
            string mesaj = "Sayın yazarımız sisteme yüklediğiniz makale hakemlerimiz tarafından yayınlanmaya   uygun görülmüştür .Dergide yayınlanmak üzere sıraya alınmıştır.";
            sms.mesaj = mesaj;
            sendEmailViaWebApi(sms);
        }
    }
}