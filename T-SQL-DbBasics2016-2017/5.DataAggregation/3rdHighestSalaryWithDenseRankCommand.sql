SELECT salaries.DepartmentId, salaries.Salary FROM
	(SELECT 
		DepartmentId,
		MAX(Salary) AS Salary,
		DENSE_RANK() OVER (PARTITION BY DepartmentId ORDER BY Salary DESC) AS Rank
	 FROM Employees
	 GROUP BY DepartmentId, Salary) AS salaries
WHERE salaries.Rank = 3
GROUP BY salaries.DepartmentId, salaries.Salary