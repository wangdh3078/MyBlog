namespace MyBlog.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddWeightRecord : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WeightRecords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Weight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Date = c.DateTime(nullable: false),
                        CreateUserId = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.WeightRecords");
        }
    }
}
