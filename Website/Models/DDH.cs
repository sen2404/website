using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Website.Models
{
    public class DDH
    {
        [Key]
        public int IDDDH { get; set; }
        public string MaKhachHang { get; set; }
        [ForeignKey("MaKhachHang")]
        public KhachHang KhachHang { get; set; }
        public string TinhTrangDH { get; set; }
        public string MaNVGH { get; set; }
        [ForeignKey("MaNVGH")]
        public NVGiaoHang NVGiaoHang { get; set; }
        public DateTime NgayDH { get; set; }
        public int TongGia { get; set; }
        public string NoiNhan { get; set; }
        public string GhiChu { get; set; }
        public ICollection<ChiTietDDH> ChiTietDDHs { get; set; }
    }
}