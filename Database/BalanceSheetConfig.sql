CREATE TABLE [dbo].[BalanceSheetConfig](
	[SlNo] [int] NULL,
	[Head] [varchar](100) NULL,
	[QueryType] [varchar](50) NULL,
	[QueryText] [varchar](500) NULL,
	[Filter] [varchar](500) NULL,
	[CssClass] [varchar](50) NULL,
	[Side] [varchar](50) NULL
) ON [PRIMARY]
GO
INSERT [dbo].[BalanceSheetConfig] ([SlNo], [Head], [QueryType], [QueryText], [Filter], [CssClass], [Side]) VALUES (0, N'Assets', NULL, NULL, NULL, N'assets', N'L')
GO
INSERT [dbo].[BalanceSheetConfig] ([SlNo], [Head], [QueryType], [QueryText], [Filter], [CssClass], [Side]) VALUES (1, N'Current Assets', NULL, NULL, NULL, N'curent-assets', N'L')
GO
INSERT [dbo].[BalanceSheetConfig] ([SlNo], [Head], [QueryType], [QueryText], [Filter], [CssClass], [Side]) VALUES (2, N'Cash and cash equivalents', N'Scalar', N'SELECT SUM(CurrentBalance) FROM VW_AccountWithClassification', N'AccountSubType = ''Cash''', N'cash', N'L')
GO
INSERT [dbo].[BalanceSheetConfig] ([SlNo], [Head], [QueryType], [QueryText], [Filter], [CssClass], [Side]) VALUES (3, N'Customers', N'Table', N'SELECT AccountTitle AS Head, CurrentBalance AS Value  FROM VW_AccountWithClassification', N'AccountSubType = ''Bills Receivable''', N'customers', N'L')
GO
INSERT [dbo].[BalanceSheetConfig] ([SlNo], [Head], [QueryType], [QueryText], [Filter], [CssClass], [Side]) VALUES (90, N'Liabilities', NULL, NULL, NULL, N'liabilities', N'R')
GO