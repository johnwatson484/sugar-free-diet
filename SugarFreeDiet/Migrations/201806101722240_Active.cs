namespace SugarFreeDiet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Active : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Recipes", "Active", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Recipes", "Active");
        }
    }
}
