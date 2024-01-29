using Business.Abstract;
using Entities.Concrete.Dtos.Employee;
using Entities.Concrete.Dtos.Payroll;
using Entities.Concrete.Dtos.SalaryDetails;
using Entities.Concrete.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SalaryAPI.Controllers
{
    [Route("salary")]
    [ApiController]
    public class SalaryController : ControllerBase
    {
        IEmployeeTypeService _employeeTypeService;
        IEmployeeService _employeeService;
        ISalaryDetailsService _salaryDetailsService;
        IPayrollService _payrollService;

        public SalaryController(IEmployeeTypeService employeeTypeService, IEmployeeService employeeService, ISalaryDetailsService salaryDetailsService, IPayrollService payrollService)
        {
            _employeeTypeService = employeeTypeService;
            _employeeService = employeeService;
            _salaryDetailsService = salaryDetailsService;
            _payrollService = payrollService;
        }

        [HttpPost]
        [Route("AddSalaryDetailsToEmployee")]
        public async Task<IActionResult> AddSalaryDetailsToEmployee(AddSalaryDetailsDto requestBody)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("The request body is not suitable");
                }

                ServiceResponseDto response = await _salaryDetailsService.AddSalaryDetailsToEmployee(requestBody);

                if (response.IsSuccess)
                {
                    return Ok(response);
                }

                return BadRequest(response.Message);

                

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("AddPayrollToEmployee")]
        public async Task<IActionResult> AddPayrollToEmployee(AddPayrollDto requestBody)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("The request body is not suitable");
                }

                ServiceResponseDto response = await _payrollService.AddPayrollToEmployee(requestBody);

                if (response.IsSuccess)
                {
                    return Ok(response);
                }

                return BadRequest(response.Message);



            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("GetSalaryDetailsByEmployee")]
        public async Task<IActionResult> GetSalaryDetailsByEmployee(GetEmployeeDto requestBody)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("The request body is not suitable");
                }

                EmployeeSalaryDetailsResDto response = await _salaryDetailsService.GetSalaryDetailsByEmployee(requestBody);

                // Q: Obje nullable gelmiyor?
                if (response == null)
                {
                    return NotFound("No salary details found for the specified employee.");
                }

                return Ok(response);



            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("GetOvertimeSalaryRange")]
        public async Task<IActionResult> GetOvertimeSalaryRange(OvertimeSalaryRangeDto requestBody)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("The request body is not suitable");
                }

                List<GetOvertimeSalaryRangeResDto> responseList = await _payrollService.GetOvertimeSalaryRange(requestBody);

                
                if (responseList.Count == 0)
                {
                    return NotFound("No data found for the specified range.");
                }

                return Ok(responseList);



            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("PostSalaryDetails")]
        public async Task<IActionResult> PostSalaryDetailsSP(AddSalaryDetailsDto requestBody)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("The request body is not suitable");
                }

                ServiceResponseDto response = await _salaryDetailsService.PostSalaryDetailsSP(requestBody);


                if (response.IsSuccess)
                {
                    return Ok("Salary Details created successfully.");
                }

                return BadRequest(response.Message);



            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
