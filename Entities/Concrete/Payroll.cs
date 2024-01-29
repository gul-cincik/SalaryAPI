using DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Payroll : EntityBase
    {
        [Key]
        public int Id { get; set; }

        public double BaseSalary { get; set; }
        public double DaysWorked { get; set; }
        public double HoursWorked { get; set; }
        public double TotalSalary { get; set; }

        public DateTime PayDate { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

    }


}
