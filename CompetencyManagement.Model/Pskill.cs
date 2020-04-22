using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencyManagement.Model
{
    public class Pskill
    {
        public int Id { get; set; }
        [Display(Name = "Position Skill Name")]
        [Required]
        public string PskillName { get; set; }
        public virtual PsCategory PsCategory { get; set; }
        public int PsCategoryId { get; set; }
    }
}
