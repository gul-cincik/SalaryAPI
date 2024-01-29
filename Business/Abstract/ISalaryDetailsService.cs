using Entities.Concrete.Dtos.Employee;
using Entities.Concrete.Dtos.SalaryDetails;
using Entities.Concrete.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ISalaryDetailsService
    {
        Task<ServiceResponseDto> AddSalaryDetailsToEmployee(AddSalaryDetailsDto dto);
        Task<EmployeeSalaryDetailsResDto> GetSalaryDetailsByEmployee(GetEmployeeDto dto);
        Task<ServiceResponseDto> PostSalaryDetailsSP(AddSalaryDetailsDto dto);

    }
}
