using CargoManagement.Api.DTOs;
using CargoManagement.Api.Models;

namespace CargoManagement.Api.Services.Interfaces;

public interface IManifestService
{
    Task<IEnumerable<Manifest>> GetAllAsync();
    Task<Manifest?> GetByIdAsync(int id);
    Task<IEnumerable<Manifest>> GetByCargoIdAsync(int cargoId);
    Task<Manifest> CreateAsync(CreateManifestDto dto);
    Task<Manifest?> UpdateAsync(int id, CreateManifestDto dto);
    Task<bool> DeleteAsync(int id);
}
