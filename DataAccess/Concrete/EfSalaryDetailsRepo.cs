using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.Dtos.SalaryDetails;
using Entities.Concrete.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfSalaryDetailsRepo : EfRepoBase<SalaryDetails>, ISalaryDetailsRepo
    {
        private readonly SalaryDbContext _dbContext;
        public EfSalaryDetailsRepo(SalaryDbContext salaryDbContext) : base(salaryDbContext)
        {
            _dbContext = salaryDbContext;
        }

        public async Task<ServiceResponseDto> PostSalaryDetailsSP(AddSalaryDetailsDto dto)
        {
            try
            {
                _dbContext.Database.ExecuteSqlRaw("EXEC CreateSalaryDetails @p0, @p1, @p2, @p3",
                                                    dto.EmployeeId, dto.BaseSalary, dto.DailyWage, dto.HourlyWage, DateTime.Now, 0);

                return new ServiceResponseDto { IsSuccess = true, Message = "SalaryDetails Created Successfully" };
            }
            catch (Exception ex)
            {
                return new ServiceResponseDto { IsSuccess = false, Message = ex.Message };
                throw;
            }
        }
    }
}
