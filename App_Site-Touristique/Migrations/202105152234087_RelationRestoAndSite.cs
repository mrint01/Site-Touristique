namespace App_Site_Touristique.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RelationRestoAndSite : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Restaurants", "SiteTouristique_Id", c => c.Int());
            CreateIndex("dbo.Restaurants", "SiteTouristique_Id");
            AddForeignKey("dbo.Restaurants", "SiteTouristique_Id", "dbo.SiteTouristiques", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Restaurants", "SiteTouristique_Id", "dbo.SiteTouristiques");
            DropIndex("dbo.Restaurants", new[] { "SiteTouristique_Id" });
            DropColumn("dbo.Restaurants", "SiteTouristique_Id");
        }
    }
}
