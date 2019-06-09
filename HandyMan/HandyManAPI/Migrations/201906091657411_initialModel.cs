namespace HandyManAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        DOB = c.DateTime(nullable: false),
                        Address = c.String(),
                        Address2 = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Country = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        ConfirmPassword = c.String(),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Logins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        PasswordHash = c.String(),
                        PasswordSalt = c.String(),
                        UserId_UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId_UserId)
                .Index(t => t.UserId_UserId);
            
            CreateTable(
                "dbo.Sessions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Token = c.String(),
                        UserId_UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId_UserId)
                .Index(t => t.UserId_UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sessions", "UserId_UserId", "dbo.Users");
            DropForeignKey("dbo.Logins", "UserId_UserId", "dbo.Users");
            DropForeignKey("dbo.Jobs", "UserId", "dbo.Users");
            DropIndex("dbo.Sessions", new[] { "UserId_UserId" });
            DropIndex("dbo.Logins", new[] { "UserId_UserId" });
            DropIndex("dbo.Jobs", new[] { "UserId" });
            DropTable("dbo.Sessions");
            DropTable("dbo.Logins");
            DropTable("dbo.Users");
            DropTable("dbo.Jobs");
        }
    }
}
