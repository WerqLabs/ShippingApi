namespace ShippingApiAppDataManagers.IDataManager
{
    public interface IDBManager
    {
        DataManager.DBManager InitDbCommand(string cmd);
        DataManager.DBManager InitDbCommand(string cmd, CommandType cmdtype);
        DataManager.DBManager AddCMDParam(string parametername, object value);
        DataManager.DBManager AddCMDParam(string parametername, object value, DbType dbtype);
        DataManager.DBManager AddCMDOutParam(string parametername, DbType dbtype, int iSize = 0);

        T GetOutParam<T>(string paramname);
        DataTable ExecuteDataTable();
        DataSet ExecuteDataSet();

        object? ExecuteScalar();

        Task<object?> ExecuteScalarAsync();
        int ExecuteNonQuery();
        Task<int> ExecuteNonQueryAsync();
    }
}
