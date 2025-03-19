USE [Dna]
GO
/****** Object:  UserDefinedTableType [dbo].[FamilyFinderTable]    Script Date: 13.03.2025 14:43:27 ******/
CREATE TYPE [dbo].[FamilyFinderTable] AS TABLE(
	[FamilyFinderId] [nvarchar](350) NOT NULL,
	[KitNr] [nvarchar](350) NOT NULL,
	[Full_Name] [nvarchar](max) NOT NULL,
	[First_Name] [nvarchar](max) NOT NULL,
	[Middle_Name] [nvarchar](max) NULL,
	[Last_Name] [nvarchar](max) NOT NULL,
	[Match_Date] [date] NOT NULL,
	[Relationship_Range] [nvarchar](max) NOT NULL,
	[Suggested_Relationship] [nvarchar](max) NOT NULL,
	[Shared_cM] [float] NOT NULL,
	[Longest_Block] [float] NOT NULL,
	[Linked_Relationship] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Ancestral_Surnames] [nvarchar](max) NULL,
	[Y_DNA_Haplogroup] [nvarchar](max) NULL,
	[mtDNA_Haplogroup] [nvarchar](max) NULL,
	[Notes] [nvarchar](max) NULL,
	[Matching_Bucket] [nvarchar](max) NOT NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[GedMatchTable]    Script Date: 13.03.2025 14:43:27 ******/
