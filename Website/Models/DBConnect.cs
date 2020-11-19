namespace Website.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBConnect : DbContext
    {
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<NCC> NCCs { get; set; }
        public virtual DbSet<VatTu> VatTus { get; set; }
        public virtual DbSet<DDH> DDHs { get; set; }
        public virtual DbSet<ChiTietDDH> ChiTietDDHs { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<ChiTietNhap> ChiTietNhaps { get; set; }
        public virtual DbSet<ChiTietXuat> ChiTietXuats { get; set; }
        public virtual DbSet<Ton> Tons { get; set; }
        public virtual DbSet<PhieuNhap> PhieuNhaps { get; set; }
        public virtual DbSet<PhieuXuat> PhieuXuats { get; set; }
      
        public virtual DbSet<NVGiaoHang> NVGiaoHangs { get; set; }
        public DBConnect()
            : base("name=DBConnect")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
