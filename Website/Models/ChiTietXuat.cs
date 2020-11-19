using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Website.Models
{
    public class ChiTietXuat
    {
        [Key]
        public int STT { get; set; }
        public string MaPhieuXuat { get; set; }
        [ForeignKey("MaPhieuXuat")]
        public PhieuXuat PhieuXuat { get; set; }
        public string MaVatTu { get; set; }
        [ForeignKey("MaVatTu")]
        public VatTu VatTu { get; set; }
        public int SoLuong { get; set; }
        public DateTime NgayXuat{ get; set; }
        public string MaKhachHang { get; set; }
        [ForeignKey("MaKhachHang")]
        public KhachHang KhachHang { get; set; }
    }
}