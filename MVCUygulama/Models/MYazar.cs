using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MVCUygulama.Models
{
    public class MYazar
    {
        [Key]
        public int YazarID { get; set; }
        public string YazarAD { get; set; }
        public int MakaleSayisi { get; set; }
        public bool? isDeleted { get; set; }
        public ICollection<kitap> kitaps { get; set; }
    }
}