namespace BootzAndCatz.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cat",
                c => new
                    {
                        CatId = c.Int(nullable: false, identity: true),
                        IsDeclawed = c.Boolean(nullable: false),
                        IsFat = c.Boolean(nullable: false),
                        ShelterId = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Breed = c.String(nullable: false),
                        Age = c.Int(nullable: false),
                        AboutMe = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CatId)
                .ForeignKey("dbo.Shelter", t => t.ShelterId, cascadeDelete: true)
                .Index(t => t.ShelterId);
            
            CreateTable(
                "dbo.Shelter",
                c => new
                    {
                        ShelterId = c.Int(nullable: false, identity: true),
                        ShelterOwnerId = c.Guid(nullable: false),
                        ShelterName = c.String(nullable: false),
                        ZipCode = c.Int(nullable: false),
                        Description = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        Address = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ShelterId);
            
            CreateTable(
                "dbo.Dog",
                c => new
                    {
                        DogId = c.Int(nullable: false, identity: true),
                        IsChipped = c.Boolean(nullable: false),
                        EnergyLevel = c.String(nullable: false),
                        Size = c.String(nullable: false),
                        ShelterId = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Breed = c.String(nullable: false),
                        Age = c.Int(nullable: false),
                        AboutMe = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.DogId)
                .ForeignKey("dbo.Shelter", t => t.ShelterId, cascadeDelete: true)
                .Index(t => t.ShelterId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Dog", "ShelterId", "dbo.Shelter");
            DropForeignKey("dbo.Cat", "ShelterId", "dbo.Shelter");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Dog", new[] { "ShelterId" });
            DropIndex("dbo.Cat", new[] { "ShelterId" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Dog");
            DropTable("dbo.Shelter");
            DropTable("dbo.Cat");
        }
    }
}
