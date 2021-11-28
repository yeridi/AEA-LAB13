namespace APITecsup.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v8 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clients", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Clients", "Name", c => c.Int(nullable: false));
        }
    }
}
