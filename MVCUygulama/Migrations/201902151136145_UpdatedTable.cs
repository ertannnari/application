namespace MVCUygulama.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MYazars", "isDeleted", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MYazars", "isDeleted");
        }
    }
}
