using CargoManagement.Api.DTOs;
using CargoManagement.Api.Models;

namespace CargoManagement.Api.Services.Interfaces;

public interface ICargoService
{
    Task<PagedResult<CargoDto>> GetAllAsync(int page, int pageSize);
    Task<Cargo?> GetByIdAsync(int id);
    Task<Cargo> CreateAsync(CreateCargoDto dto);
    Task<Cargo?> UpdateAsync(int id, CreateCargoDto dto);
    Task<bool> DeleteAsync(int id);
    Task<IEnumerable<CargoDto>> GetByPeriodAsync(DateTime startDate, DateTime endDate);
}
