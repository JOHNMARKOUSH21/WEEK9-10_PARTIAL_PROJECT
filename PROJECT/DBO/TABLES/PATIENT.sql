CREATE TABLE [dbo].[PATIENT]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [First_Name] NVARCHAR(50) NULL, 
    [Middle_initial] NVARCHAR(50) NULL, 
    [Last_name] NVARCHAR(50) NULL, 
    [Age] INT NULL, 
    [Sex] NVARCHAR(50) NULL, 
    [Height_cm] FLOAT NULL, 
    [Weight_kg] FLOAT NULL, 
    [Phone_num] NVARCHAR(50) NULL, 
    [Email] NVARCHAR(50) NULL, 
    [Nationality] NVARCHAR(50) NULL, 
    [Race] NVARCHAR(50) NULL, 
    [Birthday] NVARCHAR(50) NULL, 
    [Place_of_birth] NVARCHAR(50) NULL, 
    [Blood_type] NVARCHAR(50) NULL 
)
