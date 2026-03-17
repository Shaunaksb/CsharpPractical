USE CollegeDB;
GO

CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    Username VARCHAR(50) UNIQUE NOT NULL,
    Password VARCHAR(50) NOT NULL -- In a real app, use Hashed Passwords!
);

INSERT INTO Users (Username, Password) VALUES ('admin', 'password123');