namespace Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChiTietDDHs",
                c => new
                    {
                        IDChiTiet = c.Int(nullable: false, identity: true),
                        IDDDH = c.Int(nullable: false),
                        MaVatTu = c.String(maxLength: 128),
                        SoLuong = c.Int(nullable: false),
                        DonGia = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IDChiTiet)
                .ForeignKey("dbo.DDHs", t => t.IDDDH, cascadeDelete: true)
                .ForeignKey("dbo.VatTus", t => t.MaVatTu)
                .Index(t => t.IDDDH)
                .Index(t => t.MaVatTu);
            
            CreateTable(
                "dbo.DDHs",
                c => new
                    {
                        IDDDH = c.Int(nullable: false, identity: true),
                        MaKhachHang = c.String(maxLength: 128),
                        IDTinhTrang = c.String(maxLength: 128),
                        MaNVGH = c.String(maxLength: 128),
                        NgayDH = c.DateTime(nullable: false),
                        TongGia = c.Int(nullable: false),
                        NoiNhan = c.String(),
                        GhiChu = c.String(),
                    })
                .PrimaryKey(t => t.IDDDH)
                .ForeignKey("dbo.KhachHangs", t => t.MaKhachHang)
                .ForeignKey("dbo.NVGiaoHangs", t => t.MaNVGH)
                .ForeignKey("dbo.TinhTrangs", t => t.IDTinhTrang)
                .Index(t => t.MaKhachHang)
                .Index(t => t.IDTinhTrang)
                .Index(t => t.MaNVGH);
            
            CreateTable(
                "dbo.KhachHangs",
                c => new
                    {
                        MaKhachHang = c.String(nullable: false, maxLength: 128),
                        TenKhachHang = c.String(nullable: false, maxLength: 30),
                        DiaChi = c.String(),
                        DienThoai = c.String(nullable: false, maxLength: 15),
                    })
                .PrimaryKey(t => t.MaKhachHang);
            
            CreateTable(
                "dbo.ChiTietXuats",
                c => new
                    {
                        STT = c.Int(nullable: false, identity: true),
                        MaPhieuXuat = c.String(maxLength: 128),
                        MaVatTu = c.String(maxLength: 128),
                        SoLuong = c.Int(nullable: false),
                        NgayXuat = c.DateTime(nullable: false),
                        MaKhachHang = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.STT)
                .ForeignKey("dbo.KhachHangs", t => t.MaKhachHang)
                .ForeignKey("dbo.PhieuXuats", t => t.MaPhieuXuat)
                .ForeignKey("dbo.VatTus", t => t.MaVatTu)
                .Index(t => t.MaPhieuXuat)
                .Index(t => t.MaVatTu)
                .Index(t => t.MaKhachHang);
            
            CreateTable(
                "dbo.PhieuXuats",
                c => new
                    {
                        MaPhieuXuat = c.String(nullable: false, maxLength: 128),
                        NgayTao = c.DateTime(nullable: false),
                        MaKhachHang = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.MaPhieuXuat)
                .ForeignKey("dbo.KhachHangs", t => t.MaKhachHang)
                .Index(t => t.MaKhachHang);
            
            CreateTable(
                "dbo.VatTus",
                c => new
                    {
                        MaVatTu = c.String(nullable: false, maxLength: 128),
                        TenVatTu = c.String(),
                        DonGia = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DonViTinh = c.String(),
                        MaNCC = c.String(maxLength: 128),
                        HangSanXuat = c.String(),
                    })
                .PrimaryKey(t => t.MaVatTu)
                .ForeignKey("dbo.NCCs", t => t.MaNCC)
                .Index(t => t.MaNCC);
            
            CreateTable(
                "dbo.ChiTietNhaps",
                c => new
                    {
                        STT = c.Int(nullable: false, identity: true),
                        MaPhieuNhap = c.String(maxLength: 128),
                        MaVatTu = c.String(maxLength: 128),
                        SoLuong = c.Int(nullable: false),
                        NgayNhap = c.DateTime(nullable: false),
                        MaNCC = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.STT)
                .ForeignKey("dbo.NCCs", t => t.MaNCC)
                .ForeignKey("dbo.PhieuNhaps", t => t.MaPhieuNhap)
                .ForeignKey("dbo.VatTus", t => t.MaVatTu)
                .Index(t => t.MaPhieuNhap)
                .Index(t => t.MaVatTu)
                .Index(t => t.MaNCC);
            
            CreateTable(
                "dbo.NCCs",
                c => new
                    {
                        MaNCC = c.String(nullable: false, maxLength: 128),
                        TenNCC = c.String(),
                        DiaChi = c.String(),
                        DienThoai = c.String(),
                        TKNH = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.MaNCC);
            
            CreateTable(
                "dbo.PhieuNhaps",
                c => new
                    {
                        MaPhieuNhap = c.String(nullable: false, maxLength: 128),
                        NgayTao = c.DateTime(nullable: false),
                        MaNCC = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.MaPhieuNhap)
                .ForeignKey("dbo.NCCs", t => t.MaNCC)
                .Index(t => t.MaNCC);
            
            CreateTable(
                "dbo.Tons",
                c => new
                    {
                        STT = c.Int(nullable: false, identity: true),
                        MaVatTu = c.String(maxLength: 128),
                        SLTon = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.STT)
                .ForeignKey("dbo.VatTus", t => t.MaVatTu)
                .Index(t => t.MaVatTu);
            
            CreateTable(
                "dbo.HoaDons",
                c => new
                    {
                        MaHoaDon = c.String(nullable: false, maxLength: 128),
                        NgayTao = c.DateTime(nullable: false),
                        MaKhachHang = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.MaHoaDon)
                .ForeignKey("dbo.KhachHangs", t => t.MaKhachHang)
                .Index(t => t.MaKhachHang);
            
            CreateTable(
                "dbo.NVGiaoHangs",
                c => new
                    {
                        MaNVGH = c.String(nullable: false, maxLength: 128),
                        TenNVGH = c.String(),
                        SoDienThoai = c.String(),
                    })
                .PrimaryKey(t => t.MaNVGH);
            
            CreateTable(
                "dbo.TinhTrangs",
                c => new
                    {
                        IDTinhTrang = c.String(nullable: false, maxLength: 128),
                        TinhTrangDH = c.String(),
                    })
                .PrimaryKey(t => t.IDTinhTrang);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DDHs", "IDTinhTrang", "dbo.TinhTrangs");
            DropForeignKey("dbo.DDHs", "MaNVGH", "dbo.NVGiaoHangs");
            DropForeignKey("dbo.HoaDons", "MaKhachHang", "dbo.KhachHangs");
            DropForeignKey("dbo.DDHs", "MaKhachHang", "dbo.KhachHangs");
            DropForeignKey("dbo.Tons", "MaVatTu", "dbo.VatTus");
            DropForeignKey("dbo.ChiTietXuats", "MaVatTu", "dbo.VatTus");
            DropForeignKey("dbo.ChiTietNhaps", "MaVatTu", "dbo.VatTus");
            DropForeignKey("dbo.VatTus", "MaNCC", "dbo.NCCs");
            DropForeignKey("dbo.PhieuNhaps", "MaNCC", "dbo.NCCs");
            DropForeignKey("dbo.ChiTietNhaps", "MaPhieuNhap", "dbo.PhieuNhaps");
            DropForeignKey("dbo.ChiTietNhaps", "MaNCC", "dbo.NCCs");
            DropForeignKey("dbo.ChiTietDDHs", "MaVatTu", "dbo.VatTus");
            DropForeignKey("dbo.PhieuXuats", "MaKhachHang", "dbo.KhachHangs");
            DropForeignKey("dbo.ChiTietXuats", "MaPhieuXuat", "dbo.PhieuXuats");
            DropForeignKey("dbo.ChiTietXuats", "MaKhachHang", "dbo.KhachHangs");
            DropForeignKey("dbo.ChiTietDDHs", "IDDDH", "dbo.DDHs");
            DropIndex("dbo.HoaDons", new[] { "MaKhachHang" });
            DropIndex("dbo.Tons", new[] { "MaVatTu" });
            DropIndex("dbo.PhieuNhaps", new[] { "MaNCC" });
            DropIndex("dbo.ChiTietNhaps", new[] { "MaNCC" });
            DropIndex("dbo.ChiTietNhaps", new[] { "MaVatTu" });
            DropIndex("dbo.ChiTietNhaps", new[] { "MaPhieuNhap" });
            DropIndex("dbo.VatTus", new[] { "MaNCC" });
            DropIndex("dbo.PhieuXuats", new[] { "MaKhachHang" });
            DropIndex("dbo.ChiTietXuats", new[] { "MaKhachHang" });
            DropIndex("dbo.ChiTietXuats", new[] { "MaVatTu" });
            DropIndex("dbo.ChiTietXuats", new[] { "MaPhieuXuat" });
            DropIndex("dbo.DDHs", new[] { "MaNVGH" });
            DropIndex("dbo.DDHs", new[] { "IDTinhTrang" });
            DropIndex("dbo.DDHs", new[] { "MaKhachHang" });
            DropIndex("dbo.ChiTietDDHs", new[] { "MaVatTu" });
            DropIndex("dbo.ChiTietDDHs", new[] { "IDDDH" });
            DropTable("dbo.TinhTrangs");
            DropTable("dbo.NVGiaoHangs");
            DropTable("dbo.HoaDons");
            DropTable("dbo.Tons");
            DropTable("dbo.PhieuNhaps");
            DropTable("dbo.NCCs");
            DropTable("dbo.ChiTietNhaps");
            DropTable("dbo.VatTus");
            DropTable("dbo.PhieuXuats");
            DropTable("dbo.ChiTietXuats");
            DropTable("dbo.KhachHangs");
            DropTable("dbo.DDHs");
            DropTable("dbo.ChiTietDDHs");
        }
    }
}
