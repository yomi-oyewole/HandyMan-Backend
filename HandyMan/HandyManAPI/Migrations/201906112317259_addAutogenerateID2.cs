namespace HandyManAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAutogenerateID2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Jobs", "UserId", "dbo.Users");
            DropForeignKey("dbo.Logins", "UserId", "dbo.Users");
            DropForeignKey("dbo.Sessions", "UserId", "dbo.Users");
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.Users", "UserId", c => c.Guid(nullable: false, identity: true));
            AddPrimaryKey("dbo.Users", "UserId");
            AddForeignKey("dbo.Jobs", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.Logins", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.Sessions", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sessions", "UserId", "dbo.Users");
            DropForeignKey("dbo.Logins", "UserId", "dbo.Users");
            DropForeignKey("dbo.Jobs", "UserId", "dbo.Users");
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.Users", "UserId", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.Users", "UserId");
            AddForeignKey("dbo.Sessions", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.Logins", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.Jobs", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
        }
    }
}
