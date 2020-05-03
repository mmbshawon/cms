using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencyManagement.Model
{
    public class PSkillsAssignment
    {
        public int Id { get; set; }
        public int PositionId { get; set; }
        public virtual Position Position { get; set; }
        public int PskillId { get; set; }
        public virtual Pskill Pskill { get; set; }
    }
}
