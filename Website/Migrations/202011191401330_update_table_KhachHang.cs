namespace Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_table_KhachHang : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.KhachHangs", "Email", c => c.String(nullable: false));
            AddColumn("dbo.KhachHangs", "Password", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.KhachHangs", "Password");
            DropColumn("dbo.KhachHangs", "Email");
        }
    }
}
