namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comment", "ReplyComment_CommentId", "dbo.Comment");
            RenameColumn(table: "dbo.Comment", name: "ReplyComment_Id", newName: "ReplyComment_CommentId");
            RenameIndex(table: "dbo.Comment", name: "IX_ReplyComment_Id", newName: "IX_ReplyComment_CommentId");
            DropPrimaryKey("dbo.Comment");
            AddColumn("dbo.Comment", "CommentId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Comment", "CommentId");
            AddForeignKey("dbo.Comment", "ReplyComment_CommentId", "dbo.Comment", "CommentId");
            DropColumn("dbo.Comment", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comment", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Comment", "ReplyComment_CommentId", "dbo.Comment");
            DropPrimaryKey("dbo.Comment");
            DropColumn("dbo.Comment", "CommentId");
            AddPrimaryKey("dbo.Comment", "Id");
            RenameIndex(table: "dbo.Comment", name: "IX_ReplyComment_CommentId", newName: "IX_ReplyComment_Id");
            RenameColumn(table: "dbo.Comment", name: "ReplyComment_CommentId", newName: "ReplyComment_Id");
            AddForeignKey("dbo.Comment", "ReplyComment_CommentId", "dbo.Comment", "CommentId");
        }
    }
}
