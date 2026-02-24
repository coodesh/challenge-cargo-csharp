using CargoManagement.Api.DTOs;
using CargoManagement.Api.Models;
using CargoManagement.Api.Repositories.Interfaces;
using CargoManagement.Api.Services.Interfaces;

namespace CargoManagement.Api.Services;

// TODO: Candidato deve implementar este service.
// Use CargoService.cs como referência de padrão.
public class ManifestService : IManifestService
{
    private readonly IManifestRepository _manifestRepository;

    public ManifestService(IManifestRepository manifestRepository)
    {
        _manifestRepository = manifestRepository;
    }

    public Task<IEnumerable<Manifest>> GetAllAsync()
    {
        // TODO: Implementar
        throw new NotImplementedException();
    }

    public Task<Manifest?> GetByIdAsync(int id)
    {
        // TODO: Implementar
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Manifest>> GetByCargoIdAsync(int cargoId)
    {
        // TODO: Implementar
        throw new NotImplementedException();
    }

    public Task<Manifest> CreateAsync(CreateManifestDto dto)
    {
        // TODO: Implementar - mapear DTO para entidade e salvar
        throw new NotImplementedException();
    }

    public Task<Manifest?> UpdateAsync(int id, CreateManifestDto dto)
    {
        // TODO: Implementar
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(int id)
    {
        // TODO: Implementar
        throw new NotImplementedException();
    }
}
