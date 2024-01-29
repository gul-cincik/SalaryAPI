using Entities.Concrete.Dtos.EmployeeType;
using Entities.Concrete.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IEmployeeTypeService
    {
        Task<ServiceResponseDto> AddEmployeeType(AddEmployeeTypeDto dto);
    }
}
