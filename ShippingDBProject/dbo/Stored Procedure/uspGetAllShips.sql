-- =============================================
-- Author:      WerqLabs
-- Create Date: 02-22-2023 
-- Description: sp returns list of all the ships from database
-- =============================================
CREATE PROCEDURE [dbo].[uspGetAllShips]
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Select statements for procedure here
	SELECT [ShipId]
      ,[ShipName]
      ,[ShipVelocity]
      ,[CurrentLatitude]
      ,[CurrentLongitude]
	FROM [tblShip]
END
