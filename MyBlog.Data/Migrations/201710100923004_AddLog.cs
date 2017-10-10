namespace MyBlog.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLog : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Logs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Level = c.Int(nullable: false),
                        Message = c.String(),
                        UserId = c.Int(),
                        UserName = c.String(),
                        OperationType = c.String(),
                        Module = c.String(),
                        OperationDate = c.DateTime(nullable: false),
                        IP = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Logs");
        }
    }
}
