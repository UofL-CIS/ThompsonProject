using Dapper;

using MySql.Data.MySqlClient;

namespace ThompsonProject.WebApi.Repos.Abstractions;

public abstract class BaseDal
{
    protected readonly MySqlConnection Connection;

    public BaseDal(IConfiguration configuration)
    {
        Connection = new MySqlConnection(configuration.GetConnectionString("Thompson"));
    }

    protected Task<IEnumerable<T>> ExecuteQueryStoredProcedureAsync<T>(string procedureName, object procedureValues)
    {
        return Connection.QueryAsync<T>(procedureName,
            procedureValues,
            commandType: System.Data.CommandType.StoredProcedure);
    }

    protected Task ExecuteStoredProcedureAsync(string procedureName, object procedureValues)
    {
        return Connection.ExecuteAsync(procedureName,
            procedureValues,
            commandType: System.Data.CommandType.StoredProcedure);
    }
}