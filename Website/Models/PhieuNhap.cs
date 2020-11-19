using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Website.Models
{
    public class PhieuNhap
    {
        [Key]
        public string MaPhieuNhap { get; set; }
        public DateTime NgayTao { get; set; }
        public string MaNCC { get; set; }
        [ForeignKey("MaNCC")]
        public NCC NCC { get; set; }
        public ICollection<ChiTietNhap> ChiTietNhaps { get; set; }
    }
}