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
    
    public partial class Revizyon
    {
        public int id { get; set; }
        public Nullable<int> makaleid { get; set; }
        public string yazarid { get; set; }
        public string rprhkm1 { get; set; }
        public string rprhkm2 { get; set; }
        public string rprhkm3 { get; set; }
        public string pdfhkm1 { get; set; }
        public string pdfhkm2 { get; set; }
        public string pdfhkm3 { get; set; }
        public Nullable<int> puanhkm1 { get; set; }
        public Nullable<int> puanhkm2 { get; set; }
        public Nullable<int> puanhkm3 { get; set; }
        public Nullable<int> hakemid1 { get; set; }
        public Nullable<int> hakemid2 { get; set; }
        public Nullable<int> hakemid3 { get; set; }
        public Nullable<int> alaneditorid { get; set; }
        public Nullable<int> baseditorid { get; set; }
        public string yazarpdf { get; set; }
        public Nullable<System.DateTime> revizyontalep { get; set; }
        public Nullable<System.DateTime> revizyongonderim { get; set; }
        public Nullable<System.DateTime> zaman { get; set; }
        public Nullable<bool> aktif { get; set; }
    }
}
