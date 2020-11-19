namespace Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_Table_DDH : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DDHs", "IDTinhTrang", "dbo.TinhTrangs");
            DropIndex("dbo.DDHs", new[] { "IDTinhTrang" });
            AddColumn("dbo.DDHs", "TinhTrangDH", c => c.String());
            DropColumn("dbo.DDHs", "IDTinhTrang");
            DropTable("dbo.TinhTrangs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TinhTrangs",
                c => new
                    {
                        IDTinhTrang = c.String(nullable: false, maxLength: 128),
                        TinhTrangDH = c.String(),
                    })
                .PrimaryKey(t => t.IDTinhTrang);
            
            AddColumn("dbo.DDHs", "IDTinhTrang", c => c.String(maxLength: 128));
            DropColumn("dbo.DDHs", "TinhTrangDH");
            CreateIndex("dbo.DDHs", "IDTinhTrang");
            AddForeignKey("dbo.DDHs", "IDTinhTrang", "dbo.TinhTrangs", "IDTinhTrang");
        }
    }
}
