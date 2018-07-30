USE ExamenVueling
GO

IF OBJECT_ID(N'ExamenVueling.dbo.Policies', N'U') IS NULL
BEGIN

CREATE TABLE dbo.Policies
(
	Id INT IDENTITY NOT NULL PRIMARY KEY,
	AmountInsured [NVARCHAR] (50) NOT NULL,
	Email [NVARCHAR] (250) NOT NULL,
	InceptionDate [NVARCHAR] (14) NOT NULL,
    installmentPayment BOOL NOT NULL,
    clientId [NVARCHAR] (200) NOT NULL
);
END