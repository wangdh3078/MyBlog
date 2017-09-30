namespace MyBlog.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeStruct : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BlogsClassify", "BlogId", "dbo.Blogs");
            DropForeignKey("dbo.BlogsClassify", "ClassifyId", "dbo.Classifies");
            DropIndex("dbo.BlogsClassify", new[] { "BlogId" });
            DropIndex("dbo.BlogsClassify", new[] { "ClassifyId" });
            AddColumn("dbo.Blogs", "Classify_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Blogs", "Classify_Id");
            AddForeignKey("dbo.Blogs", "Classify_Id", "dbo.Classifies", "Id", cascadeDelete: true);
            DropTable("dbo.BlogsClassify");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.BlogsClassify",
                c => new
                    {
                        BlogId = c.Int(nullable: false),
                        ClassifyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.BlogId, t.ClassifyId });
            
            DropForeignKey("dbo.Blogs", "Classify_Id", "dbo.Classifies");
            DropIndex("dbo.Blogs", new[] { "Classify_Id" });
            DropColumn("dbo.Blogs", "Classify_Id");
            CreateIndex("dbo.BlogsClassify", "ClassifyId");
            CreateIndex("dbo.BlogsClassify", "BlogId");
            AddForeignKey("dbo.BlogsClassify", "ClassifyId", "dbo.Classifies", "Id", cascadeDelete: true);
            AddForeignKey("dbo.BlogsClassify", "BlogId", "dbo.Blogs", "Id", cascadeDelete: true);
        }
    }
}
