namespace ShippingApiAppModel
{
    /// <summary>
    /// Add Ship Request Model
    /// </summary>
    public class AddShipRequestModel
    {
            [Required, RegularExpression(@"^[A-Za-z0-9 _]*[A-Za-z0-9][A-Za-z0-9 _]*$", ErrorMessage = "It should only contain letters and numbers, special characters are not allowed.")]
            public string ShipName { get; set; }
            [Range(-90, 90, ErrorMessage = "Latitude should be between -90 and 90 range")]
            [Required(ErrorMessage = "Latitude cannot be empty or null, Latitude should be between -90 and 90 range")]
            public double? Latitude { get; set; }
            [Range(-180, 180, ErrorMessage = "Longitude should be between -180 and 180 range")]
            [Required(ErrorMessage = "Longitude cannot be empty or null, Longitude should be between -180 and 180 range")]
            public double? Longitude { get; set; }
            [Required]
            public double? Velocity { get; set; }
      
    }
}