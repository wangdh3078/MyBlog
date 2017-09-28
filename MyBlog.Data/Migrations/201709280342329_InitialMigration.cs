namespace MyBlog.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        ShortContext = c.String(),
                        Context = c.String(),
                        Author = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        PublishedDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        IsPublished = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Classifies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LoginName = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        IsDisabled = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BlogsClassify",
                c => new
                    {
                        BlogId = c.Int(nullable: false),
                        ClassifyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.BlogId, t.ClassifyId })
                .ForeignKey("dbo.Blogs", t => t.BlogId, cascadeDelete: true)
                .ForeignKey("dbo.Classifies", t => t.ClassifyId, cascadeDelete: true)
                .Index(t => t.BlogId)
                .Index(t => t.ClassifyId);
            
            CreateTable(
                "dbo.BlogTags",
                c => new
                    {
                        BlogId = c.Int(nullable: false),
                        TagId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.BlogId, t.TagId })
                .ForeignKey("dbo.Blogs", t => t.BlogId, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.TagId, cascadeDelete: true)
                .Index(t => t.BlogId)
                .Index(t => t.TagId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BlogTags", "TagId", "dbo.Tags");
            DropForeignKey("dbo.BlogTags", "BlogId", "dbo.Blogs");
            DropForeignKey("dbo.BlogsClassify", "ClassifyId", "dbo.Classifies");
            DropForeignKey("dbo.BlogsClassify", "BlogId", "dbo.Blogs");
            DropIndex("dbo.BlogTags", new[] { "TagId" });
            DropIndex("dbo.BlogTags", new[] { "BlogId" });
            DropIndex("dbo.BlogsClassify", new[] { "ClassifyId" });
            DropIndex("dbo.BlogsClassify", new[] { "BlogId" });
            DropTable("dbo.BlogTags");
            DropTable("dbo.BlogsClassify");
            DropTable("dbo.Users");
            DropTable("dbo.Tags");
            DropTable("dbo.Classifies");
            DropTable("dbo.Blogs");
        }
    }
}
