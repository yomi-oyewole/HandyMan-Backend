namespace HandyManAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addNewDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                        Description = c.String(nullable: false),
                        Title = c.String(nullable: false),
                        Summary = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Guid(nullable: false , identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Address = c.String(),
                        Address2 = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Country = c.String(),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        ConfirmPassword = c.String(),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Logins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                        Email = c.String(),
                        PasswordHash = c.Binary(),
                        PasswordSalt = c.Binary(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Sessions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Token = c.String(),
                        UserId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sessions", "UserId", "dbo.Users");
            DropForeignKey("dbo.Logins", "UserId", "dbo.Users");
            DropForeignKey("dbo.Jobs", "UserId", "dbo.Users");
            DropIndex("dbo.Sessions", new[] { "UserId" });
            DropIndex("dbo.Logins", new[] { "UserId" });
            DropIndex("dbo.Jobs", new[] { "UserId" });
            DropTable("dbo.Sessions");
            DropTable("dbo.Logins");
            DropTable("dbo.Users");
            DropTable("dbo.Jobs");
        }
    }
}
