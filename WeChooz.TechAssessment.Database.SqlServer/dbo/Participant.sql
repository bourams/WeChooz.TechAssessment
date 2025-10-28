CREATE TABLE [dbo].[Participant] (
    [Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [SessionId] INT NOT NULL,
    [FirstName] NVARCHAR(100) NOT NULL,
    [LastName] NVARCHAR(100) NOT NULL,
    [Email] NVARCHAR(255) NOT NULL,
    [CompanyName] NVARCHAR(255) NULL,
    [RegisteredAt] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
    CONSTRAINT FK_Participant_Session FOREIGN KEY (SessionId)
        REFERENCES [dbo].[Session](Id)
        ON DELETE CASCADE
);
