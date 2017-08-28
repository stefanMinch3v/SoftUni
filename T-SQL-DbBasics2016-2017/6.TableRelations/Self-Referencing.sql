CREATE TABLE Teachers
(
	TeacherID int PRIMARY KEY NOT NULL,
	Name nvarchar(30) NOT NULL,
	ManagerID int NULL,
	CONSTRAINT FK_ManagerId_TeacherId
	FOREIGN KEY(ManagerID)
	REFERENCES Teachers(TeacherID)
)

INSERT INTO Teachers VALUES
(101, 'John', NULL),
(102, 'Maya', 106),
(103, 'Silvia', 106),
(104, 'Ted', 105),
(105, 'Mark', 101),
(106, 'Greta', 101)