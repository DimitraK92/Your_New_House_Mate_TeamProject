namespace YNHM.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Houses",
                c => new
                    {
                        HouseId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Address = c.String(),
                        PostalCode = c.String(),
                        PageViews = c.Int(nullable: false),
                        Area = c.Int(nullable: false),
                        Floor = c.Int(nullable: false),
                        Bedrooms = c.Int(nullable: false),
                        Rent = c.Int(nullable: false),
                        District = c.String(),
                        MapLocation = c.String(),
                        ElevatorInBuilding = c.Boolean(nullable: false),
                        FreeWiFi = c.Boolean(nullable: false),
                        Parking = c.Boolean(nullable: false),
                        AirCondition = c.Boolean(nullable: false),
                        PetFriendly = c.Boolean(nullable: false),
                        OutdoorSeating = c.Boolean(nullable: false),
                        WheelchairFriendly = c.Boolean(nullable: false),
                        OwnerId = c.Int(),
                    })
                .PrimaryKey(t => t.HouseId);
            
            CreateTable(
                "dbo.Photos",
                c => new
                    {
                        PhotoId = c.Int(nullable: false, identity: true),
                        PhotoUrl = c.String(),
                        HouseId = c.Int(),
                    })
                .PrimaryKey(t => t.PhotoId)
                .ForeignKey("dbo.Houses", t => t.HouseId)
                .Index(t => t.HouseId);
            
            CreateTable(
                "dbo.HouseSeekers",
                c => new
                    {
                        HouseSeekerId = c.Int(nullable: false, identity: true),
                        MatchPercent = c.Int(nullable: false),
                        HouseId = c.Int(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Age = c.Int(nullable: false),
                        Phone = c.String(),
                        Email = c.String(),
                        Facebook = c.String(),
                        Description = c.String(),
                        PhotoUrl = c.String(),
                        Test_TestId = c.Int(),
                    })
                .PrimaryKey(t => t.HouseSeekerId)
                .ForeignKey("dbo.Tests", t => t.Test_TestId)
                .Index(t => t.Test_TestId);
            
            CreateTable(
                "dbo.Tests",
                c => new
                    {
                        TestId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        PersonName = c.String(),
                        QuestionSetId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TestId)
                .ForeignKey("dbo.QuestionSets", t => t.QuestionSetId, cascadeDelete: true)
                .Index(t => t.QuestionSetId);
            
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        AnswerId = c.Int(nullable: false, identity: true),
                        MyAnswer = c.Int(nullable: false),
                        PreferedAnswer = c.Int(nullable: false),
                        Importance = c.Int(nullable: false),
                        Significance = c.Int(nullable: false),
                        Question_QuestionId = c.Int(),
                        Test_TestId = c.Int(),
                    })
                .PrimaryKey(t => t.AnswerId)
                .ForeignKey("dbo.Questions", t => t.Question_QuestionId)
                .ForeignKey("dbo.Tests", t => t.Test_TestId)
                .Index(t => t.Question_QuestionId)
                .Index(t => t.Test_TestId);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        QuestionId = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        Test_TestId = c.Int(),
                        QuestionSet_QuestionSetId = c.Int(),
                    })
                .PrimaryKey(t => t.QuestionId)
                .ForeignKey("dbo.Tests", t => t.Test_TestId)
                .ForeignKey("dbo.QuestionSets", t => t.QuestionSet_QuestionSetId)
                .Index(t => t.Test_TestId)
                .Index(t => t.QuestionSet_QuestionSetId);
            
            CreateTable(
                "dbo.QuestionSets",
                c => new
                    {
                        QuestionSetId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.QuestionSetId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        HouseSeekerId = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.HouseSeekers", "Test_TestId", "dbo.Tests");
            DropForeignKey("dbo.Tests", "QuestionSetId", "dbo.QuestionSets");
            DropForeignKey("dbo.Questions", "QuestionSet_QuestionSetId", "dbo.QuestionSets");
            DropForeignKey("dbo.Questions", "Test_TestId", "dbo.Tests");
            DropForeignKey("dbo.Answers", "Test_TestId", "dbo.Tests");
            DropForeignKey("dbo.Answers", "Question_QuestionId", "dbo.Questions");
            DropForeignKey("dbo.Photos", "HouseId", "dbo.Houses");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Questions", new[] { "QuestionSet_QuestionSetId" });
            DropIndex("dbo.Questions", new[] { "Test_TestId" });
            DropIndex("dbo.Answers", new[] { "Test_TestId" });
            DropIndex("dbo.Answers", new[] { "Question_QuestionId" });
            DropIndex("dbo.Tests", new[] { "QuestionSetId" });
            DropIndex("dbo.HouseSeekers", new[] { "Test_TestId" });
            DropIndex("dbo.Photos", new[] { "HouseId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.QuestionSets");
            DropTable("dbo.Questions");
            DropTable("dbo.Answers");
            DropTable("dbo.Tests");
            DropTable("dbo.HouseSeekers");
            DropTable("dbo.Photos");
            DropTable("dbo.Houses");
        }
    }
}
