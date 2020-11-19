using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Website.Models
{
    public class NCC
    {
        [Key]
        public string MaNCC { get; set; }
        public string TenNCC { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }
        public string TKNH { get; set; }
        public string Email { get; set; }
        public ICollection<VatTu> VatTus { get; set; }
        public ICollection<PhieuNhap> PhieuNhaps { get; set; }
        public ICollection<ChiTietNhap> ChiTietNhaps { get; set; }
    }
}