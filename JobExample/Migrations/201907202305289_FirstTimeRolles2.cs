namespace JobExample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstTimeRolles2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Jobs", "CategoryId_Id", "dbo.Categories");
            DropIndex("dbo.Jobs", new[] { "CategoryId_Id" });
            RenameColumn(table: "dbo.Jobs", name: "CategoryId_Id", newName: "CategoryId");
            AlterColumn("dbo.Jobs", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Jobs", "CategoryId");
            AddForeignKey("dbo.Jobs", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Jobs", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Jobs", new[] { "CategoryId" });
            AlterColumn("dbo.Jobs", "CategoryId", c => c.Int());
            RenameColumn(table: "dbo.Jobs", name: "CategoryId", newName: "CategoryId_Id");
            CreateIndex("dbo.Jobs", "CategoryId_Id");
            AddForeignKey("dbo.Jobs", "CategoryId_Id", "dbo.Categories", "Id");
        }
    }
}
