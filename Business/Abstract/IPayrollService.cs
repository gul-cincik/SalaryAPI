using Entities.Concrete.Dtos.Employee;
using Entities.Concrete.Dtos.Payroll;
using Entities.Concrete.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPayrollService
    {
        Task<ServiceResponseDto> AddPayrollToEmployee(AddPayrollDto dto);
        Task<List<GetOvertimeSalaryRangeResDto>> GetOvertimeSalaryRange(OvertimeSalaryRangeDto dto);

    }
}
