CREATE PROCEDURE AddPayrollToEmployee
    @EmployeeId INT,
    @PayDate DATETIME,
    @DaysWorked FLOAT,
    @HoursWorked FLOAT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @BaseSalary FLOAT;
    DECLARE @DailyWage FLOAT;
    DECLARE @HourlyWage FLOAT;
    DECLARE @BaseSalaryFlag BIT;
    DECLARE @OvertimeFlag BIT;
    DECLARE @DailyFlag BIT;

    -- Get Employee Type and Salary Details
    SELECT 
        @BaseSalary = ISNULL(sd.BaseSalary, 0),
        @DailyWage = ISNULL(sd.DailyWage, 0),
        @HourlyWage = ISNULL(sd.HourlyWage, 0),
        @BaseSalaryFlag = ISNULL(et.BaseSalary, 0),
        @OvertimeFlag = ISNULL(et.Overtime, 0),
        @DailyFlag = ISNULL(et.Daily, 0)
    FROM Employees e
    LEFT JOIN SalaryDetails sd ON e.Id = sd.EmployeeId
    LEFT JOIN EmployeeTypes et ON e.EmployeeTypeId = et.Id
    WHERE e.Id = @EmployeeId;

    -- Check if Employee exists
    IF @BaseSalary IS NULL
    BEGIN
        PRINT 'The Employee does not exist.';
        RETURN;
    END

    -- Create Payroll record
    DECLARE @PayrollId INT;

    INSERT INTO Payrolls (BaseSalary, DaysWorked, HoursWorked, TotalSalary, PayDate, EmployeeId, CreatedAt, IsDeleted)
    VALUES
        (0, 0, 0, 0, @PayDate, @EmployeeId, GETDATE(), 0);

    SET @PayrollId = SCOPE_IDENTITY();

    -- Calculate Payroll based on Employee Type
    UPDATE Payrolls
    SET
        BaseSalary = CASE 
                        WHEN @BaseSalaryFlag = 1 THEN @BaseSalary
                        ELSE 0
                    END,
        DaysWorked = CASE 
                        WHEN @DailyFlag = 1 THEN @DaysWorked
                        ELSE 0
                    END,
        HoursWorked = CASE 
                        WHEN @OvertimeFlag = 1 THEN @HoursWorked
                        ELSE 0
                    END,
        TotalSalary = CASE 
                        WHEN @BaseSalaryFlag = 1 AND @OvertimeFlag = 1 THEN @HoursWorked * @HourlyWage + @BaseSalary
                        WHEN @BaseSalaryFlag = 1 AND @OvertimeFlag = 0 THEN @BaseSalary
                        WHEN @DailyFlag = 1 THEN @DaysWorked * @DailyWage
                        ELSE 0
                    END
    WHERE Id = @PayrollId;

    PRINT 'Payroll record added successfully.';
END;


