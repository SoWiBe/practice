USE [user4]
GO
/****** Object:  Trigger [dbo].[AddAgents]    Script Date: 10.12.2021 9:33:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER Trigger [dbo].[AddAgents]
On [dbo].[Agents] 
After Update, Insert
AS
IF EXISTS(Select * from inserted)
BEGIN
	Insert into HistoryPrioritet([Name], [OldPriority], [Priority], [Date])
	Select i.NameAgent, null, i.Priority, GETDATE()
	From inserted i inner join deleted d on i.Id = d.Id;
END
If UPDATE([Priority])
BEGIN
	Insert into HistoryPrioritet([Name],[OldPriority], [Priority], [Date])
	Select i.NameAgent,d.Priority, i.Priority, GETDATE()
	From inserted i inner join deleted d on i.Id = d.Id;
END

