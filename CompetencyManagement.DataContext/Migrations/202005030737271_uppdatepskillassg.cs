namespace CompetencyManagement.DataContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class uppdatepskillassg : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PSkillsAssignments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PositionId = c.Int(nullable: false),
                        PskillId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Positions", t => t.PositionId, cascadeDelete: true)
                .ForeignKey("dbo.Pskills", t => t.PskillId, cascadeDelete: true)
                .Index(t => t.PositionId)
                .Index(t => t.PskillId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PSkillsAssignments", "PskillId", "dbo.Pskills");
            DropForeignKey("dbo.PSkillsAssignments", "PositionId", "dbo.Positions");
            DropIndex("dbo.PSkillsAssignments", new[] { "PskillId" });
            DropIndex("dbo.PSkillsAssignments", new[] { "PositionId" });
            DropTable("dbo.PSkillsAssignments");
        }
    }
}
