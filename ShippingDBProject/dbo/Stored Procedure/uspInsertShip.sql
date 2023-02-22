-- =============================================
-- Author:      WerqLabs
-- Create Date: 02-22-2023 
-- Description: sp inserts the ship details in the database
-- =============================================
CREATE PROCEDURE [dbo].[uspInsertShip](
	@ShipName_In VARCHAR(100),
	@ShipVelocity_In DECIMAL(5,2),
	@Latitude_In DECIMAL(9,6),
	@Longitude_In DECIMAL(9,6),
	@ErrorMsg_Out VARCHAR(100) OUTPUT,
	@Identity_Out INT OUTPUT
)
AS
BEGIN
	IF NOT EXISTS (SELECT * FROM tblShip WHERE ShipName = @ShipName_In)
	BEGIN
		INSERT INTO tblShip(ShipName,ShipVelocity,CurrentLatitude,CurrentLongitude)
		VALUES (@ShipName_In,@ShipVelocity_In,@Latitude_In,@Longitude_In)
		select @Identity_Out=@@IDENTITY
	END
	ELSE
	BEGIN
		SET @ErrorMsg_Out = 'Ship Name Already Exists.';
		SET @Identity_Out =0;
	END
END