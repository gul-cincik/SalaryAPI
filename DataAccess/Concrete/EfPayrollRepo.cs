using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.Dtos.Employee;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Entities.Concrete.Helpers;
using Entities.Concrete.Dtos.SalaryDetails;

namespace DataAccess.Concrete
{
    public class EfPayrollRepo : EfRepoBase<Payroll>, IPayrollRepo
    {
        private readonly SalaryDbContext _dbContext;

        public EfPayrollRepo(SalaryDbContext salaryDbContext) : base(salaryDbContext)
        {
            _dbContext = salaryDbContext;
        }
        // Gives error. An example of how to execute stored procedure.
        public async Task<List<GetOvertimeSalaryRangeResDto>> GetOvertimeSalaryRange(OvertimeSalaryRangeDto dto)
        {
            try
            {
                using (var db = new SalaryDbContext())
                {
                    List<SqlParameter> sqlParms = new List<SqlParameter>
                    {
                        new SqlParameter { ParameterName = "@MinBaseSalary", Value = dto.MinBaseSalary },
                        new SqlParameter { ParameterName = "@MaxBaseSalary ", Value = dto.MaxBaseSalary },
                        new SqlParameter { ParameterName = "@MinTotalSalary", Value = dto.MinTotalSalary},
                        new SqlParameter { ParameterName = "@MaxTotalSalary", Value = dto.MaxTotalSalary }
                    };

                    var qlist = _dbContext.Set<GetOvertimeSalaryRangeResDto>()
                                        .FromSqlRaw("EXEC dbo.GetFilteredTypeThreePayrollsSPT @MinBaseSalary, @MaxBaseSalary, @MinTotalSalary, @MaxTotalSalary",
                                            sqlParms.ToArray()
                                        ).ToList();

                    return new List<GetOvertimeSalaryRangeResDto>();
                }
            }
            catch (Exception ex)
            {
                return new List<GetOvertimeSalaryRangeResDto>();
                throw;
            }
        }

    }
}
