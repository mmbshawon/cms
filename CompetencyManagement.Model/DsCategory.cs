using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencyManagement.Model
{
    public class DsCategory
    {
        public int Id { get; set; }
        [Display(Name = "Sub Category Name")]
        [Required]
        public string DsCategoryName { get; set; }
        public virtual DmCategory DmCategory { get; set; }
        public int DmCategoryId { get; set; }
    }
}
