using CargoManagement.Api.DTOs;
using CargoManagement.Api.Repositories.Interfaces;

namespace CargoManagement.Api.Repositories;

// TODO: Candidato deve implementar este repository usando Dapper para chamar
// a stored procedure 'buscar_cargas_por_periodo'.
//
// Dica: Injete IConfiguration ou a connection string via DI para criar a conexão.
// Use Npgsql.NpgsqlConnection como IDbConnection.
//
// Exemplo de uso do Dapper com stored procedure:
//   using var connection = new NpgsqlConnection(_connectionString);
//   var result = await connection.QueryAsync<CargoDto>(
//       "SELECT * FROM buscar_cargas_por_periodo(@data_inicio, @data_fim)",
//       new { data_inicio = startDate, data_fim = endDate });
public class CargoQueryRepository : ICargoQueryRepository
{
    private readonly string _connectionString;

    public CargoQueryRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection")
            ?? throw new ArgumentNullException("Connection string 'DefaultConnection' not found.");
    }

    public Task<IEnumerable<CargoDto>> GetByPeriodAsync(DateTime startDate, DateTime endDate)
    {
        // TODO: Implementar usando Dapper + stored procedure buscar_cargas_por_periodo
        throw new NotImplementedException();
    }
}
