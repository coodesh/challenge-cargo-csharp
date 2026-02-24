using CargoManagement.Api.Data;
using CargoManagement.Api.Models;
using CargoManagement.Api.Repositories.Interfaces;

namespace CargoManagement.Api.Repositories;

// TODO: Candidato deve implementar este repository usando Entity Framework Core.
// Use CargoRepository.cs como referência de padrão.
public class ManifestRepository : IManifestRepository
{
    private readonly CargoDbContext _context;

    public ManifestRepository(CargoDbContext context)
    {
        _context = context;
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

    public Task<Manifest> CreateAsync(Manifest manifest)
    {
        // TODO: Implementar
        throw new NotImplementedException();
    }

    public Task<Manifest> UpdateAsync(Manifest manifest)
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
