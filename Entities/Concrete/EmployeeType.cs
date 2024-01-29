using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EmployeeType : EntityBase
    {
        [Key]
        public int Id { get; set; }
        public int Value { get; set; }

        //Does employee type has base salary?
        public bool BaseSalary { get; set; }

        //Does employee type has Overtime
        public bool Overtime { get; set; }

        // Is employe type daily employee?
        public bool Daily { get; set; }

        public ICollection<Employee> Employee { get; set; }
    }
}
