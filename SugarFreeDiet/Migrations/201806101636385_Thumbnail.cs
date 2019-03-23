namespace SugarFreeDiet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Thumbnail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Recipes", "Thumbnail", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Recipes", "Thumbnail");
        }
    }
}
