using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencyManagement.Model
{
    public class Position
    {
        public int Id { get; set; }
        [DisplayName("Position Name")]
        [Required]
        public string PositionName { get; set; }
    }
}
