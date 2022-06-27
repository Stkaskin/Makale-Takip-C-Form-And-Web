# Makale-Takip-C--Form-And-Web
Makale takip sistemi yaz projesi kapsamında proje bazlı olarak yapılmıştır. C# Form OOP ve C# Web Mvc OOP kullanılmıştır.


![image](https://user-images.githubusercontent.com/90522945/175949930-cd15e246-d3fc-4d4b-abd7-f067df7b8235.png)

Layout sayfası hariç tüm sayfalar Page sayfasındadır.
ApiSystemManager ile mail ve mail ile alakalı fonksiyon kodları bulunmaktadır.
SystemControlManager ile sistem açıldığında tüm veritabanı gözden geçirip süresi dolan işlemler ile ilgili ayarlamalar yapılmaktadır.


![image](https://user-images.githubusercontent.com/90522945/175949949-841e36dd-0ab5-4a5d-b069-196fb2dab592.png)

Database First ile MSSQL den çekilen tablolarda ilişki kullanılmamıştır.
Burada aynı foreign key farklı yerlerde de eşleşme ihtimali olabileceği için Linq sorguları ile tespit edilmiştir.
Genel tablomuz Makaleislem tablosudur.
…işlem = zaman.  
….cevap= sayı
…puan=sayı
…rapor=yazı
…pdf =yazı 
…id =sayıdır.
Revizyon tablosu revizyonu istenen ve eğer yazar tarafından gönderilmiş ise revizyon edilmemiş haldeki tüm bilgiler revizyon tablosuna kopyalanır.
Makale sayfasında 
Yazarın id’si ve başkası tarafından gönderilmiş ise diğer yazarın bilgilerini barındırmakta.
Editör tablosundaki yetki alan editörü ve baş editör arasındaki farkı belirler eğer baş editör yok ise sistem tarafından ilk kişi baş editör olur
Makale
Sistemin Belkemiği olan Makaledeki Onay :
Onay: sayı türündedir 
İçerdiği onay olan her sayının bir anlamı var ve tüm işleyiş onun üzerinden kontrol ediliyor.
revizyonzaman:Alan editörünün revizyon istediği zamandır . Bu zamana göre son revizyon gönderim zamanı tespit edilir. 

![image](https://user-images.githubusercontent.com/90522945/175949983-ec93c4a7-fe9a-4686-a965-8c38270d6306.png)

Giriş sayfası
Linq kodları ile giriş yapanı bulduktan sonra 
Session ile giriş yapan kişinin id ve yetkisi tutulur ve silinir

![image](https://user-images.githubusercontent.com/90522945/175950025-599f75e9-aaac-4f67-8a08-4e7f94e4bfcd.png)

 Yazar ve diğer yazarların makalelerini görüntülediği sayfa


![image](https://user-images.githubusercontent.com/90522945/175950063-080da369-c3fa-4f34-ab4b-4eb26721f5e9.png)

Kadro sayfası 
Kayıtlı personel bilgileri

![image](https://user-images.githubusercontent.com/90522945/175950119-d7ba4227-e7b9-4cfa-865d-11187a1c2cef.png)

Yazar Sisteme giriş yaptığında önceki kendisine ait makalelerin durumunu görür
Revizyon var ise revizyon gönderir
Yeni makale yazar.

![image](https://user-images.githubusercontent.com/90522945/175950180-d54a25f3-31ae-44d1-987c-5e2066e07d74.png)

 Yeni makale yazma sayfası bu şekildedir. Pdf seçip sisteme gönderir

![image](https://user-images.githubusercontent.com/90522945/175950248-32be2d47-fc69-46c9-b52b-99e178f92286.png)

Baş editör makaleleri masaüstü uygulamasından inceler.
“Makale seç “ butonu ile makaleler listelenir


![image](https://user-images.githubusercontent.com/90522945/175950286-18037158-502d-4c2f-91f3-7a8a4078fe5d.png)

![image](https://user-images.githubusercontent.com/90522945/175950339-f71c0b1e-824c-4ad6-bea2-62e06cfe1016.png)

Gördüğü makalede Onay sütununda kendisi ile alakalı atamaları “Alan Editör Ataması” Olanları seçer ve onları değerlendirir.Altaki Filtre buttonlarından yararlanabilir.

![image](https://user-images.githubusercontent.com/90522945/175950373-b8a3a65e-b0b8-4387-bcfd-e0eacebd9385.png)


Bu şekilde alan editörü ataması olanlar gelmiş olur. Seç butonu ile makale değerlendirmesine gider.

![image](https://user-images.githubusercontent.com/90522945/175950405-fed11611-c5da-47e6-94de-b4bef7b93045.png)


 Burada makaleyi bir alan editörüne gönderebilir veya dergilere yönlendirip ret edebilir.
 
 ![image](https://user-images.githubusercontent.com/90522945/175950440-1f28bcce-f2fa-4c6f-9b7b-a2f5a3fa2433.png)

Alan editörü web ile sisteme giriş yaptığında 
Yeni personel ekleme 
Hakem Atama
Hakemlerin raporlarını inceleme sayfasına gidebilir.


![image](https://user-images.githubusercontent.com/90522945/175950482-bba1e725-aa26-47d8-999f-4358af4b043a.png)


Atama sayfası
Burada View.bag ile hakemler seçilir.
Aynı hakem seçilmemesi için View.bag ile seçili hakemler çıkarılır.
Aynı sayfada aynı hakemlerin seçilmesi durumuda javascript ile engellenmiştir.
Pdf sayfasına erişim buttonu eklenmiştir.


![image](https://user-images.githubusercontent.com/90522945/175950517-a530f28f-ce94-4f62-9c0c-3a8586d755ba.png)


Alan editör inceleme sayfası
Burada pdf raporlarını ve ekstra yazı raporlarını alan editörü inceler .
Hakemlerin cevabını gönderir veya revizyon talep eder.
Ayrı bir rapor da kendisi yazabilir.

![image](https://user-images.githubusercontent.com/90522945/175950537-6f43314a-c42c-4aea-a1c7-5ed842561d66.png)

Hakem sisteme giriş yapıp davetler sayfasına gittiğinde onunla alakalı davetleri görüntüler ve süresi dolmadan onaylayıp ret edebilir . Süresi dolduğunda otomatik olarak makaleyi ret etmiş sayılır.


![image](https://user-images.githubusercontent.com/90522945/175950561-cc120d6f-d29c-4868-8643-a826a08265fd.png)

Hakem makaleler sayfasında makaleleri inceler ve oy verir
21 gün içinde onaylamaz ise makale ile ilgili ilişkisi biter.

![image](https://user-images.githubusercontent.com/90522945/175950584-335ceace-2a5d-4ad4-b3a4-6d366c1a9a0f.png)

Hakem incelediği makaleye puan verir ve raporunu sisteme pdf olarak yükler 
Ekstra yazı da ekleyebilir.
Hakemlerin toplam oyu 75 ve üzeri olursa cevap olarak onaylandı döner.
75 ve altı olur ise cevap olarak ret döner.

![image](https://user-images.githubusercontent.com/90522945/175950606-ab7b2c22-be8d-4e60-aeca-be7e49e1b587.png)

Diğer yazarlar ve yazarlar sisteme giriş yapmadan makaleyi inceleyebilir.

![image](https://user-images.githubusercontent.com/90522945/175950633-58a05cb1-07b0-4da6-9290-4100d1e9cebb.png)


Personel işlemler tablosu
**Masaüstü ve web ile başlangıçta otomatik olarak oluşur .bas editör veritabanından el ile eklenmelidir. Yetkisi 1 olarak seçilmelidir 



