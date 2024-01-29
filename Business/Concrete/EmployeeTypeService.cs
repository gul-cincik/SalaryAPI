using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete.Dtos.EmployeeType;
using Entities.Concrete.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class EmployeeTypeService : IEmployeeTypeService
    {
        private readonly IEmployeeTypeRepo _employeeTypeRepo;

        public EmployeeTypeService(IEmployeeTypeRepo employeeTypeRepo)
        {
            _employeeTypeRepo = employeeTypeRepo;
        }

        public async Task<ServiceResponseDto> AddEmployeeType(AddEmployeeTypeDto dto)
        {
            try
            {
                EmployeeType employeeType = new EmployeeType();

                employeeType.Value = dto.Value;
                employeeType.BaseSalary = dto.BaseSalary;
                employeeType.Daily = dto.Daily;
                employeeType.Overtime = dto.Overtime;
                employeeType.IsDeleted = false;

                await _employeeTypeRepo.AddAsync(employeeType);

                return new ServiceResponseDto { IsSuccess = true };
            }
            catch (Exception ex)
            {
                return new ServiceResponseDto { IsSuccess = false, Message = ex.Message }; ;
                throw;
            }
        }
    }
}
