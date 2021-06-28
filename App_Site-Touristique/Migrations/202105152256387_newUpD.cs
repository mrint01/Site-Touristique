namespace App_Site_Touristique.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newUpD : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Restaurants", "Nom", c => c.String(nullable: false));
            AddColumn("dbo.Restaurants", "leType", c => c.String(nullable: false));
            DropColumn("dbo.Restaurants", "Type_De_Cuisine");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Restaurants", "Type_De_Cuisine", c => c.String(nullable: false));
            DropColumn("dbo.Restaurants", "leType");
            DropColumn("dbo.Restaurants", "Nom");
        }
    }
}
