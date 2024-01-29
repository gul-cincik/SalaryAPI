CREATE PROCEDURE CreateSalaryDetails
    @EmployeeId INT,
    @BaseSalary FLOAT,
    @DailyWage FLOAT,
    @HourlyWage FLOAT
AS
BEGIN
    SET NOCOUNT ON;


    -- Insert into SalaryDetails table
    INSERT INTO SalaryDetails (EmployeeId, BaseSalary, DailyWage, HourlyWage, CreatedAt, IsDeleted)
    VALUES (@EmployeeId, @BaseSalary, @DailyWage, @HourlyWage, GETDATE(), 0);
END;