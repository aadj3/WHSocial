CREATE TABLE [dbo].[Users]
(
	userId bigint identity(0,1) NOT NULL primary key, 
	facebookId bigint NULL,
	userName nvarchar(50) NOT NULL
)
