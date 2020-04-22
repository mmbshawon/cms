using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencyManagement.Model
{
    public class PsCategory
    {
        public int Id { get; set; }
        [Display(Name = "Sub Category Name")]
        [Required]
        public string PsCategoryName { get; set; }
        public virtual PmCategory PmCategory { get; set; }
        public int PmCategoryId { get; set; }
    }
}
