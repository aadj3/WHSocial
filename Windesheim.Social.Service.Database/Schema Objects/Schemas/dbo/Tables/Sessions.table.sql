CREATE TABLE [dbo].[Sessions]
(
	userId bigint primary key NOT NULL, 
	ticket uniqueidentifier NOT NULL,
	validTill datetime NOT NULL,
	foreign key (userId) references [Users](userId)
)
