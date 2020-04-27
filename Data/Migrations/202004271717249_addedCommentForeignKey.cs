namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedCommentForeignKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comment", "Author_UserId", "dbo.User");
            DropIndex("dbo.Comment", new[] { "Author_UserId" });
            RenameColumn(table: "dbo.Comment", name: "Author_UserId", newName: "UserId");
            AlterColumn("dbo.Comment", "UserId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Comment", "UserId");
            AddForeignKey("dbo.Comment", "UserId", "dbo.User", "UserId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comment", "UserId", "dbo.User");
            DropIndex("dbo.Comment", new[] { "UserId" });
            AlterColumn("dbo.Comment", "UserId", c => c.Guid());
            RenameColumn(table: "dbo.Comment", name: "UserId", newName: "Author_UserId");
            CreateIndex("dbo.Comment", "Author_UserId");
            AddForeignKey("dbo.Comment", "Author_UserId", "dbo.User", "UserId");
        }
    }
}
