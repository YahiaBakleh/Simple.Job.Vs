namespace JobExample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstTimeRolles4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Jobs", "CategoryID_Id", "dbo.Categories");
            DropIndex("dbo.Jobs", new[] { "CategoryID_Id" });
            RenameColumn(table: "dbo.Categories", name: "Category", newName: "CategoryTitle");
            RenameColumn(table: "dbo.Jobs", name: "CategoryID_Id", newName: "CategoryId");
            AlterColumn("dbo.Jobs", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Jobs", "CategoryId");
            AddForeignKey("dbo.Jobs", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Jobs", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Jobs", new[] { "CategoryId" });
            AlterColumn("dbo.Jobs", "CategoryId", c => c.Int());
            RenameColumn(table: "dbo.Jobs", name: "CategoryId", newName: "CategoryID_Id");
            RenameColumn(table: "dbo.Categories", name: "CategoryTitle", newName: "Category");
            CreateIndex("dbo.Jobs", "CategoryID_Id");
            AddForeignKey("dbo.Jobs", "CategoryID_Id", "dbo.Categories", "Id");
        }
    }
}
