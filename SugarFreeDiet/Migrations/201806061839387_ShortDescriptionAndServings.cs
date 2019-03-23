namespace SugarFreeDiet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ShortDescriptionAndServings : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Recipes", "ShortDescription", c => c.String(nullable: false));
            AddColumn("dbo.Recipes", "Servings", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Recipes", "Servings");
            DropColumn("dbo.Recipes", "ShortDescription");
        }
    }
}
