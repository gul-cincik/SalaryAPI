using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos.SalaryDetails
{
    public class AddSalaryDetailsDto : IDto
    {
        public double BaseSalary { get; set; }
        public double DailyWage { get; set; }
        public double HourlyWage { get; set; }
        public int EmployeeId { get; set; }
    }
}
