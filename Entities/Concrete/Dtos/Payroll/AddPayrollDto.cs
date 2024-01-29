using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos.Payroll
{
    public class AddPayrollDto
    {
        public double DaysWorked { get; set; }
        public double HoursWorked { get; set; }
        public double TotalSalary { get; set; }

        public DateTime PayDate { get; set; }

        public int EmployeeId { get; set; }
    }
}
