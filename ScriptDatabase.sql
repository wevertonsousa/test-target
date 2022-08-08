CREATE DATABASE TestTarget;
GO
USE TestTarget;
GO
CREATE TABLE [Role] (
Id INT IDENTITY(1,1) NOT NULL,
Name varchar(30) NOT NULL,
CONSTRAINT Role_PK PRIMARY KEY (Id))
GO
CREATE TABLE [Customer] (
Id INT IDENTITY(1,1) NOT NULL,
RoleId INT NOT NULL,
Username VARCHAR(20) NOT NULL,
FullName VARCHAR(50) NOT NULL,
BirthDate DATE NULL,
Country VARCHAR(50) NULL,
Email VARCHAR(100) NULL,
Active BIT NOT NULL,
RegistrationDate DATETIME NOT NULL,
ChangeDate DATETIME NULL,
CONSTRAINT Customer_PK PRIMARY KEY (Id))
GO
ALTER TABLE [Customer] WITH CHECK ADD CONSTRAINT [FK_Role_CustomerRole] FOREIGN KEY (RoleId)
REFERENCES [Role] (Id)
GO
ALTER TABLE [Customer] CHECK CONSTRAINT [FK_Role_CustomerRole]
GO
INSERT INTO [Role] VALUES ('Administrator');
INSERT INTO [Role] VALUES ('User');
GO
INSERT INTO [Customer] VALUES (1,'weverton', 'Weverton Souza','22/03/1991', 'Brasil', 'wevertonsv@gmail.com', 1, getdate(),null);
GO
INSERT INTO [Customer] VALUES (2,'lucca', 'Lucca Valentim','29/12/2014', 'Brasil', 'luccaribeirovalentim@gmail.com', 1, getdate(),null);
