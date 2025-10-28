-- Relationships for clarity
ALTER TABLE [dbo].[Session]
ADD CONSTRAINT FK_Session_Course FOREIGN KEY ([CourseId])
REFERENCES [dbo].[Course]([Id]);

ALTER TABLE [dbo].[Participant]
ADD CONSTRAINT FK_Participant_Session FOREIGN KEY ([SessionId])
REFERENCES [dbo].[Session]([Id]);
