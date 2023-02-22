namespace ShippingApiAppDataManagers.BAL
{
    /// <summary>
    /// Ship Business Logic 
    /// </summary>
    public class ShipBAL: IShipBAL
    {
          /// <summary>
         /// Get closet port and ETA
         /// </summary>
         /// <returns>Get closet port from the ship and estimated time to reached at that port.</returns>
        public ShipETAResponseModel GetClosestPortToShipWithETA(ShipModel objShipModel, List<PortModel> lPortModel)
        {
            ShipETAResponseModel objETAToPortResponseModel = new ShipETAResponseModel();
            List<PortWithMinDistanceFromShipModel> lPortWithDistancesFromShipModel = new List<PortWithMinDistanceFromShipModel>();
            double dDistance = 0.0;

            //calculate distance of each port from the ship
            foreach (PortModel objPortModel in lPortModel)
            {
                dDistance = CalculateDistanceBetweenPortAndShip(objShipModel.Latitude, objShipModel.Longitude, objPortModel.Latitude, objPortModel.Longitude);
                PortWithMinDistanceFromShipModel objPortWithDistancesFromShipModel =
                    new PortWithMinDistanceFromShipModel
                    {
                        PortName = objPortModel.PortName,
                        DistinceFromShip = dDistance

                    };
                lPortWithDistancesFromShipModel.Add(objPortWithDistancesFromShipModel);
            }

            //Get Port details which is at minimum distance from ship
            PortWithMinDistanceFromShipModel objModel = GetClosetPortFromShip(lPortWithDistancesFromShipModel);

            //Calculate ETA of the ship to the closest port
            objETAToPortResponseModel = GetClosestPortToShipWithETA(objModel, objShipModel);

            return objETAToPortResponseModel;
        }

        /// <summary>
        /// function to calculate the distance between two locations in km using Haversine formula
        /// </summary>
        /// <param name="latShip">Latitude Ship</param>
        /// <param name="lonShip">Longitude Ship</param>
        /// <param name="latPort">Latitude Port</param>
        /// <param name="lonPort">Longitude Port</param>
        /// <returns></returns>
        private double CalculateDistanceBetweenPortAndShip(double latShip, double lonShip, double latPort, double lonPort)
        {

            int R = 6371; //# radius of the Earth in kilometers
            double dlat = Deg2Rad(Convert.ToDecimal(latShip) - Convert.ToDecimal(latPort));
            double dlon = Deg2Rad(Convert.ToDecimal(lonShip) - Convert.ToDecimal(lonPort));
            double a = (Math.Sin(dlat / 2) * Math.Sin(dlat / 2) +
                        Math.Cos(Deg2Rad(Convert.ToDecimal(latPort))) * Math.Cos(Deg2Rad(Convert.ToDecimal(latShip)))
                        * Math.Sin(dlon / 2) * Math.Sin(dlon / 2));
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            double d = R * c;
            return d * 0.539957;
        }

        /// <summary>
        /// function to return closest port from the ship
        /// </summary>
        /// <param name="lPortWithDistancesFromShipModel">List of Ports</param>
        /// <returns></returns>
        private PortWithMinDistanceFromShipModel GetClosetPortFromShip(List<PortWithMinDistanceFromShipModel> lPortWithDistancesFromShipModel)
        {
            PortWithMinDistanceFromShipModel objModel = lPortWithDistancesFromShipModel.OrderBy(m => m.DistinceFromShip).First();
            return objModel;
        }

        /// <summary>
        /// function gets closest port of the Ship
        /// </summary>
        /// <param name="objMimDistnacePort">Port with minium distance from ship</param>
        /// <param name="objShipModel">Ships Model</param>
        /// <returns></returns>
        private ShipETAResponseModel GetClosestPortToShipWithETA(PortWithMinDistanceFromShipModel objMimDistnacePort, ShipModel objShipModel)
        {
            double ETAOfShip = objMimDistnacePort.DistinceFromShip / objShipModel.Velocity;
            

            ShipETAResponseModel objShipETAResponseModel = new ShipETAResponseModel()
            {
                ShipName = objShipModel.ShipName,
                Velocity = objShipModel.Velocity,
                ETA = ConvertTimeSpanETAToStringETA(ETAOfShip),
                PortName = objMimDistnacePort.PortName,
                Distance = objMimDistnacePort.DistinceFromShip
            };
            return objShipETAResponseModel;
        }
        /// <summary>
        /// Calculator
        /// </summary>
        /// <param name="deg"></param>
        /// <returns></returns>
        double Deg2Rad(decimal deg)
        {
            return Convert.ToDouble(deg) * (Math.PI / 180);
        }
        /// <summary>
        /// ETA Calculator
        /// </summary>
        /// <param name="ETA"></param>
        /// <returns></returns>
        public string ConvertTimeSpanETAToStringETA(double ETA)
        {
            TimeSpan t = TimeSpan.FromHours(ETA);
            int day = t.Days;
            int hour = t.Hours;
            double days = t.TotalMinutes / 60 / 24;
            double hours = (t.TotalMinutes - days * 24 * 60) / 60;

            if (Convert.ToInt32(t.Days) > 0)
            {
                return string.Format("{0:D2} days {1:D2}h:{2:D2}m", Convert.ToInt32(t.Days), Convert.ToInt32(t.Hours),
                            t.Minutes);
            }
            else
            {
                return string.Format("{0:D2}h:{1:D2}m",
                          t.Hours,
                          t.Minutes);
            }
        }
    }
}
