namespace App_Site_Touristique.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddResto : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Restaurants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NumTel = c.String(nullable: false),
                        Type_De_Cuisine = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Restaurants");
        }
    }
}
