using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Website.Models
{
    public class NVGiaoHang
    {
        [Key]
        public string MaNVGH { get; set; }
        public string TenNVGH { get; set; }
        public string SoDienThoai { get; set; }
        public ICollection<DDH> DDHs { get; set; }
    }
}