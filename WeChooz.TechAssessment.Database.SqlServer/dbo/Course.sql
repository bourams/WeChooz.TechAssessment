CREATE TABLE [dbo].[Course] (
    [Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Name] NVARCHAR(200) NOT NULL,
    [ShortDescription] NVARCHAR(500) NULL,
    [LongDescriptionMarkdown] NVARCHAR(MAX) NULL,
    [DurationDays] INT NOT NULL,
    [TargetAudience] NVARCHAR(50) NOT NULL, -- 'Elu' or 'President'
    [Capacity] INT NOT NULL,
    [Trainer] NVARCHAR(150) NOT NULL,
    [CreatedAt] DATETIME2 NOT NULL DEFAULT GETUTCDATE()
);