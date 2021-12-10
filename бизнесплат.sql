Alter Trigger dbo.AddAgents
On [dbo].[Agents] 
After Update, Insert
AS
If UPDATE([Priority])
BEGIN
	Insert into HistoryPrioritet([Name],[OldPriority], [Priority], [Date])
	Select i.NameAgent ,d.Priority, i.Priority, GETDATE()
	From inserted i inner join deleted d on i.Id = d.Id;
END
IF EXISTS(Select * from inserted) and NOT EXISTS (Select * from deleted)
BEGIN
	Insert into HistoryPrioritet([Name], [OldPriority], [Priority], [Date])
	Select i.NameAgent, null, i.Priority, GETDATE()
	From inserted i inner join deleted d on i.Id = d.Id;
END