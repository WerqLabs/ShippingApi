CREATE TABLE [dbo].[tblShip](
	[ShipId] [int] IDENTITY(1,1) NOT NULL,
	[ShipName] [varchar](100) NOT NULL,
	[ShipVelocity] [decimal](5, 2) NOT NULL,
	[CurrentLatitude] [decimal](9, 6) NOT NULL,
	[CurrentLongitude] [decimal](9, 6) NOT NULL,
	CONSTRAINT [PK_ShipId] PRIMARY KEY CLUSTERED ([ShipId] ASC)
);