using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Website.Models
{
    public class ChiTietNhap
    {
        [Key]
        public int STT { get; set; }
        public string MaPhieuNhap { get; set; }
        [ForeignKey("MaPhieuNhap")]
        public PhieuNhap PhieuNhap { get; set; }
        public string MaVatTu { get; set; }
        [ForeignKey("MaVatTu")]
        public VatTu VatTu { get; set; }
        public int SoLuong { get; set; }
        public DateTime NgayNhap { get; set; }
        public string MaNCC { get; set; }
        [ForeignKey("MaNCC")]
        public NCC NCC { get; set; }
    }
}