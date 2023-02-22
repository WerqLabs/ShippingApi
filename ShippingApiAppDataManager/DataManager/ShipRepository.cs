namespace ShippingApiAppDataManagers.DataManager
{
    public class ShipRepository: IShipRepository
    { 
        readonly IDBManager _IDBManager;
        readonly IShipBAL _shipBAL;

        public ShipRepository(IDBManager dbmanager, IShipBAL shipBAL)
        {           
            _IDBManager = dbmanager;
            _shipBAL = shipBAL;
        }

        /// <summary>
        /// Get all the ports
        /// </summary>
        /// <returns>Get the list of ports</returns>
        private List<PortModel> GetAllPortList()
        {
            List<PortModel> lPortModel = new List<PortModel>();
            _IDBManager.InitDbCommand("uspGetAllPorts", CommandType.StoredProcedure);
            DataTable dtShowAllShips = _IDBManager.ExecuteDataTable();
            foreach (DataRow row in dtShowAllShips.Rows)
            {
                lPortModel.Add(new PortModel()
                {
                    PortName = row["PortName"].ToString(),
                    Latitude = Convert.ToDouble(row["Latitude"]),
                    Longitude = Convert.ToDouble(row["Longitude"])
                });
            }
            return lPortModel;


        }

        /// <summary>
        /// Get all the ships
        /// </summary>
        /// <returns>Get the list of ships</returns>
        public List<ShipModel> GetAllShipList()
        {
            List<ShipModel> lShipModel = new List<ShipModel>();
            _IDBManager.InitDbCommand("uspGetAllShips", CommandType.StoredProcedure);
            DataTable dtShowAllShips = _IDBManager.ExecuteDataTable();
            foreach (DataRow row in dtShowAllShips.Rows)
            {
                lShipModel.Add(new ShipModel()
                {
                    ShipId = Convert.ToInt32(row["ShipId"].ToString()),
                    ShipName = row["ShipName"].ToString(),
                    Latitude = Convert.ToDouble(row["CurrentLatitude"]),
                    Longitude = Convert.ToDouble(row["CurrentLongitude"]),
                    Velocity=Convert.ToDouble(row["ShipVelocity"])

                });
            }
            return lShipModel;


        }

        /// <summary>
        /// Add Ship details into Database
        /// </summary>
        /// <returns>Get ship if validation is successfull or error message if there is some error in validation.</returns>
        public AddShipResponseModel AddShip(AddShipRequestModel oShip)
        {
            _IDBManager.InitDbCommand("uspInsertShip", CommandType.StoredProcedure);
            _IDBManager.AddCMDParam("@ShipName_In", oShip.ShipName);
            _IDBManager.AddCMDParam("@ShipVelocity_In", oShip.Velocity);
            _IDBManager.AddCMDParam("@Latitude_In", oShip.Latitude);
            _IDBManager.AddCMDParam("@Longitude_In", oShip.Longitude);
            _IDBManager.AddCMDOutParam("@ErrorMsg_Out", DbType.String, 100);
            _IDBManager.AddCMDOutParam("@Identity_Out", DbType.Int32);
            _IDBManager.ExecuteNonQuery();
            string sError = _IDBManager.GetOutParam<string>("@ErrorMsg_Out");
            int iIdentity = _IDBManager.GetOutParam<Int32>("@Identity_Out");
            AddShipResponseModel oResponse = new AddShipResponseModel()
            {
                ErrorMessage = sError,
                ShipId = iIdentity
            };
            return oResponse;
        }

        /// <summary>
        /// Update Ship Velocity  
        /// </summary>
        /// <returns>Error if shipid does not exists in database.</returns>
        public string UpdateVelocityOfShip(UpdateVelocityRequestModel oVelocityModel)
        {
            _IDBManager.InitDbCommand("uspUpdateShipVelocity", CommandType.StoredProcedure);
            _IDBManager.AddCMDParam("@ShipId_In", oVelocityModel.ShipId);
            _IDBManager.AddCMDParam("@ShipVelocity_In", oVelocityModel.Velocity);
            _IDBManager.AddCMDOutParam("@ErrorMsg_Out", DbType.String, 1000);
            _IDBManager.ExecuteNonQuery();
            string sResponse = _IDBManager.GetOutParam<string>("@ErrorMsg_Out");
            return sResponse;
        }

        /// <summary>
        /// Get closet port and ETA
        /// </summary>
        /// <returns>Get closet port from the ship and estimated time to reached at that port.</returns>
        public ShipETAResponseModel GetClosestPortToShipWithETA(int iShipId)
        {
            ShipETAResponseModel objShipETAResponseModel = new ShipETAResponseModel();
            ShipModel objShipModel = GetShipDetail( iShipId);
            if (objShipModel != null)
            {
                List<PortModel> portModels = GetAllPortList();
                objShipETAResponseModel = _shipBAL.GetClosestPortToShipWithETA(objShipModel, portModels);
            }
            else
            {
                objShipETAResponseModel.ErrorMessage = "Please Provider valid Ship Id, Record Not Found";
            }

            return objShipETAResponseModel;
        }

        /// <summary>
        /// Get Ship Details
        /// </summary>
        /// <returns>Get ship details from database.</returns>
        private ShipModel GetShipDetail(int iShipId)
        {
            ShipModel? oShipModel = null;
            _IDBManager.InitDbCommand("uspGetShipDetails", CommandType.StoredProcedure);
            _IDBManager.AddCMDParam("@ShipId_In", iShipId);
            DataTable dtShipDetail = _IDBManager.ExecuteDataTable();
            if (dtShipDetail != null && dtShipDetail.Rows.Count > 0)
            {
                DataRow row = dtShipDetail.Rows[0];
                oShipModel = new ShipModel()
                {
                    Latitude = Convert.ToDouble(row["CurrentLatitude"]),
                    Longitude = Convert.ToDouble(row["CurrentLongitude"]),
                    ShipName = Convert.ToString(row["ShipName"]),
                    Velocity = Convert.ToDouble(row["ShipVelocity"])
                };
            }
            return oShipModel;
        }



    }
}
