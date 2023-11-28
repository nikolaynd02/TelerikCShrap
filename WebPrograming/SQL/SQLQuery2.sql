-- If you don't have the Corporation database, 
--    use the Corporation.sql script to create it first.
-- Then complete the tasks below. Good luck!
-----------------------------------------------------------
USE Corporation
-- 1. Find all information about all departments.
SELECT * FROM Departments
-- 2. Find all department names.
SELECT Name from Departments
-- 3. Find first name, last name and salary of each employee.
SELECT FirstName, LastName, Salary FROM Employees
-- 4. Write a SQL to find the full name of each employee. 
--       Hint: Full name is constructed by joining first, middle and last name.
SELECT Concat(FirstName, MiddleName, LastName) AS FullName FROM Employees

-- 5. Find all different employee salaries.
SELECT Distinct Salary from Employees

-- 6. Find all information about the employees whose job title is "Sales Representative" or "Sales Manager".
SELECT * FROM Employees WHERE JobTitle = 'Sales Representative' OR JobTitle LIKE  '%Sales Manager%'

-- 7. Find the names of all employees whose first name starts with "SA".
SELECT FirstName,MiddleName,LastName FROM Employees WHERE FirstName Like 'Sa%' 
-- 8. Find the names of all employees whose last name contains "ei".
SELECT FirstName,MiddleName,LastName FROM Employees WHERE LastName LIKE('%ei%') 
-- 9. Find the salary of all employees whose salary is in the range [20000…30000].
SELECT Salary from Employees where Salary >= 20000 AND Salary <= 30000

-- 10. Find the names of all employees whose salary is 25000, 14000, 12500 or 23600.
SELECT CONCAT(FirstName,MiddleName,LastName) AS Name  FROM Employees WHERE Salary=25000 or Salary =14000 or Salary=12500 or Salary=23600
-- 11. Find all employees that do not have manager.
SELECT * FROM Employees WHERE ManagerID is null

-- 12. Find all employees that have salary more than 50000. Order them in decreasing order by salary.
SELECT * FROM Employees WHERE Salary > 50000 ORDER BY SALARY DESC
-- 13. Find the top 5 best paid employees.
SELECT TOP 5 * FROM Employees ORDER BY Salary DESC
-- 14. Find all employees along with their address. Use inner join with ON clause.
SELECT e.FirstName, a.AddressText FROM Employees e
INNER JOIN Addresses a ON a.AddressID = e.AddressID


