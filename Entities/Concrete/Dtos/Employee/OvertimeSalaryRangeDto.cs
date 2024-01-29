using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos.Employee
{
    public class OvertimeSalaryRangeDto
    {
        public double MinBaseSalary { get; set; }
        public double MaxBaseSalary { get; set; }
        public double MinTotalSalary { get; set; }
        public double MaxTotalSalary { get; set; }
    }
}
