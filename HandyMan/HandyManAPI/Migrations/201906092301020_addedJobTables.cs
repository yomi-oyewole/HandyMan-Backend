namespace HandyManAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedJobTables : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "Description", c => c.String(nullable: false));
            AddColumn("dbo.Jobs", "Title", c => c.String(nullable: false));
            AddColumn("dbo.Jobs", "Summary", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "ConfirmPassword", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "ConfirmPassword", c => c.String());
            AlterColumn("dbo.Users", "Password", c => c.String());
            AlterColumn("dbo.Users", "Email", c => c.String());
            AlterColumn("dbo.Users", "LastName", c => c.String());
            AlterColumn("dbo.Users", "FirstName", c => c.String());
            DropColumn("dbo.Jobs", "Summary");
            DropColumn("dbo.Jobs", "Title");
            DropColumn("dbo.Jobs", "Description");
        }
    }
}
