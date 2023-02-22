
namespace ShippingApiAppModel
{
    /// <summary>
    /// Update Velocity request  model
    /// </summary>
    public class UpdateVelocityRequestModel
    {
        [Required]
        public int? ShipId { get; set; }
        [Required]
        public double? Velocity { get; set; }
    }
}
