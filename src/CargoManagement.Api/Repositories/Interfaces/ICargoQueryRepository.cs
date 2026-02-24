using CargoManagement.Api.DTOs;

namespace CargoManagement.Api.Repositories.Interfaces;

public interface ICargoQueryRepository
{
    Task<IEnumerable<CargoDto>> GetByPeriodAsync(DateTime startDate, DateTime endDate);
}
