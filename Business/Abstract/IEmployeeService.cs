using Entities.Concrete.Dtos.Employee;
using Entities.Concrete.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IEmployeeService
    {
        Task<ServiceResponseDto> AddEmployee(AddEmployeeDto dto);


    }
}
