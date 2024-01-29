using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class SpGetFilteredTypeThreePayrolls : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE GetFilteredTypeThreePayrollsSP
                        @MinBaseSalary DECIMAL(18, 2),
                        @MaxBaseSalary DECIMAL(18, 2),
                        @MinTotalSalary DECIMAL(18, 2),
                        @MaxTotalSalary DECIMAL(18, 2)
                    AS
                    BEGIN
                        SELECT 
                            e.FirstName,
                            e.LastName,
                            e.Email,
                            et.Value AS Type,
                            p.BaseSalary,
                            p.HoursWorked,
                            sd.HourlyWage,
                            p.TotalSalary,
                            p.PayDate
                        FROM 
                            Payrolls p
                        INNER JOIN 
                            Employees e ON e.Id = p.EmployeeId
                        INNER JOIN 
                            EmployeeTypes et ON et.Id = e.EmployeeTypeId
                        INNER JOIN 
                            SalaryDetails sd ON sd.EmployeeId = p.EmployeeId
                        WHERE 
                            et.Value = 3 
                            AND et.BaseSalary = 1 
                            AND et.Overtime = 1
                            AND p.IsDeleted = 0 
                            AND e.IsDeleted = 0 
                            AND et.IsDeleted = 0 
                            AND sd.IsDeleted = 0
                            AND p.BaseSalary BETWEEN @MinBaseSalary AND @MaxBaseSalary
                            AND p.TotalSalary BETWEEN @MinTotalSalary AND @MaxTotalSalary;
                    END;";

            migrationBuilder.Sql(sp);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
