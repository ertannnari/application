namespace MVCUygulama.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedTable1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.kitaps",
                c => new
                    {
                        makaleId = c.Int(nullable: false, identity: true),
                        makaleAdi = c.String(),
                        YazarID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.makaleId)
                .ForeignKey("dbo.MYazars", t => t.YazarID, cascadeDelete: true)
                .Index(t => t.YazarID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.kitaps", "YazarID", "dbo.MYazars");
            DropIndex("dbo.kitaps", new[] { "YazarID" });
            DropTable("dbo.kitaps");
        }
    }
}
