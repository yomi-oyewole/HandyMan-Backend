namespace HandyManAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovePasswordhashSalt : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Logins", "PasswordHash");
            DropColumn("dbo.Logins", "PasswordSalt");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Logins", "PasswordSalt", c => c.String());
            AddColumn("dbo.Logins", "PasswordHash", c => c.String());
        }
    }
}
