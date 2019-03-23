namespace SugarFreeDiet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DescriptionNotRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Recipes", "Description", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Recipes", "Description", c => c.String(nullable: false));
        }
    }
}
