namespace CompetencyManagement.DataContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(nullable: false),
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
            
            CreateTable(
                "dbo.DeptSkills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DeptSkillName = c.Int(nullable: false),
                        DeptSkillSubCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DeptSkillSubCategories", t => t.DeptSkillSubCategoryId, cascadeDelete: true)
                .Index(t => t.DeptSkillSubCategoryId);
            
            CreateTable(
                "dbo.DeptSkillSubCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DeptSkillSubCategoryName = c.String(),
                        DeptSkillMainCatagoryId = c.Int(nullable: false),
                        DeptSkillMainCategory_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DeptSkillMainCategories", t => t.DeptSkillMainCategory_Id)
                .Index(t => t.DeptSkillMainCategory_Id);
            
            CreateTable(
                "dbo.DeptWiseSkillAssignments",
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
            
            CreateTable(
                "dbo.Dskills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DskillName = c.String(nullable: false),
                        DsCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DsCategories", t => t.DsCategoryId, cascadeDelete: true)
                .Index(t => t.DsCategoryId);
            
            CreateTable(
                "dbo.DsCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DsCategoryName = c.String(nullable: false),
                        DmCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DmCategories", t => t.DmCategoryId, cascadeDelete: true)
                .Index(t => t.DmCategoryId);
            
            CreateTable(
                "dbo.DmCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DmCategoryName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DeptWiseSkillAssignments", "DskillId", "dbo.Dskills");
            DropForeignKey("dbo.Dskills", "DsCategoryId", "dbo.DsCategories");
            DropForeignKey("dbo.DsCategories", "DmCategoryId", "dbo.DmCategories");
            DropForeignKey("dbo.DeptWiseSkillAssignments", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.DeptSkills", "DeptSkillSubCategoryId", "dbo.DeptSkillSubCategories");
            DropForeignKey("dbo.DeptSkillSubCategories", "DeptSkillMainCategory_Id", "dbo.DeptSkillMainCategories");
            DropIndex("dbo.DsCategories", new[] { "DmCategoryId" });
            DropIndex("dbo.Dskills", new[] { "DsCategoryId" });
            DropIndex("dbo.DeptWiseSkillAssignments", new[] { "DskillId" });
            DropIndex("dbo.DeptWiseSkillAssignments", new[] { "DepartmentId" });
            DropIndex("dbo.DeptSkillSubCategories", new[] { "DeptSkillMainCategory_Id" });
            DropIndex("dbo.DeptSkills", new[] { "DeptSkillSubCategoryId" });
            DropTable("dbo.DmCategories");
            DropTable("dbo.DsCategories");
            DropTable("dbo.Dskills");
            DropTable("dbo.DeptWiseSkillAssignments");
            DropTable("dbo.DeptSkillSubCategories");
            DropTable("dbo.DeptSkills");
            DropTable("dbo.DeptSkillMainCategories");
            DropTable("dbo.Departments");
        }
    }
}
