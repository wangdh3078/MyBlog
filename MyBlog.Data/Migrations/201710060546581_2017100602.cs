namespace MyBlog.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2017100602 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Blogs", "Title", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Classifies", "Name", c => c.String(nullable: false, maxLength: 64));
            AlterColumn("dbo.Tags", "Name", c => c.String(nullable: false, maxLength: 64));
            AlterColumn("dbo.Users", "LoginName", c => c.String(nullable: false, maxLength: 64));
            AlterColumn("dbo.Users", "NickName", c => c.String(maxLength: 64));
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("dbo.Users", "Email", c => c.String(maxLength: 128));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Email", c => c.String());
            AlterColumn("dbo.Users", "Password", c => c.String());
            AlterColumn("dbo.Users", "NickName", c => c.String());
            AlterColumn("dbo.Users", "LoginName", c => c.String());
            AlterColumn("dbo.Tags", "Name", c => c.String());
            AlterColumn("dbo.Classifies", "Name", c => c.String());
            AlterColumn("dbo.Blogs", "Title", c => c.String());
        }
    }
}
