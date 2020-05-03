using CompetencyManagement.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencyManagement.DataContext
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
          : base("name=DatabaseContext")
        {

        }
        //Department DB
        public DbSet<Department> departments { get; set; }
        public DbSet<DmCategory> dmCategories { get; set; }
        public DbSet<DsCategory> dsCategories { get; set; }
        public DbSet<Dskill> dskills { get; set; }
        public DbSet<DSkillsAssignment> dSkillsAssignments { get; set; }
        //Position DB
        public DbSet<Position> positions { get; set; }
        public DbSet<PmCategory> pmCategories { get; set; }
        public DbSet<PsCategory> psCategories { get; set; }
        public DbSet<Pskill> pskills { get; set; }
        public DbSet<PSkillsAssignment> pSkillsAssignments { get; set; }

    }
}
