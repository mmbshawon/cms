using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencyManagement.Model
{
    public class Department
    {
        public int Id { get; set; }
        [DisplayName("Department Name")]
        [Required]
        public string DepartmentName { get; set; }
    }
}
