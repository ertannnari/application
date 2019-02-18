using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MVCUygulama.Models
{
    public class Ogrenci
    {
        [Key]
        public int OgrNo { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }

        public ICollection<Ders> ders { get; set; }
    }
}