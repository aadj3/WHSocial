CREATE TABLE [dbo].[Messages]
(
	messageId int identity(0,1) primary key NOT NULL, 
	parent int NULL,
	groupId int NOT NULL,
	userId bigint NOT NULL,
	value text NOT NULL,
	postDate datetime NOT NULL,
	foreign key(groupId) references [Groups](groupId),
	foreign key(userId) references [Users](userId),
	foreign key(parent) references [Messages](messageId)
)
