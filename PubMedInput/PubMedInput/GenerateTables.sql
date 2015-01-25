
/****** Object:  Table [dbo].[Title]    Script Date: 2015/1/21 23:14:44 ******/


CREATE TABLE [dbo].[{0}_Title](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[TI] [nvarchar](500) NULL,
	[DP] [int] NULL,
	[VI] [int] NULL,
	[PG] [int] NULL,
	[Guid] uniqueidentifier NULL,
	[PMID] [int] NULL,
 CONSTRAINT [PK_{0}_Title] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

CREATE TABLE [dbo].[{0}_Mesh](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[TitleGuid] uniqueidentifier NULL,
	[PMID] [int] NULL,
	[MH] [nvarchar](500) NULL,
 CONSTRAINT [PK_{0}_Mesh] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


