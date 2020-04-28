namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class replyServiceUserID : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApplicationUser", "UserId", c => c.Guid());
            AddColumn("dbo.ApplicationUser", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ApplicationUser", "Discriminator");
            DropColumn("dbo.ApplicationUser", "UserId");
        }
    }
}
