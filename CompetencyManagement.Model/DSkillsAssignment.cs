using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencyManagement.Model
{
    public class DSkillsAssignment
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public  virtual Department Department { get; set; }
        public int DskillId { get; set; }
        public virtual Dskill Dskill { get; set; }
    }
}
