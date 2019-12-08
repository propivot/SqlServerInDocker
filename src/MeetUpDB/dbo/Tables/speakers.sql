CREATE TABLE [dbo].[speakers] (
    [id]		INT           IDENTITY (1, 1) NOT NULL,
	[meetupId]	INT	NOT NULL,			
    [fullName]	NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_speakers] PRIMARY KEY CLUSTERED ([id] ASC),
	CONSTRAINT [FK_speakers_To_meetups] FOREIGN KEY ([meetupId]) REFERENCES [dbo].[meetups] ([id])
);

