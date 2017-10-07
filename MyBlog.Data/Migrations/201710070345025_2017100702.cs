namespace MyBlog.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2017100702 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Classifies", "Name", c => c.String(maxLength: 64));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Classifies", "Name", c => c.String(nullable: false, maxLength: 64));
        }
    }
}
