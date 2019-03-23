namespace SugarFreeDiet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Recipes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        RecipeId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                        Created = c.DateTime(nullable: false),
                        Text = c.String(),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.Recipes", t => t.RecipeId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.RecipeId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Recipes",
                c => new
                    {
                        RecipeId = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        Created = c.DateTime(nullable: false),
                        Title = c.String(),
                        Description = c.String(),
                        Ingredients = c.String(),
                        Directions = c.String(),
                        Hours = c.Int(nullable: false),
                        Minutes = c.Int(nullable: false),
                        Image = c.Binary(),
                    })
                .PrimaryKey(t => t.RecipeId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Replies",
                c => new
                    {
                        ReplyId = c.Int(nullable: false, identity: true),
                        CommentId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                        Created = c.DateTime(nullable: false),
                        Text = c.String(),
                    })
                .PrimaryKey(t => t.ReplyId)
                .ForeignKey("dbo.Comments", t => t.CommentId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.CommentId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Replies", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Replies", "CommentId", "dbo.Comments");
            DropForeignKey("dbo.Recipes", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comments", "RecipeId", "dbo.Recipes");
            DropIndex("dbo.Replies", new[] { "UserId" });
            DropIndex("dbo.Replies", new[] { "CommentId" });
            DropIndex("dbo.Recipes", new[] { "UserId" });
            DropIndex("dbo.Comments", new[] { "UserId" });
            DropIndex("dbo.Comments", new[] { "RecipeId" });
            DropTable("dbo.Replies");
            DropTable("dbo.Recipes");
            DropTable("dbo.Comments");
        }
    }
}
