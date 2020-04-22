using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencyManagement.Model
{
    public class Dskill
    {
        public int Id { get; set; }
        [Display(Name = "Department Skill Name")]
        [Required]
        public string DskillName { get; set; }
        public virtual DsCategory DsCategory { get; set; }
        public int DsCategoryId { get; set; }
    }
}
