using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Website.Models
{
    public class VatTu
    {
        [Key]
        public string MaVatTu { get; set; }
        public string TenVatTu { get; set; }
        public Decimal DonGia { get; set; }
        public string DonViTinh { get; set; }
        public string MaNCC { get; set; }
        [ForeignKey("MaNCC")]
        public NCC NCC { get; set; }
        public string HangSanXuat { get; set; }
        public ICollection<Ton> Tons { get; set; }
        public ICollection<ChiTietNhap> ChiTietNhaps { get; set; }
        public ICollection<ChiTietXuat> ChiTietXuats { get; set; }
        public ICollection<ChiTietDDH> ChiTietDDHs { get; set; }
    }
}