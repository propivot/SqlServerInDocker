CREATE TABLE [dbo].[hosts] (
    [id]       INT           IDENTITY (1, 1) NOT NULL,
    [fullName] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_hosts] PRIMARY KEY CLUSTERED ([id] ASC)
);

