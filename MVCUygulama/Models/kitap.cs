using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MVCUygulama.Models
{
    public class kitap
    {
        [Key]
        public int makaleId { get; set; }
        public string makaleAdi { get; set; }
        public int YazarID { get; set; }
        public MYazar MYazar { get; set; }
    }
}