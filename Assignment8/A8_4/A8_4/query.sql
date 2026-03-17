USE CollegeDB;
GO

-- Create the table if it doesn't exist
IF OBJECT_ID('Employee', 'U') IS NULL
BEGIN
    CREATE TABLE Employee (
        EmpID INT PRIMARY KEY,
        Name VARCHAR(100),
        Salary DECIMAL(18, 2)
    );
END