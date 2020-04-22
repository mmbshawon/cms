namespace CompetencyManagement.DataContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class position : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DeptSkillSubCategories", "DeptSkillMainCategory_Id", "dbo.DeptSkillMainCategories");
            DropForeignKey("dbo.DeptSkills", "DeptSkillSubCategoryId", "dbo.DeptSkillSubCategories");
            DropForeignKey("dbo.DeptWiseSkillAssignments", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.DeptWiseSkillAssignments", "DskillId", "dbo.Dskills");
            DropIndex("dbo.DeptSkills", new[] { "DeptSkillSubCategoryId" });
            DropIndex("dbo.DeptSkillSubCategories", new[] { "DeptSkillMainCategory_Id" });
            DropIndex("dbo.DeptWiseSkillAssignments", new[] { "DepartmentId" });
            DropIndex("dbo.DeptWiseSkillAssignments", new[] { "DskillId" });
            CreateTable(
                "dbo.PmCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PmCategoryName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PositionName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PsCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PsCategoryName = c.String(nullable: false),
                        PmCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PmCategories", t => t.PmCategoryId, cascadeDelete: true)
                .Index(t => t.PmCategoryId);
            
            CreateTable(
                "dbo.Pskills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PskillName = c.String(nullable: false),
                        PsCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PsCategories", t => t.PsCategoryId, cascadeDelete: true)
                .Index(t => t.PsCategoryId);
            
            DropTable("dbo.DeptSkillMainCategories");
            DropTable("dbo.DeptSkills");
            DropTable("dbo.DeptSkillSubCategories");
            DropTable("dbo.DeptWiseSkillAssignments");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.DeptWiseSkillAssignments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DepartmentId = c.Int(nullable: false),
                        DskillId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DeptSkillSubCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DeptSkillSubCategoryName = c.String(),
                        DeptSkillMainCatagoryId = c.Int(nullable: false),
                        DeptSkillMainCategory_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DeptSkills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DeptSkillName = c.Int(nullable: false),
                        DeptSkillSubCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DeptSkillMainCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DeptSkillMainCategoryName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Pskills", "PsCategoryId", "dbo.PsCategories");
            DropForeignKey("dbo.PsCategories", "PmCategoryId", "dbo.PmCategories");
            DropIndex("dbo.Pskills", new[] { "PsCategoryId" });
            DropIndex("dbo.PsCategories", new[] { "PmCategoryId" });
            DropTable("dbo.Pskills");
            DropTable("dbo.PsCategories");
            DropTable("dbo.Positions");
            DropTable("dbo.PmCategories");
            CreateIndex("dbo.DeptWiseSkillAssignments", "DskillId");
            CreateIndex("dbo.DeptWiseSkillAssignments", "DepartmentId");
            CreateIndex("dbo.DeptSkillSubCategories", "DeptSkillMainCategory_Id");
            CreateIndex("dbo.DeptSkills", "DeptSkillSubCategoryId");
            AddForeignKey("dbo.DeptWiseSkillAssignments", "DskillId", "dbo.Dskills", "Id", cascadeDelete: true);
            AddForeignKey("dbo.DeptWiseSkillAssignments", "DepartmentId", "dbo.Departments", "Id", cascadeDelete: true);
            AddForeignKey("dbo.DeptSkills", "DeptSkillSubCategoryId", "dbo.DeptSkillSubCategories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.DeptSkillSubCategories", "DeptSkillMainCategory_Id", "dbo.DeptSkillMainCategories", "Id");
        }
    }
}
