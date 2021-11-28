namespace APITecsup.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Details", "Igv", c => c.Int(nullable: false));
            AddColumn("dbo.Details", "Total", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Details", "Total");
            DropColumn("dbo.Details", "Igv");
        }
    }
}
