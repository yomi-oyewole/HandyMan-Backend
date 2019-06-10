namespace HandyManAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPasswordhashSaltByte : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Logins", "PasswordHash", c => c.Binary());
            AddColumn("dbo.Logins", "PasswordSalt", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Logins", "PasswordSalt");
            DropColumn("dbo.Logins", "PasswordHash");
        }
    }
}
