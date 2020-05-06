namespace CompetencyManagement.DataContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class emupdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "EmployeeName", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "EmpoloyeeEmail", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "EmpoloyeeUserName", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "EmpoloyeePassword", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "EmpoloyeePassword", c => c.String());
            AlterColumn("dbo.Employees", "EmpoloyeeUserName", c => c.String());
            AlterColumn("dbo.Employees", "EmpoloyeeEmail", c => c.String());
            AlterColumn("dbo.Employees", "EmployeeName", c => c.String());
        }
    }
}
