namespace Blog.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createdb1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Titile = c.String(nullable: false, maxLength: 200),
                        Content = c.String(nullable: false, storeType: "ntext"),
                        GoodCount = c.Int(nullable: false),
                        BadCount = c.Int(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ArticleToCategories",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ArticleId = c.Guid(nullable: false),
                        CategoryId = c.Guid(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Articles", t => t.ArticleId, cascadeDelete: true)
                .ForeignKey("dbo.CategoryInfoes", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.ArticleId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.CategoryInfoes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CategoryName = c.String(nullable: false, maxLength: 50, unicode: false),
                        UserId = c.Guid(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserInfoes", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.ArticleToUserInfoes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        ArticleId = c.Guid(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Articles", t => t.ArticleId, cascadeDelete: true)
                .ForeignKey("dbo.UserInfoes", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.ArticleId);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CommentContent = c.String(nullable: false, maxLength: 500, unicode: false),
                        ArticleId = c.Guid(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Articles", t => t.ArticleId, cascadeDelete: true)
                .Index(t => t.ArticleId);
            
            CreateTable(
                "dbo.FansInfoes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FansId = c.Guid(nullable: false),
                        AuthorId = c.Guid(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserInfoes", t => t.FansId, cascadeDelete: true)
                .Index(t => t.FansId)
                .Index(t => t.AuthorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FansInfoes", "AuthorId", "dbo.UserInfoes");
            DropForeignKey("dbo.FansInfoes", "FansId", "dbo.UserInfoes");
            DropForeignKey("dbo.Comments", "ArticleId", "dbo.Articles");
            DropForeignKey("dbo.ArticleToUserInfoes", "UserId", "dbo.UserInfoes");
            DropForeignKey("dbo.ArticleToUserInfoes", "ArticleId", "dbo.Articles");
            DropForeignKey("dbo.ArticleToCategories", "CategoryId", "dbo.CategoryInfoes");
            DropForeignKey("dbo.CategoryInfoes", "UserId", "dbo.UserInfoes");
            DropForeignKey("dbo.ArticleToCategories", "ArticleId", "dbo.Articles");
            DropIndex("dbo.FansInfoes", new[] { "AuthorId" });
            DropIndex("dbo.FansInfoes", new[] { "FansId" });
            DropIndex("dbo.Comments", new[] { "ArticleId" });
            DropIndex("dbo.ArticleToUserInfoes", new[] { "ArticleId" });
            DropIndex("dbo.ArticleToUserInfoes", new[] { "UserId" });
            DropIndex("dbo.CategoryInfoes", new[] { "UserId" });
            DropIndex("dbo.ArticleToCategories", new[] { "CategoryId" });
            DropIndex("dbo.ArticleToCategories", new[] { "ArticleId" });
            DropTable("dbo.FansInfoes");
            DropTable("dbo.Comments");
            DropTable("dbo.ArticleToUserInfoes");
            DropTable("dbo.CategoryInfoes");
            DropTable("dbo.ArticleToCategories");
            DropTable("dbo.Articles");
        }
    }
}
