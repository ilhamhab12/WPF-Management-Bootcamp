namespace Microservice.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addLevel : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Classes", new[] { "Departments_Id" });
            CreateTable(
                "dbo.Levels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Lessons", "levels_Id", c => c.Int());
            AddColumn("dbo.WeeklyScores", "levels_Id", c => c.Int());
            CreateIndex("dbo.Classes", "departments_Id");
            CreateIndex("dbo.Lessons", "levels_Id");
            CreateIndex("dbo.WeeklyScores", "levels_Id");
            AddForeignKey("dbo.Lessons", "levels_Id", "dbo.Levels", "Id");
            AddForeignKey("dbo.WeeklyScores", "levels_Id", "dbo.Levels", "Id");
            DropColumn("dbo.Lessons", "Level");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Lessons", "Level", c => c.String());
            DropForeignKey("dbo.WeeklyScores", "levels_Id", "dbo.Levels");
            DropForeignKey("dbo.Lessons", "levels_Id", "dbo.Levels");
            DropIndex("dbo.WeeklyScores", new[] { "levels_Id" });
            DropIndex("dbo.Lessons", new[] { "levels_Id" });
            DropIndex("dbo.Classes", new[] { "departments_Id" });
            DropColumn("dbo.WeeklyScores", "levels_Id");
            DropColumn("dbo.Lessons", "levels_Id");
            DropTable("dbo.Levels");
            CreateIndex("dbo.Classes", "Departments_Id");
        }
    }
}
