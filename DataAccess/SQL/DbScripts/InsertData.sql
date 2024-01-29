---EmployeeTypes
SET IDENTITY_INSERT EmployeeTypes ON;
INSERT INTO EmployeeTypes (Id, Value, BaseSalary, Overtime, Daily, CreatedAt, IsDeleted)
VALUES
    (1, 1, 1, 0, 0, '2024-01-29T12:00:00', 0),
    (2, 2, 0, 0, 1, '2024-01-29T12:00:00', 0),
    (3, 3, 1, 1, 0, '2024-01-29T12:00:00', 0);

SET IDENTITY_INSERT EmployeeTypes OFF;

---Employees
SET IDENTITY_INSERT Employees ON;
INSERT INTO Employees (Id, Tc, FirstName, LastName, Email, EmployeeTypeId, CreatedAt, IsDeleted)
VALUES
    (1, '12345678901', 'Mehmet', 'Kara', 'mkara@gmail.com', 1, '2024-01-29T12:00:00', 0),
    (2, '98765432109', 'Ali', 'Şahin', 'asahin@gmail.com', 1, '2024-01-29T12:00:00', 0),

    (3, '55544433322', 'Ayşe', 'Demir', 'ademir@gmail.com', 2, '2024-01-29T12:00:00', 0),
	(4, '55478533322', 'Serkan ', 'Göde', 'sgode@gmail.com', 2, '2024-01-29T12:00:00', 0),

	(5, '25944433322', 'Gülce ', 'Sabaz', 'gsabaz@gmail.com', 3, '2024-01-29T12:00:00', 0),
	(6, '58542578322', 'Arif ', 'Sarı', 'asarı@gmail.com', 3, '2024-01-29T12:00:00', 0),
	(7, '55368433322', 'Nazlı ', 'Özbek', 'nozbek@gmail.com', 3, '2024-01-29T12:00:00', 0);

SET IDENTITY_INSERT Employees OFF;


---SalaryDetails
SET IDENTITY_INSERT SalaryDetails ON;
INSERT INTO SalaryDetails (Id, BaseSalary, DailyWage, HourlyWage, EmployeeId, CreatedAt, IsDeleted)
VALUES
    (1, 35000, 0, 0, 1, '2024-01-29T12:00:00', 0),
    (2, 27000, 0, 0, 2, '2024-01-29T12:00:00', 0),

    (3, 0, 500, 0, 3, '2024-01-29T12:00:00', 0),
	(4, 0, 1000, 0, 4, '2024-01-29T12:00:00', 0),

    (5, 25000, 0, 200, 5, '2024-01-29T12:00:00', 0),
    (6, 40000, 0, 400, 6, '2024-01-29T12:00:00', 0),
	(7, 30000, 0, 300, 7, '2024-01-29T12:00:00', 0);

SET IDENTITY_INSERT SalaryDetails OFF;

---Payrolls
SET IDENTITY_INSERT Payrolls ON;
INSERT INTO Payrolls (Id, BaseSalary, DaysWorked, HoursWorked, TotalSalary, PayDate, EmployeeId, CreatedAt, IsDeleted)
VALUES
    (1, 35000, 0, 0, 35000, '2024-01-29T12:00:00', 1, '2024-01-29T12:00:00', 0),
    (2, 27000, 0, 0, 27000, '2024-01-29T12:00:00', 2, '2024-01-29T12:00:00', 0),

    (3, 0, 20, 10000, 10000, '2024-01-29T12:00:00', 3, '2024-01-29T12:00:00', 0),
	(4, 0, 15, 15000, 15000, '2024-01-29T12:00:00', 4, '2024-01-29T12:00:00', 0),

    (5, 25000, 0, 10, 27000, '2024-01-29T12:00:00', 5, '2024-01-29T12:00:00', 0),
    (6, 40000, 0, 10, 44000, '2024-01-29T12:00:00', 6, '2024-01-29T12:00:00', 0),
	(7, 30000, 20, 20, 36000, '2024-01-29T12:00:00', 7, '2024-01-29T12:00:00', 0);

SET IDENTITY_INSERT Payrolls OFF;
