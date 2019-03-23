namespace SugarFreeDiet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VegetarianVegan : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Recipes", "Vegetarian", c => c.Boolean(nullable: false));
            AddColumn("dbo.Recipes", "Vegan", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Recipes", "Vegan");
            DropColumn("dbo.Recipes", "Vegetarian");
        }
    }
}
