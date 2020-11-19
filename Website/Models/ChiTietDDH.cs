using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Website.Models
{
    public class ChiTietDDH
    {
        [Key]
        public int IDChiTiet { get; set; }
        public int IDDDH { get; set; }
        [ForeignKey("IDDDH")]
        public DDH DDH { get; set; }
        public string MaVatTu { get; set; }
        [ForeignKey("MaVatTu")]
        public VatTu VatTu { get; set; }
        public int SoLuong { get; set; }
        public int DonGia { get; set; }
    }
}