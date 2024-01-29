using DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Employee : EntityBase
    {
        [Key]
        public int Id { get; set; }

        [StringLength(11, MinimumLength = 11, ErrorMessage = "Tc must be exactly 11 characters.")]
        public string Tc { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [ForeignKey("EmployeeType")]
        public int EmployeeTypeId { get; set; }
        public EmployeeType EmployeeType { get; set; }

        public virtual SalaryDetails SalaryDetails { get; set; }
        public ICollection<Payroll> Payrolls { get; set; }
    }
}
