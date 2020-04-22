using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencyManagement.Model
{
    public class PmCategory
    {
        public int Id { get; set; }
        [Display(Name = "Main Category Name")]
        [Required]
        public string PmCategoryName { get; set; }
    }
}
