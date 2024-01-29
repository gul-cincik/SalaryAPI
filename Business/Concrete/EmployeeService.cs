using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using Entities.Concrete.Dtos.Employee;
using Entities.Concrete.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepo _employeeRepo;
        private readonly IEmployeeTypeRepo _employeeTypeRepo;

        public EmployeeService(IEmployeeRepo employeeRepo, IEmployeeTypeRepo employeeTypeRepo)
        {
            _employeeRepo = employeeRepo;
            _employeeTypeRepo = employeeTypeRepo;
        }

        public async Task<ServiceResponseDto> AddEmployee(AddEmployeeDto dto)
        {
            try
            {
                Employee employee = new Employee();

                // Check if Employee Type exists.
                EmployeeType employeeType = await _employeeTypeRepo.GetAsync(e => e.Id == dto.EmployeeTypeId);

                if (employeeType == null)
                {
                    return new ServiceResponseDto { IsSuccess = false, Message = "This Employee Type does not exist in your system." };
                }

                // TODO Employee Tc shoudd be encrypted data. 
                employee.Tc = dto.Tc;
                employee.FirstName = dto.FirstName;
                employee.LastName = dto.LastName;
                employee.Email = dto.Email;
                employee.IsDeleted = false;
                employee.EmployeeTypeId = dto.EmployeeTypeId;

                await _employeeRepo.AddAsync(employee);

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
