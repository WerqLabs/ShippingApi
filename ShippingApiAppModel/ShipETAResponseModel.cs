
namespace ShippingApiAppModel
{
    /// <summary>
    /// Ship ETA response model
    /// </summary>
    public class ShipETAResponseModel
    {
        public string ShipName { get; set; }
        public double Velocity { get; set; }
        public string PortName { get; set; }       
        public double Distance { get; set; }
        public string ETA { get; set; }
        public string ErrorMessage { get; set; }

    }
}
