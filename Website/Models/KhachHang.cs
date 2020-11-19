using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Website.Models
{
    public class KhachHang
    {
        [Key]
        public string MaKhachHang { get; set; }
        [Required,MaxLength(30)]
        public string TenKhachHang { get; set; }
        public string DiaChi { get; set; }
        [Required,MinLength(8), MaxLength(15)]
        public string DienThoai { get; set; }
        [Required,EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [NotMapped]
        [Required]
        [System.ComponentModel.DataAnnotations.Compare("Password")]
        public string confirm_password { get; set; }

        public ICollection<HoaDon> HoaDons { get; set; }
        public ICollection<PhieuXuat> PhieuXuats { get; set; }
        public ICollection<ChiTietXuat> ChiTietXuats { get; set; }
        public ICollection<DDH> DDHs { get; set; }

      
    }
}