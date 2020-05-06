using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencyManagement.Model
{
    public class Employee
    {
        public int Id { get; set; }
        [DisplayName("Employee Name")]
        [Required]
        public string EmployeeName { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Joining Date")]
        [Required]
        public DateTime EmpoloyeeJoiningDate { get; set; }
        public int EmployeeStatusId { get; set; }
        public virtual EmployeeStatus EmployeeStatus { get; set; }
        [DisplayName("Empoloyee Email")]
        [Required]
        public string EmpoloyeeEmail { get; set; }
        [DisplayName("User Name")]
        [Required]
        public string EmpoloyeeUserName { get; set; }
        [DisplayName("Password")]
        [Required]
        public string EmpoloyeePassword { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public int PositionId { get; set; }
        public virtual Position Position { get; set; }
    }
}
