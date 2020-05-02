namespace CompetencyManagement.DataContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class D_Assignment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DSkillsAssignments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DepartmentId = c.Int(nullable: false),
                        DskillId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .ForeignKey("dbo.Dskills", t => t.DskillId, cascadeDelete: true)
                .Index(t => t.DepartmentId)
                .Index(t => t.DskillId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DSkillsAssignments", "DskillId", "dbo.Dskills");
            DropForeignKey("dbo.DSkillsAssignments", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.DSkillsAssignments", new[] { "DskillId" });
            DropIndex("dbo.DSkillsAssignments", new[] { "DepartmentId" });
            DropTable("dbo.DSkillsAssignments");
        }
    }
}
