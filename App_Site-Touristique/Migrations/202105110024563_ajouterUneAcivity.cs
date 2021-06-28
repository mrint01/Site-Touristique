namespace App_Site_Touristique.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ajouterUneAcivity : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO ACTIVITIES(Nom,Genre,prix) Values(1 ,2,40.00)");
            Sql("INSERT INTO ACTIVITIES(Nom,Genre,prix) Values(2,2,40.00)");
            Sql("INSERT INTO ACTIVITIES(Nom,Genre,prix) Values(3 ,5,40.00)");


        }

        public override void Down()
        {
        }
    }
}
