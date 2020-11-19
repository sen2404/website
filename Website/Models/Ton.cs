using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Website.Models
{
    public class Ton
    {
        [Key]
        public int STT { get; set; }
        public string MaVatTu { get; set; }
        [ForeignKey("MaVatTu")]
        public VatTu VatTu { get; set; }
        public int SLTon { get; set; }
    }
}