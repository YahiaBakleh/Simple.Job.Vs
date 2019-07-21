namespace JobExample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstTimeRolles : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Category = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        JobTitle = c.String(),
                        CategoryId_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId_Id)
                .Index(t => t.CategoryId_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Jobs", "CategoryId_Id", "dbo.Categories");
            DropIndex("dbo.Jobs", new[] { "CategoryId_Id" });
            DropTable("dbo.Jobs");
            DropTable("dbo.Categories");
        }
    }
}
