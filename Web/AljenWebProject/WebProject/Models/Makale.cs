//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebProject.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Makale
    {
        public int id { get; set; }
        public string baslik { get; set; }
        public string metin { get; set; }
        public string kategori { get; set; }
        public Nullable<System.DateTime> zaman { get; set; }
        public string yazar { get; set; }
        public string revizyon { get; set; }
        public Nullable<System.DateTime> revizyonzaman { get; set; }
        public string yol { get; set; }
        public Nullable<int> onay { get; set; }
        public string ad { get; set; }
        public string soyad { get; set; }
        public string mail { get; set; }
        public string kurum { get; set; }
    }
}