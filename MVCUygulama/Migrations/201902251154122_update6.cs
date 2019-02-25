namespace MVCUygulama.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.kitaps", "isDeleted", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.kitaps", "isDeleted");
        }
    }
}
