namespace ShippingApiAppDataManagers.IDataManager
{
    public interface IShipRepository
    {
        public List<ShipModel> GetAllShipList();
        public AddShipResponseModel AddShip(AddShipRequestModel oShip);
        string UpdateVelocityOfShip(UpdateVelocityRequestModel oVelocityModel);
        ShipETAResponseModel GetClosestPortToShipWithETA(int iShipId);
    }
}
