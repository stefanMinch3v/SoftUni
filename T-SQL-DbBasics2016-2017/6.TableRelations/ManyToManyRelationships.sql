USE [TestRelationsBetweenDatabases]

CREATE TABLE Students
(
	StudentID int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	Name nvarchar(30)
)

CREATE TABLE Exams
(
	ExamID int PRIMARY KEY NOT NULL,
	Name nvarchar(30) NOT NULL
)

CREATE TABLE StudentsExams
(
	StudentID int NOT NULL,
	ExamID int NOT NULL
	CONSTRAINT PK_StudentId_ExamId     -- 1 constraint add 2 primary keys at once
	PRIMARY KEY(StudentID, ExamID),
	CONSTRAINT FK_StudentExams_Students-- 2 constraint
	FOREIGN KEY(StudentID)
	REFERENCES Students(StudentID),
	CONSTRAINT FK_StudentsExams_Exams  -- 3 constraint
	FOREIGN KEY (ExamID)
	REFERENCES Exams(ExamID)
)

INSERT INTO Students VALUES
('Mila'),
('Toni'),
('Ron')

INSERT INTO Exams VALUES
(101, 'SpringMVC'),
(102, 'Neo4j'),
(103, 'Oracle 11g')

INSERT INTO StudentsExams VALUES
(1, 101),
(1, 102),
(2, 101),
(3, 103),
(2, 102),
(2, 103)