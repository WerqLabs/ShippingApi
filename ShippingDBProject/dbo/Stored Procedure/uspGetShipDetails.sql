-- =============================================
-- Author:      WerqLabs
-- Create Date: 02-22-2023
-- Description: sp returns the ship detail based on the ship id from database
-- =============================================
CREATE PROCEDURE [dbo].[uspGetShipDetails]
(
    -- Add the parameters for the stored procedure here
    @ShipId_In INT
)
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Insert statements for procedure here
    SELECT [ShipId]
      ,[ShipName]
      ,[ShipVelocity]
      ,[CurrentLatitude]
      ,[CurrentLongitude]
	FROM [tblShip] 
	where [ShipId] = @ShipId_In;
END