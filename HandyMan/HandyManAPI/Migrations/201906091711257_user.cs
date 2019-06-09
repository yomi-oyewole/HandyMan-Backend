namespace HandyManAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class user : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Logins", name: "UserId_UserId", newName: "UserId");
            RenameColumn(table: "dbo.Sessions", name: "UserId_UserId", newName: "UserId");
            RenameIndex(table: "dbo.Logins", name: "IX_UserId_UserId", newName: "IX_UserId");
            RenameIndex(table: "dbo.Sessions", name: "IX_UserId_UserId", newName: "IX_UserId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Sessions", name: "IX_UserId", newName: "IX_UserId_UserId");
            RenameIndex(table: "dbo.Logins", name: "IX_UserId", newName: "IX_UserId_UserId");
            RenameColumn(table: "dbo.Sessions", name: "UserId", newName: "UserId_UserId");
            RenameColumn(table: "dbo.Logins", name: "UserId", newName: "UserId_UserId");
        }
    }
}
