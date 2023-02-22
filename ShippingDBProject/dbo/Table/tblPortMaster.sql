CREATE TABLE [dbo].[tblPortMaster](
	[PortId] [int] IDENTITY(1,1) NOT NULL,
	[PortName] [varchar](100) NOT NULL,
	[Longitude] [decimal](9, 6) NOT NULL,
	[Latitude] [decimal](9, 6) NOT NULL,
 CONSTRAINT [PK_PortId] PRIMARY KEY CLUSTERED ([PortId] ASC)
 );