CREATE TABLE [dbo].[CustomReport](
	[ReportId] [int] IDENTITY(1,1) NOT NULL,
	[ReportName] [varchar](100) NULL,
	[ReportTitle] [varchar](200) NULL,
	[Styles] [varchar](max) NULL,
	[CompanyId] [int] NULL,
 CONSTRAINT [PK_CustomReport] PRIMARY KEY CLUSTERED 
(
	[ReportId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

CREATE TABLE [dbo].[CustomReportDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ReportId] [int] NULL,
	[SortOrder] [int] NULL,
	[Head] [varchar](100) NULL,
	[QueryType] [varchar](50) NULL,
	[QueryText] [varchar](max) NULL,
	[Filter] [varchar](max) NULL,
	[CssClass] [varchar](100) NULL,
	[Side] [varchar](5) NULL,
 CONSTRAINT [PK_CustomReportDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]