CREATE TYPE [dbo].[GedMatchTable] AS TABLE(
	[KitNr] [nvarchar](100) NOT NULL,
	[Kit] [nvarchar](100) NOT NULL,
	[OneToManyLink] [nvarchar](max) NOT NULL,
	[CompareLink] [nvarchar](max) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[LargestSeg] [float] NOT NULL,
	[TotalcM] [float] NOT NULL,
	[Gen] [float] NOT NULL,
	[LowOverlappingInfo] [nvarchar](100) NULL,
	[Overlap] [int] NOT NULL,
	[DateCompared] [datetime] NOT NULL,
	[TestingCompany] [nvarchar](max) NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[KitNumberTable]    Script Date: 13.03.2025 14:43:27 ******/
CREATE TYPE [dbo].[KitNumberTable] AS TABLE(
	[KitNr] [nvarchar](50) NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[KitNumberTableWithId]    Script Date: 13.03.2025 14:43:27 ******/
CREATE TYPE [dbo].[KitNumberTableWithId] AS TABLE(
	[id] [int] NOT NULL,
	[KitNr] [nvarchar](50) NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[MyHeritageSegmentsTable]    Script Date: 13.03.2025 14:43:27 ******/
CREATE TYPE [dbo].[MyHeritageSegmentsTable] AS TABLE(
	[MyHeritageMatchId] [nvarchar](100) NOT NULL,
	[KitNr] [nvarchar](100) NOT NULL,
	[Start_Position] [int] NOT NULL,
	[End_Position] [int] NOT NULL,
	[Chromosom] [tinyint] NOT NULL,
	[Anfangs_RSID] [nvarchar](100) NOT NULL,
	[End_RSID] [nvarchar](100) NOT NULL,
	[Centimorgan] [float] NOT NULL,
	[SNPs] [int] NOT NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[MyHeritageTable]    Script Date: 13.03.2025 14:43:27 ******/
CREATE TYPE [dbo].[MyHeritageTable] AS TABLE(
	[MyHeritageMatchId] [nvarchar](max) NOT NULL,
	[KitNr] [nvarchar](max) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Alter] [nvarchar](max) NULL,
	[Land] [nvarchar](max) NULL,
	[DNA_Match_kontaktieren] [nvarchar](max) NULL,
	[DNA_verwaltet_von] [nvarchar](max) NOT NULL,
	[DNA_Verwalter_kontaktieren] [nvarchar](max) NULL,
	[Status] [nvarchar](max) NULL,
	[Voraussichtliche_Verwandtschaft] [nvarchar](max) NOT NULL,
	[Gesamtlaenge_cM_geteilt] [float] NULL,
	[Prozent_der_gemeinsamen_DNA] [float] NOT NULL,
	[Anzahl_gemeinsamer_Segmente] [int] NOT NULL,
	[Groesstes_Segment_cM] [float] NOT NULL,
	[DNA_Match_Seite_pruefen] [nvarchar](max) NOT NULL,
	[Hat_einen_Stammbaum] [nvarchar](max) NOT NULL,
	[Anzahl_der_Personen_im_Stammbaum] [int] NULL,
	[Stammbaum_verwaltet_von] [nvarchar](max) NULL,
	[Stammbaum_ansehen] [nvarchar](max) NULL,
	[Stammbaumverwalter_kontaktieren] [nvarchar](max) NULL,
	[Anzahl_von_SmartMatches] [int] NULL,
	[Geteilte_gemeinsame_Nachnamen] [nvarchar](max) NULL,
	[Alle_Nachnamen_der_Vorfahren] [nvarchar](max) NULL,
	[Anmerkungen] [nvarchar](max) NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[YfullTable]    Script Date: 13.03.2025 14:43:27 ******/
CREATE TYPE [dbo].[YfullTable] AS TABLE(
	[ID] [varchar](50) NOT NULL,
	[KitNr] [nvarchar](100) NOT NULL,
	[MRCA_branch] [varchar](50) NOT NULL,
	[TMRCA_ybp] [varchar](50) NOT NULL,
	[Most_distant_ancestor] [nvarchar](500) NULL,
	[Country_of_origin] [varchar](50) NULL,
	[Terminal_Hg] [varchar](50) NOT NULL,
	[Shared_SNPs] [varchar](max) NOT NULL,
	[Assumed_shared_SNPs] [varchar](max) NOT NULL,
	[All_shared_SNPs] [int] NOT NULL
)
GO
/****** Object:  UserDefinedFunction [dbo].[GetFamilyFinderUpdateCriteria]    Script Date: 13.03.2025 14:43:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[GetFamilyFinderUpdateCriteria](@Email NVARCHAR(350), @Ancestral_Surnames NVARCHAR(MAX), @Y_DNA_Haplogroup NVARCHAR(MAX), @mtDNA_Haplogroup NVARCHAR(MAX), @Notes NVARCHAR(MAX), @Matching_Bucket NVARCHAR(MAX))
RETURNS NVARCHAR(MAX) AS
BEGIN
	RETURN 
	LOWER( 
	+ RTRIM(LTRIM(ISNULL(@Ancestral_Surnames, ''))) 
	+ RTRIM(LTRIM(ISNULL(@Y_DNA_Haplogroup, ''))) 
	+ RTRIM(LTRIM(ISNULL(@mtDNA_Haplogroup, ''))) 
	+ RTRIM(LTRIM(ISNULL(@Notes, ''))) 
	+ RTRIM(LTRIM(ISNULL(@Matching_Bucket, ''))))
END
GO
/****** Object:  UserDefinedFunction [dbo].[GetGetMatchFinderUpdateCriteria]    Script Date: 13.03.2025 14:43:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create FUNCTION [dbo].[GetGetMatchFinderUpdateCriteria](@OneToManyLink nvarchar(max), @CompareLink nvarchar(max), @Name nvarchar(max),@Email nvarchar(max), @LowOverlappingInfo nvarchar(100))
RETURNS NVARCHAR(MAX) AS
BEGIN
	RETURN 
	LOWER(RTRIM(LTRIM(ISNULL(@OneToManyLink, ''))) 
	+ RTRIM(LTRIM(ISNULL(@CompareLink, ''))) 
	+ RTRIM(LTRIM(ISNULL(@Name, ''))) 
	+ RTRIM(LTRIM(ISNULL(@Email, ''))) 
	+ RTRIM(LTRIM(ISNULL(@LowOverlappingInfo, ''))) )
END
GO
/****** Object:  UserDefinedFunction [dbo].[GetMyHeritageUpdateCriteria]    Script Date: 13.03.2025 14:43:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE FUNCTION [dbo].[GetMyHeritageUpdateCriteria](@Name NVARCHAR(MAX) ,@Alter NVARCHAR(MAX) ,@Land NVARCHAR(MAX) ,@DNA_Match_kontaktieren NVARCHAR(MAX) ,@DNA_verwaltet_von NVARCHAR(MAX),@DNA_Verwalter_kontaktieren NVARCHAR(MAX)
      ,@Status NVARCHAR(MAX) ,@Voraussichtliche_Verwandtschaft NVARCHAR(MAX) ,@DNA_Match_Seite_pruefen NVARCHAR(MAX) ,@Hat_einen_Stammbaum NVARCHAR(MAX) ,@Anzahl_der_Personen_im_Stammbaum INT
      ,@Stammbaum_verwaltet_von NVARCHAR(MAX) ,@Stammbaum_ansehen NVARCHAR(MAX) ,@Stammbaumverwalter_kontaktieren NVARCHAR(MAX) ,@Anzahl_von_SmartMatches INT ,@Geteilte_gemeinsame_Nachnamen NVARCHAR(MAX)
      ,@Alle_Nachnamen_der_Vorfahren NVARCHAR(MAX) ,@Anmerkungen NVARCHAR(MAX))
RETURNS NVARCHAR(MAX) AS
BEGIN
	RETURN 
	    LOWER(RTRIM(LTRIM(ISNULL(@Name, ''))) 
	  + RTRIM(LTRIM(ISNULL(@Alter, ''))) 
	  + RTRIM(LTRIM(ISNULL(@Land, ''))) 
	  + RTRIM(LTRIM(ISNULL(@DNA_Match_kontaktieren, ''))) 
	  + RTRIM(LTRIM(ISNULL(@DNA_verwaltet_von, ''))) 
	  + RTRIM(LTRIM(ISNULL(@DNA_Verwalter_kontaktieren, ''))) 
      + RTRIM(LTRIM(ISNULL(@Status, ''))) 
	  + RTRIM(LTRIM(ISNULL(@Voraussichtliche_Verwandtschaft, ''))) 
	  + RTRIM(LTRIM(ISNULL(@DNA_Match_Seite_pruefen, ''))) 
	  + RTRIM(LTRIM(ISNULL(@Hat_einen_Stammbaum, ''))) 
	  + RTRIM(LTRIM(ISNULL(@Anzahl_der_Personen_im_Stammbaum, ''))) 
      + RTRIM(LTRIM(ISNULL(@Stammbaum_verwaltet_von, ''))) 
	  + RTRIM(LTRIM(ISNULL(@Stammbaum_ansehen, ''))) 
	  + RTRIM(LTRIM(ISNULL(@Stammbaumverwalter_kontaktieren, ''))) 
	  + RTRIM(LTRIM(ISNULL(@Anzahl_von_SmartMatches, ''))) 
	  + RTRIM(LTRIM(ISNULL(@Geteilte_gemeinsame_Nachnamen, ''))) 
      + RTRIM(LTRIM(ISNULL(@Alle_Nachnamen_der_Vorfahren, ''))) 
	  + RTRIM(LTRIM(ISNULL(@Anmerkungen, '')))) 
END
GO
/****** Object:  UserDefinedFunction [dbo].[GetYFullCriteriaUpdateCriteria]    Script Date: 13.03.2025 14:43:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE FUNCTION [dbo].[GetYFullCriteriaUpdateCriteria](
	@MRCA_branch varchar(50),
	@TMRCA_ybp varchar(50),
	@Most_distant_ancestor nvarchar(500),
	@Country_of_origin varchar(50),
	@Terminal_Hg varchar(50),
	@Shared_SNPs varchar(max),
	@Assumed_shared_SNPs varchar(max),
	@All_shared_SNPs int
)
RETURNS NVARCHAR(MAX) AS
BEGIN
	RETURN 
	    LOWER(RTRIM(LTRIM(ISNULL(@MRCA_branch, ''))) 
	  + RTRIM(LTRIM(ISNULL(@TMRCA_ybp, ''))) 
	  + RTRIM(LTRIM(ISNULL(@Most_distant_ancestor, ''))) 
	  + RTRIM(LTRIM(ISNULL(@Country_of_origin, ''))) 
	  + RTRIM(LTRIM(ISNULL(@Terminal_Hg, ''))) 
      + RTRIM(LTRIM(ISNULL(@Shared_SNPs, ''))) 
	  + RTRIM(LTRIM(ISNULL(@Assumed_shared_SNPs, ''))) 
	  + RTRIM(LTRIM(ISNULL(@All_shared_SNPs, '')))) 
END
GO
/****** Object:  Table [dbo].[Companies]    Script Date: 13.03.2025 14:43:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Companies](
	[CompanyId] [int] NOT NULL,
	[CompanyName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Companies_1] PRIMARY KEY CLUSTERED 
(
	[CompanyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FamilyFinder]    Script Date: 13.03.2025 14:43:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FamilyFinder](
	[TblId] [int] IDENTITY(1,1) NOT NULL,
	[FamilyFinderId] [nvarchar](350) NOT NULL,
	[KitNr] [nvarchar](50) NOT NULL,
	[Full_Name] [nvarchar](max) NOT NULL,
	[First_Name] [nvarchar](max) NOT NULL,
	[Middle_Name] [nvarchar](max) NULL,
	[Last_Name] [nvarchar](max) NOT NULL,
	[Match_Date] [date] NOT NULL,
	[Relationship_Range] [nvarchar](max) NOT NULL,
	[Suggested_Relationship] [nvarchar](max) NULL,
	[Shared_cM] [float] NOT NULL,
	[Longest_Block] [float] NOT NULL,
	[Linked_Relationship] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Ancestral_Surnames] [nvarchar](max) NULL,
	[Y_DNA_Haplogroup] [nvarchar](max) NULL,
	[mtDNA_Haplogroup] [nvarchar](max) NULL,
	[Notes] [nvarchar](max) NULL,
	[Matching_Bucket] [nvarchar](max) NOT NULL,
	[InsertDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_FamilyFinder] PRIMARY KEY CLUSTERED 
(
	[TblId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GedMatch]    Script Date: 13.03.2025 14:43:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GedMatch](
	[KitNr] [nvarchar](100) NOT NULL,
	[Kit] [nvarchar](100) NOT NULL,
	[OneToManyLink] [nvarchar](max) NOT NULL,
	[CompareLink] [nvarchar](max) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[LargestSeg] [float] NOT NULL,
	[TotalcM] [float] NOT NULL,
	[Gen] [float] NOT NULL,
	[LowOverlappingInfo] [nvarchar](100) NULL,
	[Overlap] [int] NOT NULL,
	[DateCompared] [datetime] NOT NULL,
	[TestingCompany] [nvarchar](max) NULL,
	[InsertDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_GedMatch] PRIMARY KEY CLUSTERED 
(
	[KitNr] ASC,
	[Kit] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kits]    Script Date: 13.03.2025 14:43:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kits](
	[KitNr] [nvarchar](100) NOT NULL,
	[KitTypeId] [int] NOT NULL,
	[CompanyId] [int] NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[FullName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Kits_1] PRIMARY KEY CLUSTERED 
(
	[KitNr] ASC,
	[KitTypeId] ASC,
	[CompanyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KitTypes]    Script Date: 13.03.2025 14:43:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KitTypes](
	[KitTypeId] [int] NOT NULL,
	[Description] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_KitTypes] PRIMARY KEY CLUSTERED 
(
	[KitTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MyHeritage]    Script Date: 13.03.2025 14:43:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MyHeritage](
	[TblId] [int] IDENTITY(1,1) NOT NULL,
	[MyHeritageMatchId] [nvarchar](100) NOT NULL,
	[KitNr] [nvarchar](100) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Alter] [nvarchar](100) NULL,
	[Land] [nvarchar](100) NULL,
	[DNA_Match_kontaktieren] [nvarchar](max) NULL,
	[DNA_verwaltet_von] [nvarchar](max) NOT NULL,
	[DNA_Verwalter_kontaktieren] [nvarchar](max) NULL,
	[Status] [nvarchar](100) NULL,
	[Voraussichtliche_Verwandtschaft] [nvarchar](max) NOT NULL,
	[Gesamtlaenge_cM_geteilt] [float] NOT NULL,
	[Prozent_der_gemeinsamen_DNA] [float] NOT NULL,
	[Anzahl_gemeinsamer_Segmente] [int] NOT NULL,
	[Groesstes_Segment_cM] [float] NOT NULL,
	[DNA_Match_Seite_pruefen] [nvarchar](max) NOT NULL,
	[Hat_einen_Stammbaum] [nvarchar](max) NOT NULL,
	[Anzahl_der_Personen_im_Stammbaum] [int] NULL,
	[Stammbaum_verwaltet_von] [nvarchar](max) NULL,
	[Stammbaum_ansehen] [nvarchar](max) NULL,
	[Stammbaumverwalter_kontaktieren] [nvarchar](max) NULL,
	[Anzahl_von_SmartMatches] [int] NULL,
	[Geteilte_gemeinsame_Nachnamen] [nvarchar](max) NULL,
	[Alle_Nachnamen_der_Vorfahren] [nvarchar](max) NULL,
	[Anmerkungen] [nvarchar](max) NULL,
	[InsertDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_MyHeritage_1] PRIMARY KEY CLUSTERED 
(
	[TblId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MyHeritageSegments]    Script Date: 13.03.2025 14:43:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MyHeritageSegments](
	[MyHeritageMatchId] [nvarchar](100) NOT NULL,
	[KitNr] [nvarchar](100) NOT NULL,
	[Start_Position] [int] NOT NULL,
	[End_Position] [int] NOT NULL,
	[Chromosom] [tinyint] NOT NULL,
	[Anfangs_RSID] [nvarchar](100) NOT NULL,
	[End_RSID] [nvarchar](100) NOT NULL,
	[Centimorgan] [float] NOT NULL,
	[SNPs] [int] NOT NULL,
	[InsertDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_MyHeritageSegments] PRIMARY KEY CLUSTERED 
(
	[MyHeritageMatchId] ASC,
	[KitNr] ASC,
	[Start_Position] ASC,
	[End_Position] ASC,
	[Chromosom] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Yfull]    Script Date: 13.03.2025 14:43:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Yfull](
	[ID] [varchar](50) NOT NULL,
	[KitNr] [nvarchar](100) NOT NULL,
	[MRCA_branch] [varchar](50) NOT NULL,
	[TMRCA_ybp] [varchar](50) NOT NULL,
	[Most_distant_ancestor] [nvarchar](500) NULL,
	[Country_of_origin] [varchar](50) NULL,
	[Terminal_Hg] [varchar](50) NOT NULL,
	[Shared_SNPs] [varchar](max) NOT NULL,
	[Assumed_shared_SNPs] [varchar](max) NOT NULL,
	[All_shared_SNPs] [int] NOT NULL,
	[InsertDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_Yfull] PRIMARY KEY CLUSTERED 
(
	[ID] ASC,
	[KitNr] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Kits]  WITH NOCHECK ADD  CONSTRAINT [FK_Kits_Companies] FOREIGN KEY([KitTypeId])
REFERENCES [dbo].[KitTypes] ([KitTypeId])
GO
ALTER TABLE [dbo].[Kits] NOCHECK CONSTRAINT [FK_Kits_Companies]
GO
ALTER TABLE [dbo].[MyHeritage]  WITH CHECK ADD  CONSTRAINT [FK_MyHeritage_MyHeritage] FOREIGN KEY([TblId])
REFERENCES [dbo].[MyHeritage] ([TblId])
GO
ALTER TABLE [dbo].[MyHeritage] CHECK CONSTRAINT [FK_MyHeritage_MyHeritage]
GO
/****** Object:  StoredProcedure [dbo].[InsertUpdateFamilyFinder]    Script Date: 13.03.2025 14:43:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertUpdateFamilyFinder](@Data FamilyFinderTable READONLY)
AS
BEGIN
	DECLARE @Updated INT = 0
	DECLARE @Inserted INT = 0
	DECLARE @Date DATETIME = GETDATE()
	
	UPDATE [dbo].[FamilyFinder]
		SET
			FamilyFinderId = D.FamilyFinderId,
			KitNr = D.KitNr,
			[Middle_Name] = D.[Middle_Name],
			[Linked_Relationship] = D.[Linked_Relationship],
			[Email] = D.[Email],
			[Ancestral_Surnames] = D.[Ancestral_Surnames],
			[Y_DNA_Haplogroup] = D.[Y_DNA_Haplogroup],
			[mtDNA_Haplogroup] = D.[mtDNA_Haplogroup],
			[Notes] = D.[Notes],
			[Matching_Bucket] = D.[Matching_Bucket],
			UpdateDate = @Date 
		FROM 
			@Data D 
			INNER JOIN [dbo].[FamilyFinder] FF ON D.FamilyFinderId = FF.FamilyFinderId AND D.KitNr = FF.KitNr
		WHERE
			 dbo.GetFamilyFinderUpdateCriteria(FF.Email, FF.Ancestral_Surnames, FF.Y_DNA_Haplogroup,FF.mtDNA_Haplogroup, FF.Notes, FF.Matching_Bucket)
			<> dbo.GetFamilyFinderUpdateCriteria(D.Email, D.Ancestral_Surnames, D.Y_DNA_Haplogroup,D.mtDNA_Haplogroup, D.Notes, D.Matching_Bucket)


		SET @Updated = @@ROWCOUNT

	
	INSERT INTO [dbo].[FamilyFinder]
			   (	 [FamilyFinderId]
					,[KitNr]
					,[Full_Name]
					,[First_Name]
			   ,[Middle_Name]
					,[Last_Name]
					,[Match_Date]
					,[Relationship_Range]
					--,[Suggested_Relationship]
					,[Shared_cM]
					,[Longest_Block]
			   ,[Linked_Relationship]
			   --,[Email]
			   ,[Ancestral_Surnames]
			   ,[Y_DNA_Haplogroup]
			   ,[mtDNA_Haplogroup]
			   ,[Notes]
			   ,[Matching_Bucket]
					,[InsertDate])
	SELECT 
				 [FamilyFinderId]
				,[KitNr]
			   ,[Full_Name]
			   ,[First_Name]
			   ,[Middle_Name]
			   ,[Last_Name]
			   ,[Match_Date]
			   ,[Relationship_Range]
			  -- ,[Suggested_Relationship]
			   ,[Shared_cM]
			   ,[Longest_Block]
			   ,[Linked_Relationship]
			   --,[Email]
			   ,[Ancestral_Surnames]
			   ,[Y_DNA_Haplogroup]
			   ,[mtDNA_Haplogroup]
			   ,[Notes]
			   ,[Matching_Bucket]
			   ,@Date 
	FROM 
		@Data D
	WHERE NOT EXISTS 
			(SELECT 1 FROM [dbo].[FamilyFinder] 
				WHERE KitNr = D.KitNr AND [FamilyFinderId] = D.[FamilyFinderId])

	SET @Inserted = @@ROWCOUNT

	SELECT @Updated Updated, @Inserted Inserted

END
GO
/****** Object:  StoredProcedure [dbo].[InsertUpdateGedMatch]    Script Date: 13.03.2025 14:43:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[InsertUpdateGedMatch](@Data GedMatchTable READONLY)
AS
BEGIN
	DECLARE @Updated INT = 0
	DECLARE @Inserted INT= 0
	DECLARE @Date DATETIME = GETDATE()
	
UPDATE [dbo].[GedMatch]
   SET [KitNr] = D.KitNr
      ,[Kit] = D.[Kit]
      ,[OneToManyLink] = D.[OneToManyLink]
      ,[CompareLink] = D.[CompareLink]
      ,[Name] = D.[Name]
      ,[Email] = D.[Email]
      ,[LargestSeg] = D.[LargestSeg]
      ,[TotalcM] = D.[TotalcM]
      ,[Gen] = D.[Gen]
      ,[LowOverlappingInfo] = D.[LowOverlappingInfo]
      ,[Overlap] = D.[Overlap]
      ,[DateCompared] = D.[DateCompared]
      ,[TestingCompany] = D.[TestingCompany]
      ,[InsertDate] = @Date
	FROM
		@Data D INNER JOIN [dbo].[GedMatch] GM ON GM.Kit = D.Kit AND D.KitNr = GM.KitNr AND
		[dbo].[GetGetMatchFinderUpdateCriteria](D.OneToManyLink, D.CompareLink, D.Name, D.Email, D.LowOverlappingInfo)
		<> 
		[dbo].[GetGetMatchFinderUpdateCriteria](GM.OneToManyLink, GM.CompareLink, GM.Name, GM.Email, GM.LowOverlappingInfo)

SET @Updated = @@ROWCOUNT

	

INSERT INTO [dbo].[GedMatch]
           ([KitNr]
           ,[Kit]
           ,[OneToManyLink]
           ,[CompareLink]
           ,[Name]
           ,[Email]
           ,[LargestSeg]
           ,[TotalcM]
           ,[Gen]
           ,[LowOverlappingInfo]
           ,[Overlap]
           ,[DateCompared]
           ,[TestingCompany]
			,InsertDate)
SELECT [KitNr]
      ,[Kit]
      ,[OneToManyLink]
      ,[CompareLink]
      ,[Name]
      ,[Email]
      ,[LargestSeg]
      ,[TotalcM]
      ,[Gen]
      ,[LowOverlappingInfo]
      ,[Overlap]
      ,[DateCompared]
      ,[TestingCompany]
      , @Date
		  
	FROM @Data D
	WHERE NOT EXISTS 
			(SELECT 1 FROM [dbo].[GedMatch]
				WHERE KitNr = D.KitNr AND
					KIt = D.KIt)

	SET @Inserted = @@ROWCOUNT

	SELECT @Updated Updated, @Inserted Inserted

END
GO
/****** Object:  StoredProcedure [dbo].[InsertUpdateMyHeritage]    Script Date: 13.03.2025 14:43:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InsertUpdateMyHeritage](@Data MyHeritageTable READONLY)
AS
BEGIN
	DECLARE @Updated INT = 0
	DECLARE @Inserted INT= 0
	DECLARE @Date DATETIME = GETDATE()
	
	UPDATE [dbo].[MyHeritage]
	SET 
		  [Name] = D.Name
		  ,[Alter] = D.[Alter]
		  ,[Land] = D.Land
		  ,[DNA_Match_kontaktieren] = D.DNA_Match_kontaktieren
		  ,[DNA_verwaltet_von] = D.DNA_verwaltet_von
		  ,[DNA_Verwalter_kontaktieren] = D.DNA_Verwalter_kontaktieren
		  ,[Status] = D.Status
		  ,[Voraussichtliche_Verwandtschaft] = D.Voraussichtliche_Verwandtschaft
		  ,[Gesamtlaenge_cM_geteilt] = D.Gesamtlaenge_cM_geteilt
		  ,[Prozent_der_gemeinsamen_DNA] = D.Prozent_der_gemeinsamen_DNA
		  ,[Anzahl_gemeinsamer_Segmente] = D.Anzahl_gemeinsamer_Segmente
		  ,[Groesstes_Segment_cM] = D.Groesstes_Segment_cM
		  ,[DNA_Match_Seite_pruefen] = D.DNA_Match_Seite_pruefen
		  ,[Hat_einen_Stammbaum] = D.Hat_einen_Stammbaum
		  ,[Anzahl_der_Personen_im_Stammbaum] = D.Anzahl_der_Personen_im_Stammbaum
		  ,[Stammbaum_verwaltet_von] = D.Stammbaum_verwaltet_von
		  ,[Stammbaum_ansehen] = D.Stammbaum_ansehen
		  ,[Stammbaumverwalter_kontaktieren] = D.Stammbaumverwalter_kontaktieren
		  ,[Anzahl_von_SmartMatches] = D.Anzahl_von_SmartMatches
		  ,[Geteilte_gemeinsame_Nachnamen] = D.Geteilte_gemeinsame_Nachnamen
		  ,[Alle_Nachnamen_der_Vorfahren] = D.Alle_Nachnamen_der_Vorfahren
		  ,[Anmerkungen] = D.Anmerkungen
		  ,UpdateDate = @Date
	FROM
		@Data D INNER JOIN [dbo].[MyHeritage] MH ON MH.MyHeritageMatchId = D.MyHeritageMatchId AND D.KitNr = MH.KitNr
	WHERE 
		 [dbo].[GetMyHeritageUpdateCriteria](D.Name ,D.[Alter] ,D.Land ,D.DNA_Match_kontaktieren ,D.DNA_verwaltet_von,D.DNA_Verwalter_kontaktieren
		  ,D.Status ,D.Voraussichtliche_Verwandtschaft ,D.DNA_Match_Seite_pruefen ,D.Hat_einen_Stammbaum ,D.Anzahl_der_Personen_im_Stammbaum
		  ,D.Stammbaum_verwaltet_von ,D.Stammbaum_ansehen ,D.Stammbaumverwalter_kontaktieren ,D.Anzahl_von_SmartMatches ,D.Geteilte_gemeinsame_Nachnamen
		  ,D.Alle_Nachnamen_der_Vorfahren ,D.Anmerkungen)
		<> 
		[dbo].[GetMyHeritageUpdateCriteria](MH.Name ,MH.[Alter] ,MH.Land ,MH.DNA_Match_kontaktieren ,MH.DNA_verwaltet_von,MH.DNA_Verwalter_kontaktieren
		  ,MH.Status ,MH.Voraussichtliche_Verwandtschaft ,MH.DNA_Match_Seite_pruefen ,MH.Hat_einen_Stammbaum ,MH.Anzahl_der_Personen_im_Stammbaum
		  ,MH.Stammbaum_verwaltet_von ,MH.Stammbaum_ansehen ,MH.Stammbaumverwalter_kontaktieren ,MH.Anzahl_von_SmartMatches ,MH.Geteilte_gemeinsame_Nachnamen
		  ,MH.Alle_Nachnamen_der_Vorfahren ,MH.Anmerkungen)

SET @Updated = @@ROWCOUNT
	
INSERT [dbo].[MyHeritage]
           ([MyHeritageMatchId]
           ,[KitNr]
           ,[Name]
           ,[Alter]
           ,[Land]
           ,[DNA_Match_kontaktieren]
           ,[DNA_verwaltet_von]
           ,[DNA_Verwalter_kontaktieren]
           ,[Status]
           ,[Voraussichtliche_Verwandtschaft]
           ,[Gesamtlaenge_cM_geteilt]
           ,[Prozent_der_gemeinsamen_DNA]
           ,[Anzahl_gemeinsamer_Segmente]
           ,[Groesstes_Segment_cM]
           ,[DNA_Match_Seite_pruefen]
           ,[Hat_einen_Stammbaum]
           ,[Anzahl_der_Personen_im_Stammbaum]
           ,[Stammbaum_verwaltet_von]
           ,[Stammbaum_ansehen]
           ,[Stammbaumverwalter_kontaktieren]
           ,[Anzahl_von_SmartMatches]
           ,[Geteilte_gemeinsame_Nachnamen]
           ,[Alle_Nachnamen_der_Vorfahren]
           ,[Anmerkungen]
		   ,InsertDate)
     SELECT
           MyHeritageMatchId,
           KitNr,
           Name,
           [Alter],
           Land,
           DNA_Match_kontaktieren,
           DNA_verwaltet_von,
           DNA_Verwalter_kontaktieren,
           Status,
           Voraussichtliche_Verwandtschaft,
           Gesamtlaenge_cM_geteilt,
           Prozent_der_gemeinsamen_DNA,
           Anzahl_gemeinsamer_Segmente,
           Groesstes_Segment_cM,
           DNA_Match_Seite_pruefen,
           Hat_einen_Stammbaum,
           Anzahl_der_Personen_im_Stammbaum,
           Stammbaum_verwaltet_von,
           Stammbaum_ansehen,
           Stammbaumverwalter_kontaktieren,
           Anzahl_von_SmartMatches,
           Geteilte_gemeinsame_Nachnamen,
           Alle_Nachnamen_der_Vorfahren,
           Anmerkungen,
		   @Date
	FROM @Data D
	WHERE NOT EXISTS 
			(SELECT 1 FROM [dbo].[MyHeritage]
				WHERE KitNr = D.KitNr 
					AND MyHeritageMatchId = D.MyHeritageMatchId)

	SET @Inserted = @@ROWCOUNT

	SELECT @Updated Updated, @Inserted Inserted

END
GO
/****** Object:  StoredProcedure [dbo].[InsertUpdateMyHeritageSegments]    Script Date: 13.03.2025 14:43:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[InsertUpdateMyHeritageSegments](@Data MyHeritageSegmentsTable READONLY)
AS
BEGIN
	DECLARE @Updated INT = 0
	DECLARE @Inserted INT= 0
	DECLARE @Date DATETIME = GETDATE()

	-- Kein Update momentan vorgesehen

	INSERT INTO [dbo].[MyHeritageSegments]
           ([MyHeritageMatchId]
           ,[KitNr]
           ,[Start_Position]
           ,[End_Position]
           ,[Chromosom]
           ,[Anfangs_RSID]
           ,[End_RSID]
           ,[Centimorgan]
           ,[SNPs]
           ,[InsertDate])
     SELECT 
           D.MyHeritageMatchId
           ,D.KitNr
           ,D.Start_Position
           ,D.End_Position
           ,D.Chromosom
           ,D.Anfangs_RSID
           ,D.End_RSID
           ,D.Centimorgan
           ,D.SNPs
           ,@Date
	FROM @Data D
	WHERE NOT EXISTS 
			(SELECT 1 FROM [dbo].[MyHeritageSegments]
				WHERE 
				KitNr = D.KitNr AND
				MyHeritageMatchId = D.MyHeritageMatchId AND
				Start_Position = D.Start_Position AND
				End_Position = D.End_Position AND
				Chromosom = D.Chromosom
				)
	
	SET @Inserted = @@ROWCOUNT

	SELECT @Updated Updated, @Inserted Inserted

END
GO
/****** Object:  StoredProcedure [dbo].[InsertUpdateYFull]    Script Date: 13.03.2025 14:43:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[InsertUpdateYFull](@Data YfullTable READONLY)
AS
BEGIN
	DECLARE @Updated INT = 0
	DECLARE @Inserted INT= 0
	DECLARE @Date DATETIME = GETDATE()
	
UPDATE [dbo].[YFull]
   SET 
	   [ID] = D.ID,
	   [KitNr] = D.KitNr,
	   [MRCA_branch] = D.MRCA_branch,
	   [TMRCA_ybp] = D.TMRCA_ybp,
	   [Most_distant_ancestor] = D.Most_distant_ancestor,
	   [Country_of_origin] = D.Country_of_origin,
	   [Terminal_Hg] = D.Terminal_Hg,
	   [Shared_SNPs] = D.Shared_SNPs,
	   [Assumed_shared_SNPs] = D.Assumed_shared_SNPs,
	   [All_shared_SNPs] = D.All_shared_SNPs,
       [UpdateDate] = @Date
	FROM
		@Data D INNER JOIN [dbo].[YFull] YF ON D.KitNr = YF.KitNr AND D.ID = YF.ID AND
		[dbo].[GetYFullCriteriaUpdateCriteria](D.MRCA_branch, D.TMRCA_ybp, D.Most_distant_ancestor, 
			D.Country_of_origin, D.Terminal_Hg, D.Shared_SNPs, D.Assumed_shared_SNPs, D.All_shared_SNPs)
		<> 
		[dbo].[GetYFullCriteriaUpdateCriteria](YF.MRCA_branch, YF.TMRCA_ybp, YF.Most_distant_ancestor, 
			YF.Country_of_origin, YF.Terminal_Hg, YF.Shared_SNPs, YF.Assumed_shared_SNPs, YF.All_shared_SNPs)

SET @Updated = @@ROWCOUNT

INSERT [dbo].[Yfull]
           ([ID]
           ,[KitNr]
           ,[MRCA_branch]
           ,[TMRCA_ybp]
           ,[Most_distant_ancestor]
           ,[Country_of_origin]
           ,[Terminal_Hg]
           ,[Shared_SNPs]
           ,[Assumed_shared_SNPs]
           ,[All_shared_SNPs]
           ,[InsertDate])
SELECT
           [ID]
           ,[KitNr]
           ,[MRCA_branch]
           ,[TMRCA_ybp]
           ,[Most_distant_ancestor]
           ,[Country_of_origin]
           ,[Terminal_Hg]
           ,[Shared_SNPs]
           ,[Assumed_shared_SNPs]
           ,[All_shared_SNPs]
           ,@Date
	FROM @Data D
	WHERE NOT EXISTS 
			(SELECT 1 FROM [dbo].[YFull]
				WHERE ID = D.ID AND KitNr = D.KitNr)

	SET @Inserted = @@ROWCOUNT

	SELECT @Updated Updated, @Inserted Inserted

END
GO
/****** Object:  StoredProcedure [dbo].[IsKitNrAllowed]    Script Date: 13.03.2025 14:43:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[IsKitNrAllowed](@KitNr NVARCHAR(100), @KitTypeId INT, @CompanyId INT)
AS
BEGIN
	DECLARE @IsAllowed BIT

	SELECT @IsAllowed = COUNT(1) FROM Kits 
	WHERE 
		KitNr = @KitNr 
		AND KitTypeId = @KitTypeId
		AND CompanyId = @CompanyId 

	SELECT CAST(@IsAllowed AS BIT)
END
GO
/****** Object:  StoredProcedure [dbo].[SelectCommonMatchesFamilyFinder]    Script Date: 13.03.2025 14:43:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SelectCommonMatchesFamilyFinder](
	@SelectedList  KitNumberTableWithId READONLY, 
	@PagingFrom INT,
	@PageSize INT, 
	@SortAscending BIT,
	@SearchString NVARCHAR(1000),
	@SortColumn NVARCHAR(100))
AS
BEGIN
	SET NOCOUNT ON;

	IF OBJECT_ID('tempdb..#Temp') IS NOT NULL DROP TABLE #Temp

	DECLARE @KitNr NVARCHAR(100)
	DECLARE @Count INT = (SELECT COUNT(1) FROM @SelectedList)

	IF @Count <= 1
	RETURN

	CREATE TABLE #Temp(
		[TblId] int NOT NULL,
		[KitNr] [nvarchar](50) NOT NULL,
		[Full_Name] [nvarchar](200) NOT NULL,
		[First_Name] [nvarchar](4000) NOT NULL,
		[Middle_Name] [nvarchar](4000) NULL,
		[Last_Name] [nvarchar](4000) NOT NULL,
		[Email] [nvarchar](max) NULL,
		[Ancestral_Surnames] [nvarchar](max) NULL,
		[Y_DNA_Haplogroup] [nvarchar](max) NULL,
		[mtDNA_Haplogroup] [nvarchar](max) NULL
	)

	INSERT #Temp
	SELECT 
		TblId,
		ff.[KitNr],
		[Full_Name],
		[First_Name],
		[Middle_Name],
		[Last_Name],
		[Email],
		[Ancestral_Surnames],
		[Y_DNA_Haplogroup],
		[mtDNA_Haplogroup]
	  FROM [dbo].[FamilyFinder] ff
	  INNER JOIN @SelectedList kn ON ff.KitNr = kn.KitNr

	CREATE NONCLUSTERED INDEX ix_tempCIndexAft2 ON #Temp (KitNr) INCLUDE(Full_Name)

	DECLARE @intFlag INT
	SET @intFlag = 1
	WHILE (@intFlag <=@Count)
	BEGIN
		SELECT @KitNr = KitNr FROM @SelectedList WHERE Id = @intFlag
		DELETE
		FROM #Temp
		WHERE Full_Name NOT IN(SELECT Full_Name FROM #Temp WHERE KitNr = @KitNr) 
		SET @intFlag = @intFlag + 1;
	END

	IF @SearchString IS NULL
	BEGIN
		SELECT 
			0 AllCount,
			MIN([TblId]) TblId,
			MIN([KitNr]) KitNr,
			[Full_Name] Full_Name,
			MIN([First_Name]) First_Name,
			MIN([Middle_Name]) Middle_Name,
			MIN([Last_Name]) Last_Name,
			MIN([Email]) Email,
			MIN([Ancestral_Surnames]) Ancestral_Surnames,
			MIN([Y_DNA_Haplogroup]) Y_DNA_Haplogroup,
			MIN([mtDNA_Haplogroup]) mtDNA_Haplogroup
		FROM #Temp t
		GROUP BY Full_Name
		ORDER BY Full_Name
	END
	ELSE
	BEGIN
		SELECT 
			0 AllCount,
			MIN([TblId]) TblId,
			MIN([KitNr]) KitNr,
			[Full_Name] Full_Name,
			MIN([First_Name]) First_Name,
			MIN([Middle_Name]) Middle_Name,
			MIN([Last_Name]) Last_Name,
			MIN([Email]) Email,
			MIN([Ancestral_Surnames]) Ancestral_Surnames,
			MIN([Y_DNA_Haplogroup]) Y_DNA_Haplogroup,
			MIN([mtDNA_Haplogroup]) mtDNA_Haplogroup
		FROM #Temp t
		WHERE 
			t.Full_Name Like '%' + @SearchString +'%' 
			OR Ancestral_Surnames Like '%' + @SearchString  + '%' 
		GROUP BY Full_Name
		ORDER BY Full_Name
	END

	DROP TABLE #Temp
END
GO
/****** Object:  StoredProcedure [dbo].[SelectCommonMatchesMyHeritage]    Script Date: 13.03.2025 14:43:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SelectCommonMatchesMyHeritage](
	@SelectedList  KitNumberTableWithId READONLY, 
	@PagingFrom INT,
	@PageSize INT, 
	@SortAscending BIT,
	@SearchString NVARCHAR(1000),
	@SortColumn NVARCHAR(100))
AS
BEGIN
	SET NOCOUNT ON;

	IF OBJECT_ID('tempdb..#Temp') IS NOT NULL DROP TABLE #Temp

	DECLARE @KitNr NVARCHAR(100)
	DECLARE @Count INT = (SELECT COUNT(1) FROM @SelectedList)
	IF @Count <= 1
	RETURN

	CREATE TABLE #Temp(
		[TblId] int NOT NULL,
		[MyHeritageMatchId] [nvarchar](100) NOT NULL,
		[KitNr] [nvarchar](100) NOT NULL,
		[Name] [nvarchar](200) NOT NULL,
		[Alter] [nvarchar](100) NULL,
		[Land] [nvarchar](100) NULL,
		[DNA_Match_kontaktieren] [nvarchar](max) NULL,
		[DNA_verwaltet_von] [nvarchar](max) NOT NULL,
		[DNA_Verwalter_kontaktieren] [nvarchar](max) NULL,
		[Stammbaum_verwaltet_von] [nvarchar](max) NULL,
		[Stammbaum_ansehen] [nvarchar](max) NULL,
		[Stammbaumverwalter_kontaktieren] [nvarchar](max) NULL,
		[Geteilte_gemeinsame_Nachnamen] [nvarchar](max) NULL,
		[Alle_Nachnamen_der_Vorfahren] [nvarchar](max) NULL
	)

	INSERT #Temp
	SELECT 
		TblId,
		[MyHeritageMatchId],
		mh.[KitNr],
		[Name],
		[Alter],
		[Land],
		[DNA_Match_kontaktieren],
		[DNA_verwaltet_von],
		[DNA_Verwalter_kontaktieren],
		[Stammbaum_verwaltet_von],
		[Stammbaum_ansehen],
		[Stammbaumverwalter_kontaktieren],
		[Geteilte_gemeinsame_Nachnamen],
		[Alle_Nachnamen_der_Vorfahren]
	  FROM [dbo].[MyHeritage] mh
	  INNER JOIN @SelectedList kn ON mh.KitNr = kn.KitNr

	CREATE NONCLUSTERED INDEX ix_tempCIndexAft ON #Temp (KitNr, MyHeritageMatchId) INCLUDE(name) ;

	DECLARE @intFlag INT
	SET @intFlag = 1
	WHILE (@intFlag <=@Count)
	BEGIN
		SELECT @KitNr = KitNr FROM @SelectedList WHERE Id = @intFlag
		DELETE
		FROM #Temp
		WHERE MyHeritageMatchId NOT IN(SELECT MyHeritageMatchId FROM #Temp WHERE KitNr = @KitNr) 
		SET @intFlag = @intFlag + 1;
	END

	IF @SearchString IS NULL
	BEGIN
		SELECT 
			MIN(TblId) TblId,
			0 AllCount,
			[Name],
			MIN([Alter]) [Alter],
			MIN([Land]) [Land],
			MIN([DNA_Match_kontaktieren]) [DNA_Match_kontaktieren],
			MIN([DNA_verwaltet_von]) [DNA_verwaltet_von],
			MIN([DNA_Verwalter_kontaktieren]) DNA_Verwalter_kontaktieren,
			MIN([Stammbaum_verwaltet_von])[Stammbaum_verwaltet_von],
			MIN([Stammbaum_ansehen]) [Stammbaum_ansehen],
			MIN([Stammbaumverwalter_kontaktieren]) [Stammbaumverwalter_kontaktieren],
			MIN([Geteilte_gemeinsame_Nachnamen]) [Geteilte_gemeinsame_Nachnamen],
			MIN([Alle_Nachnamen_der_Vorfahren]) Alle_Nachnamen_der_Vorfahren
		FROM #Temp t
		GROUP BY NAME
		ORDER BY NAME
	END
	ELSE BEGIN
		SELECT 
			MIN(TblId) TblId,
			0 AllCount,
			[Name],
			MIN([Alter]) [Alter],
			MIN([Land]) [Land],
			MIN([DNA_Match_kontaktieren]) [DNA_Match_kontaktieren],
			MIN([DNA_verwaltet_von]) [DNA_verwaltet_von],
			MIN([DNA_Verwalter_kontaktieren]) DNA_Verwalter_kontaktieren,
			MIN([Stammbaum_verwaltet_von])[Stammbaum_verwaltet_von],
			MIN([Stammbaum_ansehen]) [Stammbaum_ansehen],
			MIN([Stammbaumverwalter_kontaktieren]) [Stammbaumverwalter_kontaktieren],
			MIN([Geteilte_gemeinsame_Nachnamen]) [Geteilte_gemeinsame_Nachnamen],
			MIN([Alle_Nachnamen_der_Vorfahren]) Alle_Nachnamen_der_Vorfahren
		FROM #Temp t
		WHERE 
				t.Name Like '%' + @SearchString +'%'  -- ev TODO Name aufteilen  
				OR Geteilte_gemeinsame_Nachnamen Like '%' + @SearchString  + '%' 
				OR Alle_Nachnamen_der_Vorfahren Like '%' + @SearchString  + '%'		
		GROUP BY NAME
		ORDER BY NAME
	END

	DROP TABLE #Temp
END

GO
/****** Object:  StoredProcedure [dbo].[SelectCompanies]    Script Date: 13.03.2025 14:43:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Script for SelectTopNRows command from SSMS  ******/
create PROCEDURE [dbo].[SelectCompanies]
AS
BEGIN
  SELECT [CompanyId] ,[CompanyName]
  FROM [Dna].[dbo].[Companies]
END
GO
/****** Object:  StoredProcedure [dbo].[SelectFamilyFinder]    Script Date: 13.03.2025 14:43:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SelectFamilyFinder](
	@SelectedList  KitNumberTable READONLY, 
	@PagingFrom INT,
	@PageSize INT, 
	@SortAscending BIT,
	@SearchString NVARCHAR(1000),
	@SortColumn NVARCHAR(100))
AS
BEGIN

SET NOCOUNT ON;

;WITH Temp AS
(
	SELECT
		ROW_NUMBER() OVER 
		(
			ORDER BY
				CASE WHEN @SortColumn ='Last_Name' AND @SortAscending= 1 THEN Last_Name ELSE NULL END ASC,
				CASE WHEN @SortColumn ='Last_Name' AND @SortAscending= 0 THEN Last_Name ELSE NULL END DESC,
							
				CASE WHEN @SortColumn ='Match_Date' AND @SortAscending= 1 THEN Match_Date ELSE NULL END ASC,
				CASE WHEN @SortColumn ='Match_Date' AND @SortAscending= 0 THEN Match_Date ELSE NULL END DESC,

				CASE WHEN @SortColumn ='Shared_cM' AND @SortAscending= 1 THEN Shared_cM ELSE NULL END ASC,
				CASE WHEN @SortColumn ='Shared_cM' AND @SortAscending= 0 THEN Shared_cM ELSE NULL END DESC,

				CASE WHEN @SortColumn ='Longest_Block' AND @SortAscending= 1 THEN Longest_Block ELSE NULL END ASC,
				CASE WHEN @SortColumn ='Longest_Block' AND @SortAscending= 0 THEN Longest_Block ELSE NULL END DESC,

				CASE WHEN @SortColumn ='Y_DNA_Haplogroup' AND @SortAscending= 1 THEN Y_DNA_Haplogroup ELSE NULL END ASC,
				CASE WHEN @SortColumn ='Y_DNA_Haplogroup' AND @SortAscending= 0 THEN Y_DNA_Haplogroup ELSE NULL END DESC,

				CASE WHEN @SortColumn ='mtDNA_Haplogroup' AND @SortAscending= 1 THEN mtDNA_Haplogroup ELSE NULL END ASC,
				CASE WHEN @SortColumn ='mtDNA_Haplogroup' AND @SortAscending= 0 THEN mtDNA_Haplogroup ELSE NULL END DESC,

				CASE WHEN @SortColumn ='KitNr' AND @SortAscending= 1 THEN KitNr ELSE NULL END ASC,
				CASE WHEN @SortColumn ='KitNr' AND @SortAscending= 0 THEN KitNr ELSE NULL END DESC,

				CASE WHEN @SortColumn ='Email' AND @SortAscending= 1 THEN Email ELSE NULL END ASC,
				CASE WHEN @SortColumn ='Email' AND @SortAscending= 0 THEN Email ELSE NULL END DESC,

				CASE WHEN @SortColumn ='Relationship_Range' AND @SortAscending= 1 THEN Relationship_Range ELSE NULL END ASC,
				CASE WHEN @SortColumn ='Relationship_Range' AND @SortAscending= 0 THEN Relationship_Range ELSE NULL END DESC,

				CASE WHEN @SortColumn ='Notes' AND @SortAscending= 1 THEN Notes ELSE NULL END ASC,
				CASE WHEN @SortColumn ='Notes' AND @SortAscending= 0 THEN Notes ELSE NULL END DESC,

				CASE WHEN @SortColumn ='First_Name' AND @SortAscending= 1 THEN First_Name ELSE NULL END ASC,
				CASE WHEN @SortColumn ='First_Name' AND @SortAscending= 0 THEN First_Name ELSE NULL END DESC,

				CASE WHEN @SortColumn ='First_Name' AND @SortAscending= 1 THEN First_Name ELSE NULL END ASC,
				CASE WHEN @SortColumn ='First_Name' AND @SortAscending= 0 THEN First_Name ELSE NULL END DESC

		) RowNumber,
		TblId
	FROM
		[dbo].[FamilyFinder] FFIN
	WHERE 
		(FFIN.KitNr IN(SELECT KitNr FROM @SelectedList  WHERE FFIN.KitNr = KitNr) OR (SELECT COUNT(1) FROM @SelectedList ) = 0)
		AND (
			FFIN.Full_Name Like '%' + @SearchString +'%' 
			OR Ancestral_Surnames Like '%' + @SearchString  + '%' 
			OR Notes Like '%' + @SearchString  + '%' 
			OR @SearchString IS NULL
			)
)

SELECT 
	   KitrNrs.[TblId]
      ,[FamilyFinderId]
      ,[KitNr]
      ,[Full_Name]
      ,[First_Name]
      ,[Middle_Name]
      ,[Last_Name]
      ,[Match_Date]
      ,[Relationship_Range]
      ,[Suggested_Relationship]
      ,[Shared_cM]
      ,[Longest_Block]
      ,[Linked_Relationship]
      ,[Email]
      ,[Ancestral_Surnames]
      ,[Y_DNA_Haplogroup]
      ,[mtDNA_Haplogroup]
      ,[Notes]
      ,[Matching_Bucket]
      ,[InsertDate]
      ,[UpdateDate],
		(SELECT Count(1) FROM Temp) AllCount
			FROM
				[dbo].[FamilyFinder] KitrNrs
				INNER JOIN Temp C ON KitrNrs.TblId = C.TblId
			WHERE 
				(@PagingFrom IS NULL OR @PageSize IS NULL) OR RowNumber BETWEEN ((@PagingFrom  - 1) * @PageSize + 1) AND (@PagingFrom  * @PageSize)

			ORDER BY
				CASE WHEN @SortColumn ='Last_Name' AND @SortAscending= 1 THEN Last_Name ELSE NULL END ASC,
				CASE WHEN @SortColumn ='Last_Name' AND @SortAscending= 0 THEN Last_Name ELSE NULL END DESC,
							
				CASE WHEN @SortColumn ='Match_Date' AND @SortAscending= 1 THEN Match_Date ELSE NULL END ASC,
				CASE WHEN @SortColumn ='Match_Date' AND @SortAscending= 0 THEN Match_Date ELSE NULL END DESC,

				CASE WHEN @SortColumn ='Shared_cM' AND @SortAscending= 1 THEN Shared_cM ELSE NULL END ASC,
				CASE WHEN @SortColumn ='Shared_cM' AND @SortAscending= 0 THEN Shared_cM ELSE NULL END DESC,

				CASE WHEN @SortColumn ='Longest_Block' AND @SortAscending= 1 THEN Longest_Block ELSE NULL END ASC,
				CASE WHEN @SortColumn ='Longest_Block' AND @SortAscending= 0 THEN Longest_Block ELSE NULL END DESC,

				CASE WHEN @SortColumn ='Y_DNA_Haplogroup' AND @SortAscending= 1 THEN Y_DNA_Haplogroup ELSE NULL END ASC,
				CASE WHEN @SortColumn ='Y_DNA_Haplogroup' AND @SortAscending= 0 THEN Y_DNA_Haplogroup ELSE NULL END DESC,

				CASE WHEN @SortColumn ='mtDNA_Haplogroup' AND @SortAscending= 1 THEN mtDNA_Haplogroup ELSE NULL END ASC,
				CASE WHEN @SortColumn ='mtDNA_Haplogroup' AND @SortAscending= 0 THEN mtDNA_Haplogroup ELSE NULL END DESC,

				CASE WHEN @SortColumn ='KitNr' AND @SortAscending= 1 THEN KitNr ELSE NULL END ASC,
				CASE WHEN @SortColumn ='KitNr' AND @SortAscending= 0 THEN KitNr ELSE NULL END DESC,

				CASE WHEN @SortColumn ='Email' AND @SortAscending= 1 THEN Email ELSE NULL END ASC,
				CASE WHEN @SortColumn ='Email' AND @SortAscending= 0 THEN Email ELSE NULL END DESC,

				CASE WHEN @SortColumn ='Relationship_Range' AND @SortAscending= 1 THEN Relationship_Range ELSE NULL END ASC,
				CASE WHEN @SortColumn ='Relationship_Range' AND @SortAscending= 0 THEN Relationship_Range ELSE NULL END DESC,

				CASE WHEN @SortColumn ='Notes' AND @SortAscending= 1 THEN Notes ELSE NULL END ASC,
				CASE WHEN @SortColumn ='Notes' AND @SortAscending= 0 THEN Notes ELSE NULL END DESC

END
GO
/****** Object:  StoredProcedure [dbo].[SelectFamilyFinderDetail]    Script Date: 13.03.2025 14:43:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SelectFamilyFinderDetail](@TblId INT)
AS
BEGIN

SET NOCOUNT ON;

SELECT 
	   [TblId]
      ,[FamilyFinderId]
      ,[KitNr]
      ,[Full_Name]
      ,[First_Name]
      ,[Middle_Name]
      ,[Last_Name]
      ,[Match_Date]
      ,[Relationship_Range]
      ,[Suggested_Relationship]
      ,[Shared_cM]
      ,[Longest_Block]
      ,[Linked_Relationship]
      ,[Email]
      ,[Ancestral_Surnames]
      ,[Y_DNA_Haplogroup]
      ,[mtDNA_Haplogroup]
      ,[Notes]
      ,[Matching_Bucket]
      ,[InsertDate]
      ,[UpdateDate]

FROM 
	FamilyFinder
WHERE 
	[TblId] = @TblId
		
END

GO
/****** Object:  StoredProcedure [dbo].[SelectKits]    Script Date: 13.03.2025 14:43:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Script for SelectTopNRows command from SSMS  ******/
CREATE PROCEDURE [dbo].[SelectKits](@CompanyId INT=NULL)
AS
BEGIN
SELECT 
	K.[KitNr]
      ,K.[Name]
      ,K.[FullName]
	  ,C.CompanyName
	  ,C.CompanyId
  FROM [dna].[dbo].[Kits] K
	INNER JOIN Companies C ON K.CompanyId = C.CompanyId
  WHERE 
	C.CompanyId = ISNULL(@CompanyId,C.CompanyId)

END
GO
/****** Object:  StoredProcedure [dbo].[SelectMyHeritageDetail]    Script Date: 13.03.2025 14:43:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SelectMyHeritageDetail](@TblId INT)
AS
BEGIN

SET NOCOUNT ON;

SELECT 
	   [TblId]
      ,[MyHeritageMatchId]
      ,[KitNr]
      ,[Name]
      ,[Alter]
      ,[Land]
      ,[DNA_Match_kontaktieren]
      ,[DNA_verwaltet_von]
      ,[DNA_Verwalter_kontaktieren]
      ,[Status]
      ,[Voraussichtliche_Verwandtschaft]
      ,[Gesamtlaenge_cM_geteilt]
      ,[Prozent_der_gemeinsamen_DNA]
      ,[Anzahl_gemeinsamer_Segmente]
      ,[Groesstes_Segment_cM]
      ,[DNA_Match_Seite_pruefen]
      ,[Hat_einen_Stammbaum]
      ,[Anzahl_der_Personen_im_Stammbaum]
      ,[Stammbaum_verwaltet_von]
      ,[Stammbaum_ansehen]
      ,[Stammbaumverwalter_kontaktieren]
      ,[Anzahl_von_SmartMatches]
      ,[Geteilte_gemeinsame_Nachnamen]
      ,[Alle_Nachnamen_der_Vorfahren]
      ,[Anmerkungen]
      ,[InsertDate]
      ,[UpdateDate]

FROM 
	MyHeritage
WHERE 
	[TblId] = @TblId
		
END

GO
/****** Object:  StoredProcedure [dbo].[SelectYFull]    Script Date: 13.03.2025 14:43:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SelectYFull](
	@SelectedList  KitNumberTableWithId READONLY, 
	@PagingFrom INT,
	@PageSize INT, 
	@SortAscending BIT,
	@SearchString NVARCHAR(1000),
	@SortColumn NVARCHAR(100))
AS
BEGIN
	SET NOCOUNT ON;

	IF OBJECT_ID('tempdb..#Temp') IS NOT NULL DROP TABLE #Temp

	DECLARE @KitNr NVARCHAR(100)
	DECLARE @Count INT = (SELECT COUNT(1) FROM @SelectedList)
	IF @Count <= 1
	RETURN

	CREATE TABLE #Temp(
		[ID] [varchar](50) NOT NULL,
		[KitNr] [nvarchar](100) NOT NULL,
		[MRCA_branch] [varchar](50) NOT NULL,
		[TMRCA_ybp] [varchar](50) NOT NULL,
		[Most_distant_ancestor] [nvarchar](500) NULL,
		[Country_of_origin] [varchar](50) NULL,
		[Terminal_Hg] [varchar](50) NOT NULL,
		[Shared_SNPs] [varchar](max) NOT NULL,
		[Assumed_shared_SNPs] [varchar](max) NOT NULL,
		[All_shared_SNPs] [int] NOT NULL,
		[InsertDate] [datetime] NOT NULL,
		[UpdateDate] [datetime] NULL,
	)

	INSERT #Temp
	SELECT 
		yf.[ID],
		yf.[KitNr],
		[MRCA_branch],
		[TMRCA_ybp],
		[Most_distant_ancestor],
		[Country_of_origin],
		[Terminal_Hg],
		[Shared_SNPs],
		[Assumed_shared_SNPs],
		[All_shared_SNPs],
		[InsertDate],
		[UpdateDate]
	  FROM [dbo].[YFull] yf
	  INNER JOIN @SelectedList kn ON yf.KitNr = kn.KitNr
	  WHERE Most_distant_ancestor IS NOT NULL


	CREATE NONCLUSTERED INDEX ix_tempCIndexAft ON #Temp (KitNr, ID) INCLUDE(Most_distant_ancestor) ;

	DECLARE @intFlag INT
	SET @intFlag = 1
	WHILE (@intFlag <=@Count)
	BEGIN
		SELECT @KitNr = KitNr FROM @SelectedList WHERE Id = @intFlag
		DELETE
		FROM #Temp
		WHERE Most_distant_ancestor NOT IN(SELECT Most_distant_ancestor FROM #Temp WHERE KitNr = @KitNr) 
		SET @intFlag = @intFlag + 1;
	END


	IF @SearchString IS NULL
	BEGIN
		SELECT 
			0 AllCount,
			MIN([Terminal_Hg]) [Terminal_Hg],
			MIN([ID]) [ID],
			MIN([KitNr]) [KitNr],
			MIN([MRCA_branch]) [MRCA_branch],
			MIN([TMRCA_ybp]) [TMRCA_ybp],
			[Most_distant_ancestor],
			MIN([Country_of_origin]) [Country_of_origin],
			MIN([Shared_SNPs]) [Shared_SNPs],
			MIN([Assumed_shared_SNPs]) [Assumed_shared_SNPs],
			MIN([All_shared_SNPs]) [All_shared_SNPs],
			MIN([InsertDate]) [InsertDate],
			MIN([UpdateDate])[UpdateDate]
		FROM #Temp t
		GROUP BY [Most_distant_ancestor]
		ORDER BY [Most_distant_ancestor]
	END
	ELSE BEGIN
		SELECT 
			0 AllCount,
			MIN([Terminal_Hg]) [Terminal_Hg],
			MIN([ID]) [ID],
			MIN([KitNr]) [KitNr],
			MIN([MRCA_branch]) [MRCA_branch],
			MIN([TMRCA_ybp]) [TMRCA_ybp],
			[Most_distant_ancestor],
			MIN([Country_of_origin]) [Country_of_origin],
			MIN([Shared_SNPs]) [Shared_SNPs],
			MIN([Assumed_shared_SNPs]) [Assumed_shared_SNPs],
			MIN([All_shared_SNPs]) [All_shared_SNPs],
			MIN([InsertDate]) [InsertDate],
			MIN([UpdateDate])[UpdateDate]
		FROM #Temp t
		WHERE 
				t.Terminal_Hg Like '%' + @SearchString +'%'  -- ev TODO Name aufteilen  
				OR Most_distant_ancestor Like '%' + @SearchString  + '%' 
				OR Country_of_origin Like '%' + @SearchString  + '%'		
		GROUP BY [Most_distant_ancestor]
		ORDER BY [Most_distant_ancestor]
	END

	DROP TABLE #Temp
END

GO
