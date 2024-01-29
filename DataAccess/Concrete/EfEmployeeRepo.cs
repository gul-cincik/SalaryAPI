using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfEmployeeRepo : EfRepoBase<Employee>, IEmployeeRepo
    {
        public EfEmployeeRepo(SalaryDbContext salaryDbContext) : base(salaryDbContext)
        {
        }
    }
}