-- 15. Find all employees and their address. Use equijoins (conditions in the WHERE clause).
SELECT e.FirstName, a.AddressText FROM Employees e, Addresses a
WHERE a.AddressID = e.AddressID
-- 16. Find all employees along with their manager.
SELECT e.FirstName, m.FirstName from Employees e
JOIN Employees m ON e.EmployeeID = m.ManagerID  
-- 17. Find all employees, along with the employee's address. 
--       Hint: Join Employees AS e, Employees AS m and Addresses.
SELECT e.FirstName, a.AddressText FROM Employees e
join Addresses a ON e.AddressID=a.AddressID
-- 18. Find all departments and all town names as a single list. 
--       Hint: Use UNION (https://www.w3schools.com/sql/sql_union.asp)

SELECT d.Name from Departments d
UNION ALL
SELECT t.Name from Towns t

-- 19. Write a SQL query that lists the name of each employee along with the name of their manager.
--       Hint: Use LEFT OUTER JOIN.
--			   Then rewrite the query using RIGHT OUTER JOIN (https://www.w3schools.com/sql/sql_join_right.asp).
--             The expected result is shown below.
SELECT e.FirstName AS Employe, m.FirstName as Manager from Employees e
RIGHT OUTER JOIN Employees m ON e.EmployeeID = m.ManagerID 
-- | Employee                 | Manager            |
-- | ------------------------ | ------------------ |
-- | Ken Sanchez              | NULL               |
-- | Martin Kulov             | NULL               |
-- | George Denchev           | NULL               |
-- | Ovidiu Cracium           | Roberto Tamburello |
-- | Michael Sullivan         | Roberto Tamburello |
-- | Sharon Salavaria         | Roberto Tamburello |
-- | Dylan Miller             | Roberto Tamburello |
-- | Rob Walters              | Roberto Tamburello |
-- | Gail Erickson            | Roberto Tamburello |
-- | Jossef Goldberg          | Roberto Tamburello |
-- | Kevin Brown              | David Bradley      |
-- | Sariya Harnpadoungsataya | David Bradley      |
-- | Jill Williams            | David Bradley      |
-- | Mary Gibson              | David Bradley      |
-- | Terry Eminhizer          | David Bradley      |

-- 20. Find the names of all employees who were hired between 1995 and 2005 and are part of the "Sales" or "Finance" departments.

SELECT e.FirstName, e.LastName, d.Name FROM Employees e
JOIN Departments d ON e.DepartmentID = d.DepartmentID
WHERE (DATEPART(YEAR, e.HireDate) between 1995 and 2005) and(d.Name = 'Sales' OR d.Name = 'Finance') 

-- 21. Find the names and salaries of the employees that take the minimal salary in the company.
--       Hint: Use a nested SELECT statement.
Select * FROM Employees e
WHERE e.Salary = (
 SELECT TOP(1) Salary from Employees
 order by Salary
)
-- 22. Find the names and salaries of the employees that have a salary that is up to 10% higher than the minimal salary for the company.
SELECT e.FirstName, e.LastName, e.Salary FROM Employees e
WHERE e.Salary <= (
	SELECT top(1) Salary * 1.1 from Employees
	order by Salary
)

-- 23. Find the full name, salary and department of the employees that take the minimal salary in their department.
--       Hint: Use a nested SELECT statement.

SELECT e.FirstName, e.LastName, e.Salary, d.Name FROM Employees e
JOIN Departments d ON e.DepartmentID = d.DepartmentID
WHERE e.DepartmentID=d.DepartmentID AND e.Salary IN (
	SELECT Min(s.Salary) FROM Employees s
	WHERE e.DepartmentID = s.DepartmentID
	group by s.DepartmentID 	
) 


-- 24. Find the number of employees and average salary for each department.
--       Hint: The expected result is shown below.

SELECT d.Name, COUNT(e.EmployeeID) [Employees], AVG(e.Salary) [Average Salary] FROM Employees e
JOIN Departments d ON d.DepartmentID = e.DepartmentID
GROUP BY d.Name
ORDER BY [Average Salary] desc


-- | Department                 | Employees | Average Salary |
-- | -------------------------- | --------- | -------------- |
-- | Executive                  | 2         | 92800.00       |
-- | Research and Development   | 6         | 45133.00       |
-- | Engineering                | 6         | 40167.00       |
-- | Information Services       | 10        | 34180.00       |
-- | Sales                      | 18        | 29989.00       |
-- | Tool Design                | 4         | 27150.00       |
-- | Finance                    | 10        | 23930.00       |
-- | Purchasing                 | 12        | 18983.00       |
-- | Production Control         | 6         | 18683.00       |
-- | Human Resources            | 6         | 18017.00       |
-- | Quality Assurance          | 7         | 17543.00       |
-- | Document Control           | 5         | 14400.00       |
-- | Production                 | 179       | 14163.00       |
-- | Marketing                  | 8         | 14063.00       |
-- | Facilities and Maintenance | 7         | 13057.00       |
-- | Shipping and Receiving     | 6         | 10867.00       |

-- 25. Find the average salary in the "Sales" department.
SELECT AVG(salary) from Employees e
join Departments d ON e.DepartmentID = d.DepartmentID
where d.Name = 'Sales'
-- 26. Find the number of employees in the "Sales" department.
SELECT Count(FirstName) from Employees e
join Departments d ON e.DepartmentID = d.DepartmentID
where d.Name = 'Sales'
-- 27. Find the number of all employees that have a manager.
Select COUNT(FirstName) from Employees e
where e.ManagerID is not null
-- 28. Find the number of all employees that have no manager.
Select COUNT(FirstName) from Employees e
where e.ManagerID is null
-- 29. Find all departments and the average salary for each of them.
SELECT AVG(e.Salary) [Average Salary], e.DepartmentID from Employees e
GROUP BY e.DepartmentID
-- 30. Find the number of employees in each department and for each town. The result table should have 3 columns - Town, Department and Employees Count. 
--       Hint: The expected table has 85 rows. The first 12 rows are shown below.

SELECT t.Name, d.Name, Count(e.EmployeeID) [Employees Count] FROM Employees e
JOIN Addresses a ON e.AddressID = a.AddressID
JOIN Towns t ON t.TownID = a.TownID
JOIN Departments d ON e.DepartmentID = d.DepartmentID
group by t.Name, d.Name
ORDER BY t.Name, [Employees Count] desc


-- | Town	    | Department	                | Employees Count |
-- | ---------- | ----------------------------- | --------------- |
-- | Bellevue	| Production	                | 22              |
-- | Bellevue	| Purchasing	                | 5               |
-- | Bellevue	| Production Control	        | 2               |
-- | Bellevue	| Marketing	                    | 2               |
-- | Bellevue	| Engineering	                | 1               |
-- | Bellevue	| Human Resources	            | 1               |
-- | Bellevue	| Information Services	        | 1               |
-- | Bellevue	| Research and Development	    | 1               |
-- | Bellevue	| Sales	                        | 1               |
-- | Berlin	    | Sales	                        | 1               |
-- | Bordeaux	| Sales	                        | 1               |

-- 31. Display the first and last name of all managers with exactly 5 employees. Display their first name and last name. 
SELECT Concat(mm.FirstName, mm.LastName)[Manager], CONCAT(ee.FirstName, ee.LastName)[Employee] FROM Employees ee
JOIN Employees mm ON ee.ManagerID = mm.EmployeeID
WHERE ee.ManagerID IN
	(SELECT m.EmployeeID  FROM Employees e
	JOIN Employees m ON e.ManagerID = m.EmployeeID
	GROUP BY m.EmployeeID
	HAVING COUNT(m.EmployeeID) = 5)
Order by Manager
-- 32. Find the average employee salary by department and job title.

SELECT d.Name, e.JobTitle, AVG(e.Salary) FROM Employees e
JOIN Departments d ON d.DepartmentID = e.DepartmentID
GROUP BY d.Name, e.JobTitle


-- 33. Find the town where maximal number of employees work.

SELECT TOP(1) t.Name, COUNT(e.EmployeeID) emps FROM Addresses a
JOIN Towns t ON a.TownID = t.TownID
JOIN Employees e ON e.AddressID = a.AddressID
GROUP BY t.Name
order by emps desc


-- 34. Find the number of managers from each town.
SELECT COUNT(e.ManagerID) [Num of managers], t.Name FROM Towns t
JOIN Addresses a ON t.TownID = a.TownID 
JOIN Employees e ON e.AddressID = a.AddressID
GROUP BY t.Name
