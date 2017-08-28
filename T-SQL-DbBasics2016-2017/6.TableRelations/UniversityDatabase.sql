CREATE TABLE Majors
(
	MajorID int PRIMARY KEY,
	Name varchar(50)
)

CREATE TABLE Students
(
	StudentID int PRIMARY KEY,
	StudentNumber int,
	StudentName varchar(50),
	MajorID int,
	CONSTRAINT FK_Students_Majors FOREIGN KEY(MajorID) REFERENCES Majors(MajorID)
)

CREATE TABLE Subjects
(
	SubjectID int PRIMARY KEY,
	SubjectName varchar(50)
)

CREATE TABLE Agenda
(
	StudentID int,
	SubjectID int,
	CONSTRAINT PK_StudentID_SubjectID PRIMARY KEY(StudentID, SubjectID),
	CONSTRAINT FK_Agenda_Students FOREIGN KEY(StudentID) REFERENCES Students(StudentID),
	CONSTRAINT FK_Agenda_Subjects FOREIGN KEY(SubjectID) REFERENCES Subjects(SubjectID)
)

CREATE TABLE Payments
(
	PaymentID int PRIMARY KEY,
	PaymentDate date,
	PaymentAmount decimal,
	StudentID int,
	CONSTRAINT FK_Payments_Students FOREIGN KEY(StudentID) REFERENCES Students(StudentID)
)