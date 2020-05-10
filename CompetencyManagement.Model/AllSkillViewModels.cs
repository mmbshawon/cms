using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencyManagement.Model
{
    public class AllSkillViewModels
    {
        public List<DmCategory> DmCategories { get; set; }
        public List<DsCategory> DsCategories { get; set; }
        public List<Dskill> Dskills { get; set; }
    }
}
