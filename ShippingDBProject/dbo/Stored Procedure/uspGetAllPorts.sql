-- =============================================
-- Author:       WerqLabs
-- Create Date: 02-22-2023 
-- Description: Sp returns list of all the ports from database
-- =============================================
CREATE PROCEDURE [dbo].[uspGetAllPorts]
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    --Select statements for procedure here
    SELECT [PortId]
      ,[PortName]
      ,[Longitude]
      ,[Latitude]
	FROM [tblPortMaster];
END
