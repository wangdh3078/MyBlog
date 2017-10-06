namespace MyBlog.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2017100601 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "CreateUserId", c => c.Int(nullable: false));
            AddColumn("dbo.Classifies", "CreateUserId", c => c.Int(nullable: false));
            AddColumn("dbo.Tags", "CreateUserId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tags", "CreateUserId");
            DropColumn("dbo.Classifies", "CreateUserId");
            DropColumn("dbo.Blogs", "CreateUserId");
        }
    }
}
