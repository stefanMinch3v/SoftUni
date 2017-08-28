CREATE TABLE Users2 
(
 Id bigint IDENTITY UNIQUE,
 Username varchar(30) UNIQUE NOT NULL,
 Password varchar(26) NOT NULL,
 ProfilePicture binary,
 CHECK (DATALENGTH(ProfilePicture) <= 900),
 LastLoginTime datetime CONSTRAINT [DF_CurrentTime4564654]  DEFAULT (getdate()),
 IsDeleted varchar(5),
 CHECK (IsDeleted = 'true' OR IsDeleted = 'false'),
 PRIMARY KEY(Id)
)

INSERT INTO Users2 (Username, Password, ProfilePicture, IsDeleted)
VALUES ('mITKO', 'asd1232', 9041, 'true'),
	   ('Sofko', 'asd5532', 901241, 'false'),
	   ('Shterion', 'asdEQ232', 9051, 'true'),
	   ('Aleks', 'as45', 90111, 'false'),
	   ('Klaus', '44', 9451, 'true')