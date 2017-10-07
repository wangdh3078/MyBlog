namespace MyBlog.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20171007001 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Blogs", "ClassifyId", "dbo.Classifies");
            AddForeignKey("dbo.Blogs", "ClassifyId", "dbo.Classifies", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Blogs", "ClassifyId", "dbo.Classifies");
            AddForeignKey("dbo.Blogs", "ClassifyId", "dbo.Classifies", "Id", cascadeDelete: true);
        }
    }
}
