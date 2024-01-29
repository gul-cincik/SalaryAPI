using Business.Abstract;
using Entities.Concrete.Dtos.Employee;
using Entities.Concrete.Dtos.EmployeeType;
using Entities.Concrete.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SalaryAPI.Controllers
{
    [Route("employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        IEmployeeTypeService _employeeTypeService;
        IEmployeeService _employeeService;

        public EmployeeController(IEmployeeTypeService employeeTypeService, IEmployeeService employeeService)
        {
            _employeeTypeService = employeeTypeService;
            _employeeService = employeeService;
        }

        [HttpPost]
        [Route("AddEmployeeType")]
        public async Task<IActionResult> AddEmployeeType(AddEmployeeTypeDto requestBody)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("The request body is not suitable");
                }

                ServiceResponseDto response = await _employeeTypeService.AddEmployeeType(requestBody);

                if (response.IsSuccess)
                {
                    return Ok("Employee is created successfully");
                }


                return BadRequest(response.Message);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("AddEmployee")]
        public async Task<IActionResult> AddEmployee(AddEmployeeDto requestBody)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("The request body is not suitable");
                }

                if (requestBody.Tc.Length != 11)
                {
                    return BadRequest("Tc must be exactly 11 characters.");
                }
                    ServiceResponseDto response = await _employeeService.AddEmployee(requestBody);

                if (response.IsSuccess)
                {
                    return Ok("Employee Type is created successfully");
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
