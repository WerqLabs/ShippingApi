namespace ShippingApiApp.Controllers
{
    [Route("/v1/api/[controller]")]
    [ApiController]
    [AuthFilter]
    public class ShippingApiController : ControllerBase
    {  /// <summary>
       /// Create Object for Interface IShipRepository
       /// </summary>
        private readonly IShipRepository _IShipRepository;
        /// <summary>
        /// Inject IShipRepository in _IShipRepository
        /// </summary>
        /// <param name="shipRepository">Interface of shipRepository</param>
        public ShippingApiController(IShipRepository shipRepository)
        {
            _IShipRepository = shipRepository;
        }

        /// <summary>
        /// List All the ships
        /// </summary>
        /// <returns>Get the list of ships in the database</returns>

        [HttpGet("GetAllShipList")]
        [SwaggerHeader("", "", "", true)]
        public IActionResult GetAllShipList()
        {
            List<ShipModel> lShips = _IShipRepository.GetAllShipList();
            return Ok(lShips);
        }

        /// <summary>
        /// Add the Ship
        /// </summary>
        /// <param name="oShipModel"> Json Model with parameters as
        /// ShipName = Name Of the Ship should be max 100 characters
        /// Longitude = Coordinate of Ship Logitude should be in decimal
        /// Latitude = Coordinate of Ship Latitude should be in decimal
        /// Velocity = Velocity of the ship should be in decimal
        ///</param>
        /// <returns>returns Ship Unique Id else return error detail</returns>
        [HttpPost("AddShip")]
        [SwaggerHeader("", "", "", true)]
        public IActionResult AddShip([FromBody] AddShipRequestModel oShipModel)
        {
            if (oShipModel != null)
            {
                if (oShipModel.Velocity == 0)
                {
                    return BadRequest((ErrorResponseModel)"Velocity should be greater than 0.");
                }
                else
                {
                    AddShipResponseModel oReponse = _IShipRepository.AddShip(oShipModel);
                    if (oReponse != null && !string.IsNullOrEmpty(oReponse.ErrorMessage))
                    {
                        return BadRequest((ErrorResponseModel)oReponse.ErrorMessage);
                    }
                    return Ok(oReponse);
                }
            }
            else
            {
                return BadRequest(400);
            }
        }
 
        
        /// <summary>
        /// Update Ship Velocity
        /// </summary>
        /// <param name="oVelocityModel"> Json Model with parameters as
        /// ShipId = Existing Ship Id datatype int;
        /// Velocity = Speed of the Ship datatype decimal
        /// </param>
        /// <returns>return 204 if success or Error detail returns 400</returns>
        [HttpPut("UpdateVelocityOfShip")]
        [SwaggerHeader("", "", "", true)]
        public IActionResult UpdateVelocityOfShip([FromBody]UpdateVelocityRequestModel objVelocityModel)
        {
            if (objVelocityModel != null)
            {
                if (objVelocityModel.ShipId == 0)
                {
                    return BadRequest((ErrorResponseModel)"Ship Id Cannot 0");
                }
                string sReturn = _IShipRepository.UpdateVelocityOfShip(objVelocityModel);
                if (!string.IsNullOrEmpty(sReturn))
                {
                    return BadRequest((ErrorResponseModel)sReturn);
                }
                return StatusCode(204);
            }
            else
            {
                return BadRequest(400);
            }

        }
  
        /// <summary>
        /// Get Closest Port To Ship with ETA
        /// </summary>
        /// <param name="iShipId">Ship Unique Id</param>
        /// <returns>Returns Closest port to ship with ETA</returns>
        [HttpGet("GetClosestPortToShipWithETA")]
        [SwaggerHeader("", "", "", true)]
        public IActionResult GetClosestPortToShipWithETA(int iShipId)
        {
            if (iShipId == 0)
            {
                return BadRequest((ErrorResponseModel)"Ship Id Cannot 0");
            }
            ShipETAResponseModel objShipETAResponseModel = _IShipRepository.GetClosestPortToShipWithETA(iShipId);
            if (objShipETAResponseModel != null && !string.IsNullOrEmpty(objShipETAResponseModel.ErrorMessage))
            {
                return BadRequest((ErrorResponseModel)"Please Provider valid Ship Id, Record Not Found");
            }
            else
            {
                return Ok(objShipETAResponseModel);
            }

        }
    }
}
