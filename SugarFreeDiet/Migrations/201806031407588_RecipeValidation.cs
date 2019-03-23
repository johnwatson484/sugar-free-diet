namespace SugarFreeDiet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RecipeValidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Recipes", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Recipes", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Recipes", "Ingredients", c => c.String(nullable: false));
            AlterColumn("dbo.Recipes", "Directions", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Recipes", "Directions", c => c.String());
            AlterColumn("dbo.Recipes", "Ingredients", c => c.String());
            AlterColumn("dbo.Recipes", "Description", c => c.String());
            AlterColumn("dbo.Recipes", "Title", c => c.String());
        }
    }
}
