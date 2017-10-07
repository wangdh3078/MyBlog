namespace MyBlog.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2017100701 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Blogs", name: "Classify_Id", newName: "ClassifyId");
            RenameIndex(table: "dbo.Blogs", name: "IX_Classify_Id", newName: "IX_ClassifyId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Blogs", name: "IX_ClassifyId", newName: "IX_Classify_Id");
            RenameColumn(table: "dbo.Blogs", name: "ClassifyId", newName: "Classify_Id");
        }
    }
}
