namespace HandyManAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedpasswordtoLogin : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Logins", "Password", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Logins", "Password");
        }
    }
}
