using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencyManagement.Model
{
    public class AllSkillViewModels
    {   //Departmentwise 
        public List<Department> Departments { get; set; }
        public List<DmCategory> DmCategories { get; set; }
        public List<DsCategory> DsCategories { get; set; }
        public List<Dskill> Dskills { get; set; }
        //Positionwise
        public List<Position> Positions { get; set; }
        public List <PmCategory> pmCategories { get; set; }
        public List<PsCategory> psCategories { get; set; }
        public List<Pskill> pskills { get; set; }

    }
}
