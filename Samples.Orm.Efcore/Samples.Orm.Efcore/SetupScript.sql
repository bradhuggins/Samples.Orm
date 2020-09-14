USE [SampleOrmAppDb]
GO
/****** Object:  Table [dbo].[Addresses]    Script Date: 9/13/2020 4:37:47 PM ******/
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
