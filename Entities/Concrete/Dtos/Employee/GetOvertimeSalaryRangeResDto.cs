using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos.Employee
{
    public class GetOvertimeSalaryRangeResDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Type { get; set; }
        public double BaseSalary { get; set; }
        public int HoursWorked { get; set; }
        public double HourlyWage { get; set; }
        public double TotalSalary { get; set; }
        public DateTime PayDate { get; set; }

    }
}
