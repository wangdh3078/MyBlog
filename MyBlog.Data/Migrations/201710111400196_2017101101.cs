namespace MyBlog.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2017101101 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Logs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Level = c.String(maxLength: 32),
                        UserId = c.Int(),
                        UserName = c.String(maxLength: 64),
                        Message = c.String(),
                        OperationType = c.String(maxLength: 64),
                        Module = c.String(maxLength: 128),
                        IP = c.String(maxLength: 128),
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
