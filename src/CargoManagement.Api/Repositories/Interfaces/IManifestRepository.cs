using CargoManagement.Api.Models;

namespace CargoManagement.Api.Repositories.Interfaces;

public interface IManifestRepository
{
    Task<IEnumerable<Manifest>> GetAllAsync();
    Task<Manifest?> GetByIdAsync(int id);
    Task<IEnumerable<Manifest>> GetByCargoIdAsync(int cargoId);
    Task<Manifest> CreateAsync(Manifest manifest);
    Task<Manifest> UpdateAsync(Manifest manifest);
    Task<bool> DeleteAsync(int id);
}
