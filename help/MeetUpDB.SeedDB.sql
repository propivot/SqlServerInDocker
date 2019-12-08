USE [MeetUpDB]

INSERT INTO [dbo].[hosts] ([fullName]) VALUES ('Jakub Šturc')


INSERT INTO [dbo].[meetups] ([eventName], [eventDate], [hostId]) values ('Brati Dec 2019', getdate(), 1)


INSERT INTO [dbo].[speakers] ([meetupId],[fullName]) VALUES (1,'Roman Jašek'),(1, 'Andrej Zaujec')
