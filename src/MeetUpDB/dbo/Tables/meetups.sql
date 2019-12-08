CREATE TABLE [dbo].[meetups] (
    [id]        INT           IDENTITY (1, 1) NOT NULL,
    [eventName] NVARCHAR (50) NOT NULL,
    [eventDate] DATETIME      NOT NULL,
    [hostId]    INT           NOT NULL,
    CONSTRAINT [PK_meetups] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_meetups_To_hosts] FOREIGN KEY ([hostId]) REFERENCES [dbo].[hosts] ([id]),
);

