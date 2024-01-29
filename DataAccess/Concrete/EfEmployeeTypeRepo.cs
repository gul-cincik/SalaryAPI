using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfEmployeeTypeRepo : EfRepoBase<EmployeeType>, IEmployeeTypeRepo
    {
        public EfEmployeeTypeRepo(SalaryDbContext salaryDbContext) : base(salaryDbContext)
        {
        }
    }

}
