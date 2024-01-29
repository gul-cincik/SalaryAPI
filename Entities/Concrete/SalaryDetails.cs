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
    public class SalaryDetails : EntityBase
    {
        [Key]
        public int Id { get; set; }

        public double BaseSalary { get; set; }
        public double DailyWage { get; set; }
        public double HourlyWage { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

    }
}
