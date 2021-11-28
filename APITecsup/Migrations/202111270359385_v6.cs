namespace APITecsup.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v6 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ClientId = c.Int(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClientId);
            
            AddColumn("dbo.Invoices", "ClientID", c => c.Int(nullable: false));
            CreateIndex("dbo.Invoices", "ClientID");
            AddForeignKey("dbo.Invoices", "ClientID", "dbo.Clients", "ClientId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Invoices", "ClientID", "dbo.Clients");
            DropIndex("dbo.Invoices", new[] { "ClientID" });
            DropColumn("dbo.Invoices", "ClientID");
            DropTable("dbo.Clients");
        }
    }
}
