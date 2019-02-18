using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MVCUygulama.Models
{
    public class Ders
    {
        [Key]
        public int dersId { get; set; }
        public string dersAdi { get; set; }

        public ICollection<Ogrenci> ogrencis { get; set; }
    }
}