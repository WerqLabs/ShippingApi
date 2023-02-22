-- =============================================
-- Author:      WerqLabs
-- Create Date: 02-22-2023 
-- Description: sp updates the ship details in the database
-- =============================================
CREATE PROCEDURE [dbo].[uspUpdateShipVelocity]
(
    -- Add the parameters for the stored procedure here
	@ShipId_In INT ,
	@ShipVelocity_In DECIMAL(5, 2),
	@ErrorMsg_Out VARCHAR(100) OUTPUT
)
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON
	IF EXISTS (SELECT ShipId FROM tblShip WHERE ShipId = @ShipId_In)
	BEGIN
			UPDATE tblShip 
			SET ShipVelocity = @ShipVelocity_In
			WHERE ShipId = @ShipId_In;
	END
	ELSE
	BEGIN
		SET @ErrorMsg_Out = 'Invalid Ship Id.';
	END
    -- Insert/Update statements for procedure here
   
END