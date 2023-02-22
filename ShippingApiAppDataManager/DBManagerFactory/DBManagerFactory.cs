namespace ShippingApiAppDataManagers.DBManagerFactory
{
    /// <summary>
    /// Creates the object of DBManager
    /// </summary>
    /// <param name="connectionString"> connection string of database
    /// </param>
    /// <returns>this returns object of class DBManager </returns>
    public class DBManagerFactory
    {
        public IDBManager GetDBManager(string connectionString)
        {
            DbConnection dbconn = new SqlConnection(connectionString);
            return new DBManager(dbconn);
        }
    }
}
