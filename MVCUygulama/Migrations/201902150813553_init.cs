namespace MVCUygulama.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MYazars",
                c => new
                    {
                        YazarID = c.Int(nullable: false, identity: true),
                        YazarAD = c.String(),
                        MakaleSayisi = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.YazarID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MYazars");
        }
    }
}
