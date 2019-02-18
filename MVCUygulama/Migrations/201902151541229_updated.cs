namespace MVCUygulama.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ders",
                c => new
                    {
                        dersId = c.Int(nullable: false, identity: true),
                        dersAdi = c.String(),
                    })
                .PrimaryKey(t => t.dersId);
            
            CreateTable(
                "dbo.Ogrencis",
                c => new
                    {
                        OgrNo = c.Int(nullable: false, identity: true),
                        Ad = c.String(),
                        Soyad = c.String(),
                    })
                .PrimaryKey(t => t.OgrNo);
            
            CreateTable(
                "dbo.OgrenciDers",
                c => new
                    {
                        Ogrenci_OgrNo = c.Int(nullable: false),
                        Ders_dersId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Ogrenci_OgrNo, t.Ders_dersId })
                .ForeignKey("dbo.Ogrencis", t => t.Ogrenci_OgrNo, cascadeDelete: true)
                .ForeignKey("dbo.Ders", t => t.Ders_dersId, cascadeDelete: true)
                .Index(t => t.Ogrenci_OgrNo)
                .Index(t => t.Ders_dersId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OgrenciDers", "Ders_dersId", "dbo.Ders");
            DropForeignKey("dbo.OgrenciDers", "Ogrenci_OgrNo", "dbo.Ogrencis");
            DropIndex("dbo.OgrenciDers", new[] { "Ders_dersId" });
            DropIndex("dbo.OgrenciDers", new[] { "Ogrenci_OgrNo" });
            DropTable("dbo.OgrenciDers");
            DropTable("dbo.Ogrencis");
            DropTable("dbo.Ders");
        }
    }
}
