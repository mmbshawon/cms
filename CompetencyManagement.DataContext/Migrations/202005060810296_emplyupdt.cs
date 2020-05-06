namespace CompetencyManagement.DataContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class emplyupdt : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeName = c.String(),
                        EmpoloyeeJoiningDate = c.DateTime(nullable: false),
                        EmployeeStatusId = c.Int(nullable: false),
                        EmpoloyeeEmail = c.String(),
                        EmpoloyeeUserName = c.String(),
                        EmpoloyeePassword = c.String(),
                        DepartmentId = c.Int(nullable: false),
                        PositionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .ForeignKey("dbo.EmployeeStatus", t => t.EmployeeStatusId, cascadeDelete: true)
                .ForeignKey("dbo.Positions", t => t.PositionId, cascadeDelete: true)
                .Index(t => t.EmployeeStatusId)
                .Index(t => t.DepartmentId)
                .Index(t => t.PositionId);
            
            CreateTable(
                "dbo.EmployeeStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StatusName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "PositionId", "dbo.Positions");
            DropForeignKey("dbo.Employees", "EmployeeStatusId", "dbo.EmployeeStatus");
            DropForeignKey("dbo.Employees", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Employees", new[] { "PositionId" });
            DropIndex("dbo.Employees", new[] { "DepartmentId" });
            DropIndex("dbo.Employees", new[] { "EmployeeStatusId" });
            DropTable("dbo.EmployeeStatus");
            DropTable("dbo.Employees");
        }
    }
}
