namespace ShippingApiAppDataManagers.IBAL
{
    public interface IShipBAL
    {
        public ShipETAResponseModel GetClosestPortToShipWithETA(ShipModel objShipModel, List<PortModel> portModels);
    }
}
