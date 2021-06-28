namespace App_Site_Touristique.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addadd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Activities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(nullable: false),
                        Genre = c.String(nullable: false),
                        prix = c.Single(nullable: false),
                        siteTouristiques_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SiteTouristiques", t => t.siteTouristiques_Id)
                .Index(t => t.siteTouristiques_Id);
            
            CreateTable(
                "dbo.SiteTouristiques",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        nom = c.String(nullable: false),
                        Anciete = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Transports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(nullable: false),
                        Ligne = c.String(nullable: false),
                        siteTouristiques_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SiteTouristiques", t => t.siteTouristiques_Id)
                .Index(t => t.siteTouristiques_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transports", "siteTouristiques_Id", "dbo.SiteTouristiques");
            DropForeignKey("dbo.Activities", "siteTouristiques_Id", "dbo.SiteTouristiques");
            DropIndex("dbo.Transports", new[] { "siteTouristiques_Id" });
            DropIndex("dbo.Activities", new[] { "siteTouristiques_Id" });
            DropTable("dbo.Transports");
            DropTable("dbo.SiteTouristiques");
            DropTable("dbo.Activities");
        }
    }
}
