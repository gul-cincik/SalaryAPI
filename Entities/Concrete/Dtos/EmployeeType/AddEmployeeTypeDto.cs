using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos.EmployeeType
{
    public class AddEmployeeTypeDto : IDto
    {
        public int Value { get; set; }

        //Does employee type has base salary?
        public bool BaseSalary { get; set; }

        //Does employee type has Overtime
        public bool Overtime { get; set; }

        // Is employe type daily employee?
        public bool Daily { get; set; }
    }
}
