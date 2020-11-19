using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Website.Models
{
    public class PhieuXuat
    {
        [Key]
        public string MaPhieuXuat { get; set; }
        public DateTime NgayTao { get; set; }
        public string MaKhachHang { get; set; }
        [ForeignKey("MaKhachHang")]
        public KhachHang KhachHang { get; set; }
        public ICollection<ChiTietXuat> ChiTietXuats { get; set; }
    }
}