using CargoManagement.Api.Models;

namespace CargoManagement.Api.Repositories.Interfaces;

public interface ICargoRepository
{
    Task<(List<Cargo> Items, int TotalCount)> GetAllAsync(int page, int pageSize);
    Task<Cargo?> GetByIdAsync(int id);
    Task<Cargo> CreateAsync(Cargo cargo);
    Task<Cargo> UpdateAsync(Cargo cargo);
    Task<bool> DeleteAsync(int id);
}
