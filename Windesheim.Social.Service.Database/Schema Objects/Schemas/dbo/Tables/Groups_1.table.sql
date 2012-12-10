CREATE TABLE [dbo].[Groups]
(
	groupId int identity(0,1) primary key NOT NULL, 
	groupName nvarchar(50) NOT NULL,
	[description] text NOT NULL,
	accessType tinyint NOT NULL,
)
