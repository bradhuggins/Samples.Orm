USE [SampleOrmAppDb]
GO
/****** Object:  Table [dbo].[Addresses]    Script Date: 9/13/2020 4:37:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Addresses](
	[AddressId] [int] IDENTITY(1,1) NOT NULL,
	[AddressLabel] [nvarchar](max) NULL,
	[StreetAddress1] [nvarchar](max) NULL,
	[StreetAddress2] [nvarchar](max) NULL,
	[City] [nvarchar](max) NULL,
	[State] [nvarchar](max) NULL,
	[PostalCode] [nvarchar](max) NULL,
	[PersonId] [int] NULL,
 CONSTRAINT [PK_Addresses] PRIMARY KEY CLUSTERED 
(
	[AddressId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[People]    Script Date: 9/13/2020 4:37:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[People](
	[PersonId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](255) NULL,
	[LastName] [varchar](255) NULL,
 CONSTRAINT [PK_People] PRIMARY KEY CLUSTERED 
(
	[PersonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TelephoneNumbers]    Script Date: 9/13/2020 4:37:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TelephoneNumbers](
	[TelephoneNumberId] [int] IDENTITY(1,1) NOT NULL,
	[TelephoneNumberLabel] [nvarchar](max) NULL,
	[TelephoneNumberValue] [nvarchar](max) NULL,
	[PersonId] [int] NULL,
 CONSTRAINT [PK_TelephoneNumbers] PRIMARY KEY CLUSTERED 
(
	[TelephoneNumberId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Addresses] ON 
GO
INSERT [dbo].[Addresses] ([AddressId], [AddressLabel], [StreetAddress1], [StreetAddress2], [City], [State], [PostalCode], [PersonId]) VALUES (1, N'Dallas City Hall', N'1500 Marilla St', NULL, N'Dallas', N'TX', N'75201', 1)
GO
SET IDENTITY_INSERT [dbo].[Addresses] OFF
GO
SET IDENTITY_INSERT [dbo].[People] ON 
GO
INSERT [dbo].[People] ([PersonId], [FirstName], [LastName]) VALUES (1, N'John', N'Doe')
GO
SET IDENTITY_INSERT [dbo].[People] OFF
GO
SET IDENTITY_INSERT [dbo].[TelephoneNumbers] ON 
GO
INSERT [dbo].[TelephoneNumbers] ([TelephoneNumberId], [TelephoneNumberLabel], [TelephoneNumberValue], [PersonId]) VALUES (1, N'Mobile', N'214-555-1212', 1)
GO
SET IDENTITY_INSERT [dbo].[TelephoneNumbers] OFF
GO
ALTER TABLE [dbo].[Addresses]  WITH CHECK ADD  CONSTRAINT [FK_Addresses_People_PersonId] FOREIGN KEY([PersonId])
REFERENCES [dbo].[People] ([PersonId])
GO
ALTER TABLE [dbo].[Addresses] CHECK CONSTRAINT [FK_Addresses_People_PersonId]
GO
ALTER TABLE [dbo].[TelephoneNumbers]  WITH CHECK ADD  CONSTRAINT [FK_TelephoneNumbers_People_PersonId] FOREIGN KEY([PersonId])
REFERENCES [dbo].[People] ([PersonId])
GO
ALTER TABLE [dbo].[TelephoneNumbers] CHECK CONSTRAINT [FK_TelephoneNumbers_People_PersonId]
GO
/****** Object:  StoredProcedure [dbo].[sp_CreateAddress]    Script Date: 9/13/2020 4:37:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_CreateAddress]
	@PersonId int,
	@AddressLabel nvarchar(max),
	@StreetAddress1 nvarchar(max),
	@StreetAddress2 nvarchar(max),
	@City nvarchar(max),
	@State nvarchar(max),
	@PostalCode nvarchar(max)
AS
BEGIN
	DECLARE @NewId int;
	INSERT INTO [dbo].[Addresses]
            ([AddressLabel]
           ,[StreetAddress1]
           ,[StreetAddress2]
           ,[City]
           ,[State]
           ,[PostalCode]
           ,[PersonId])
     VALUES
             (@AddressLabel
           ,@StreetAddress1
           ,@StreetAddress2
           ,@City
           ,@State
           ,@PostalCode
           ,@PersonId);

	SET @NewId = SCOPE_IDENTITY(); 
	SELECT [AddressId] ,[AddressLabel], [StreetAddress1] ,[StreetAddress2] ,[City] ,[State] ,[PostalCode] ,[PersonId] FROM Addresses (NOLOCK) WHERE AddressId = @NewId
END
GO
/****** Object:  StoredProcedure [dbo].[sp_CreatePerson]    Script Date: 9/13/2020 4:37:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_CreatePerson]
	@FirstName varchar(255),
	@LastName varchar(255)
AS
BEGIN
	DECLARE @NewId int;
	INSERT INTO [dbo].[People]
           ([FirstName]
           ,[LastName])
     VALUES
           (@FirstName,
            @LastName);

	SET @NewId = SCOPE_IDENTITY(); 
	SELECT [PersonId] ,[FirstName],[LastName] FROM People (NOLOCK) WHERE PersonId = @NewId
END
GO
/****** Object:  StoredProcedure [dbo].[sp_CreateTelephoneNumber]    Script Date: 9/13/2020 4:37:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_CreateTelephoneNumber]
	@PersonId int,
	@TelephoneNumberLabel nvarchar(max),
	@TelephoneNumberValue nvarchar(max)
AS
BEGIN
	DECLARE @NewId int;
	INSERT INTO [dbo].[TelephoneNumbers]
           ([TelephoneNumberLabel]
           ,[TelephoneNumberValue]
		   ,[PersonId])
     VALUES
           (@TelephoneNumberLabel,
            @TelephoneNumberValue,
			@PersonId);

	SET @NewId = SCOPE_IDENTITY(); 
	SELECT [TelephoneNumberId] ,[TelephoneNumberLabel],[TelephoneNumberValue], [PersonId] FROM TelephoneNumbers (NOLOCK) WHERE TelephoneNumberId = @NewId
END
GO
/****** Object:  StoredProcedure [dbo].[sp_DeletePerson]    Script Date: 9/13/2020 4:37:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_DeletePerson]
	@PersonId int
AS
BEGIN
	DELETE FROM Addresses WHERE PersonId = @PersonId;
	DELETE FROM TelephoneNumbers WHERE PersonId = @PersonId;
	DELETE FROM People WHERE PersonId = @PersonId;
END
GO
