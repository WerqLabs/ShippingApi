
namespace ShippingApiAppModel
{
    /// <summary>
    /// Ship model
    /// </summary>
    public class ShipModel
    {
        public int ShipId { get; set; }
        public string ShipName { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public double Velocity { get; set; }
    }
}
