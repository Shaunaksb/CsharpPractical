USE CollegeDB;
GO

IF OBJECT_ID('Products', 'U') IS NULL
BEGIN
    CREATE TABLE Products (
        ProductID INT PRIMARY KEY IDENTITY(1,1),
        ProductName VARCHAR(100) NOT NULL,
        Quantity INT DEFAULT 0,
        Price DECIMAL(10, 2)
    );
END