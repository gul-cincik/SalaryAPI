using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos.Employee
{
    public class EmployeeSalaryDetailsResDto
    {
        
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public double BaseSalary { get; set; }
            public double HourlyWage { get; set; }
            public double DailyWage { get; set; }
        
    }
}
