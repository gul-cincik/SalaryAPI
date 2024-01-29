using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using Entities.Concrete.Dtos.Employee;
using Entities.Concrete.Dtos.SalaryDetails;
using Entities.Concrete.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class SalaryDetailsService : ISalaryDetailsService
    {
        private readonly ISalaryDetailsRepo _salaryDetailsRepo;
        private readonly IEmployeeRepo _employeeRepo;
        private readonly IEmployeeTypeRepo _employeeTypeRepo;
        private readonly IPayrollRepo _payrollRepo;

        public SalaryDetailsService(ISalaryDetailsRepo salaryDetailsRepo, IEmployeeRepo employeeRepo, IEmployeeTypeRepo employeeTypeRepo, IPayrollRepo payrollRepo)
        {
            _salaryDetailsRepo = salaryDetailsRepo;
            _employeeRepo = employeeRepo;
            _employeeTypeRepo = employeeTypeRepo;
            _payrollRepo = payrollRepo;
        }

        public async Task<ServiceResponseDto> AddSalaryDetailsToEmployee(AddSalaryDetailsDto dto)
        {
            try
            {

                // Check if Employee exists
                Employee existedEmployee = await _employeeRepo.GetAsync(e => e.Id == dto.EmployeeId);

                if (existedEmployee == null)
                {
                    return new ServiceResponseDto { IsSuccess = false, Message = "The Employee does not exist." };
                }

                SalaryDetails salaryDetails = new SalaryDetails();

                // Get Employee type
                EmployeeType employeeType = await _employeeTypeRepo.GetAsync(et => et.Id == existedEmployee.EmployeeTypeId);

                if (employeeType == null)
                {
                    return new ServiceResponseDto { IsSuccess = false, Message = "The Employee Type does not exist." };

                }

                salaryDetails.EmployeeId = existedEmployee.Id;
                salaryDetails.BaseSalary = 0;
                salaryDetails.DailyWage = 0;
                salaryDetails.HourlyWage = 0;
                salaryDetails.IsDeleted = false;


                // If Employee has a base salary
                if (employeeType.BaseSalary)
                {
                    salaryDetails.BaseSalary = dto.BaseSalary;

                    // If Employee has Overtime Shift 
                    if(employeeType.Overtime)
                    {
                        salaryDetails.HourlyWage = dto.HourlyWage;
                    }
                    
                }
                // If the Employee is daily worker
                else if (employeeType.Daily)
                {
                    salaryDetails.DailyWage = dto.DailyWage;
                }
                else
                {
                    return new ServiceResponseDto { IsSuccess = false, Message = "Check your Employee working type." };
                }

                

                await _salaryDetailsRepo.AddAsync(salaryDetails);

                return new ServiceResponseDto { IsSuccess = true };
            }
            catch (Exception ex)
            {
                return new ServiceResponseDto { IsSuccess = false, Message = ex.Message };
                throw;
            }
        }
        public async Task<EmployeeSalaryDetailsResDto> GetSalaryDetailsByEmployee(GetEmployeeDto dto)
        {
            try
            {
                var employees = await _employeeRepo.GetAllAsync();  // Assuming GetAllAsync is an asynchronous method

                var query = (from e in employees
                            join sd in (await _salaryDetailsRepo.GetAllAsync()) on e.Id equals sd.EmployeeId
                            where e.Id == dto.EmployeeId && e.IsDeleted == false && sd.IsDeleted == false
                            select new EmployeeSalaryDetailsResDto
                            {
                                FirstName = e.FirstName,
                                LastName = e.LastName,
                                BaseSalary = sd.BaseSalary,
                                HourlyWage = sd.HourlyWage,
                                DailyWage = sd.DailyWage
                            })
                            .ToList().
                            FirstOrDefault();

                if (query == null)
                {
                    return new EmployeeSalaryDetailsResDto();
                }

                return query;

                // Return data with a 200 status code and a message
            }
            catch (Exception ex)
            {
                return new EmployeeSalaryDetailsResDto();

            }
        }

        public async Task<ServiceResponseDto> PostSalaryDetailsSP(AddSalaryDetailsDto dto)
        {
            try
            {

                ServiceResponseDto result = await _salaryDetailsRepo.PostSalaryDetailsSP(dto);

                return result;
            }
            catch (Exception ex)
            {
                return new ServiceResponseDto { IsSuccess = false, Message = ex.Message };
                throw;
            }
        }
    }
}
