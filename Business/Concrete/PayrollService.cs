using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete.Helpers;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete.Dtos.Payroll;
using Entities.Concrete.Dtos.Employee;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Business.Concrete
{
    public class PayrollService : IPayrollService
    {
        private readonly IPayrollRepo _payrollRepo;
        private readonly IEmployeeRepo _employeeRepo;
        private IEmployeeTypeRepo _employeeTypeRepo;
        private ISalaryDetailsRepo _salaryDetailsRepo;
        private readonly SalaryDbContext _dbContext;

        public PayrollService(IPayrollRepo payrollRepo, IEmployeeRepo employeeRepo, IEmployeeTypeRepo employeeTypeRepo, ISalaryDetailsRepo salaryDetailsRepo, SalaryDbContext dbContext)
        {
            _payrollRepo = payrollRepo;
            _employeeRepo = employeeRepo;
            _employeeTypeRepo = employeeTypeRepo;
            _salaryDetailsRepo = salaryDetailsRepo;
            _dbContext = dbContext;
        }
        // Algorithm's AddPayrollToEmployee stored procedure exists.
        public async Task<ServiceResponseDto> AddPayrollToEmployee(AddPayrollDto dto)
        {
            try
            {

                // Check if Employee exists
                Employee existedEmployee = await _employeeRepo.GetAsync(e => e.Id == dto.EmployeeId);

                if (existedEmployee == null)
                {
                    return new ServiceResponseDto { IsSuccess = false, Message = "The Employee does not exist." };
                }

                // Get Employee type
                EmployeeType employeeType = await _employeeTypeRepo.GetAsync(et => et.Id == existedEmployee.EmployeeTypeId);

                if(employeeType == null)
                {
                    return new ServiceResponseDto { IsSuccess = false, Message = "The Employee Type does not exist." };

                }

                // Get Salary Details of employee
                SalaryDetails salaryDetails = await _salaryDetailsRepo.GetAsync(sd => sd.EmployeeId  == dto.EmployeeId);

                if (salaryDetails == null)
                {
                    return new ServiceResponseDto { IsSuccess = false, Message = "Check your Employee's salary details." };
                }

                Payroll payroll = new Payroll();

                payroll.EmployeeId = existedEmployee.Id;
                payroll.BaseSalary = 0;
                payroll.DaysWorked = 0;
                payroll.HoursWorked = 0;
                payroll.PayDate = dto.PayDate;
                payroll.IsDeleted = false;


                // If Employee has a base salary
                if (employeeType.BaseSalary)
                {
                    payroll.BaseSalary = salaryDetails.BaseSalary;

                    payroll.TotalSalary = salaryDetails.BaseSalary;

                    // If Employee has Overtime Shift 
                    if (employeeType.Overtime)
                    {
                        payroll.HoursWorked = dto.HoursWorked;

                        payroll.TotalSalary = dto.HoursWorked * salaryDetails.HourlyWage + salaryDetails.BaseSalary;

                    }

                }
                // If the Employee is daily worker
                else if (employeeType.Daily)
                {
                    payroll.DaysWorked = dto.DaysWorked;

                    payroll.TotalSalary = dto.DaysWorked * salaryDetails.DailyWage;
                }
                else
                {
                    return new ServiceResponseDto { IsSuccess = false, Message = "Check your Employee working type." };
                }

                await _payrollRepo.AddAsync(payroll);

                return new ServiceResponseDto { IsSuccess = true };
            }
            catch (Exception ex)
            {
                return new ServiceResponseDto { IsSuccess = false, Message = ex.Message };
                throw;
            }
        }

        public async Task<List<GetOvertimeSalaryRangeResDto>> GetOvertimeSalaryRange(OvertimeSalaryRangeDto dto)
        {
            try
            {

                List<GetOvertimeSalaryRangeResDto>  result = await _payrollRepo.GetOvertimeSalaryRange(dto);
                return result;
            }
            catch (Exception ex)
            {
                return new List<GetOvertimeSalaryRangeResDto>();
                throw;
            }
        }
    }
}
