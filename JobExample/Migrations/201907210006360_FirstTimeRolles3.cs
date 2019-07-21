namespace JobExample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstTimeRolles3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Jobs", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Jobs", new[] { "CategoryId" });
            RenameColumn(table: "dbo.Jobs", name: "CategoryId", newName: "CategoryID_Id");
            AlterColumn("dbo.Jobs", "CategoryID_Id", c => c.Int());
            CreateIndex("dbo.Jobs", "CategoryID_Id");
            AddForeignKey("dbo.Jobs", "CategoryID_Id", "dbo.Categories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Jobs", "CategoryID_Id", "dbo.Categories");
            DropIndex("dbo.Jobs", new[] { "CategoryID_Id" });
            AlterColumn("dbo.Jobs", "CategoryID_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Jobs", name: "CategoryID_Id", newName: "CategoryId");
            CreateIndex("dbo.Jobs", "CategoryId");
            AddForeignKey("dbo.Jobs", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
    }
}
