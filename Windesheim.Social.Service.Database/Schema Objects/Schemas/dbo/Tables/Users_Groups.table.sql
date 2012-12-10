CREATE TABLE [dbo].[Users_Groups]
(
	user_groupId bigint identity(0,1) primary key not null,
	userId bigint NOT NULL, 
	groupId int NOT NULL,
	groupRole tinyint NOT NULL default 0,
	foreign key (userId) references [Users](userId),
	foreign key (groupId) references [Groups](groupId)
)
