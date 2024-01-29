using Entities.Concrete;
using Entities.Concrete.Dtos.Employee;
using Entities.Concrete.Dtos.SalaryDetails;
using Entities.Concrete.Helpers;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IPayrollRepo : IEntityRepository<Payroll>
    {
        public Task<List<GetOvertimeSalaryRangeResDto>> GetOvertimeSalaryRange(OvertimeSalaryRangeDto dto);
    }
}
