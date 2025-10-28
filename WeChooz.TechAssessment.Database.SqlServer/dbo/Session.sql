CREATE TABLE [dbo].[Session] (
    [Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [CourseId] INT NOT NULL,
    [StartDate] DATETIME2 NOT NULL,
    [Mode] NVARCHAR(20) NOT NULL, -- 'Présentiel' or 'Distance'
    [CreatedAt] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
    CONSTRAINT FK_Session_Course FOREIGN KEY (CourseId)
        REFERENCES [dbo].[Course](Id)
        ON DELETE CASCADE
);
