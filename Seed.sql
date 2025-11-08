--Departments
INSERT INTO Departments (Name) VALUES
('Human Resources'),
('Finance'),
('Engineering'),
('Marketing'),
('Sales');

--Employees
INSERT INTO Employees (DepartmentId, Name, DateOfJoin, Salary, YearsOfExperience, IsDeleted)
VALUES
(1, 'Alice Johnson', '2022-04-10', 52000, 3, 0),
(1, 'Mark Evans', '2023-03-12', 48000, 2, 0),
(2, 'John Smith', '2021-08-18', 65000, 5, 0),
(2, 'Sarah Davis', '2024-01-15', 55000, 3, 0),
(3, 'David Wilson', '2020-09-01', 87000, 7, 0),
(3, 'Priya Sharma', '2024-02-05', 72000, 4, 0),
(4, 'Emily Brown', '2022-11-25', 61000, 4, 0),
(5, 'Michael Adams', '2023-06-30', 58000, 3, 0);
