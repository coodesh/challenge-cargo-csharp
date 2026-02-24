using CargoManagement.Api.DTOs;
using CargoManagement.Api.Models;
using CargoManagement.Api.Repositories.Interfaces;
using CargoManagement.Api.Services.Interfaces;

namespace CargoManagement.Api.Services;

public class CargoService : ICargoService
{
    private readonly ICargoRepository _cargoRepository;
    private readonly ICargoQueryRepository _cargoQueryRepository;

    public CargoService(ICargoRepository cargoRepository, ICargoQueryRepository cargoQueryRepository)
    {
        _cargoRepository = cargoRepository;
        _cargoQueryRepository = cargoQueryRepository;
    }

    public async Task<PagedResult<CargoDto>> GetAllAsync(int page, int pageSize)
    {
        var (items, totalCount) = await _cargoRepository.GetAllAsync(page, pageSize);

        // BUG INTENCIONAL: N+1 - Iterando sobre cada cargo para contar containers
        // ao invés de usar Include() no repository para carregar em uma única query.
        // O candidato deve identificar e corrigir este problema.
        var dtos = items.Select(c => new CargoDto
        {
            Id = c.Id,
            Numero = c.Numero,
            Tipo = c.Tipo,
            Peso = c.Peso,
            Origem = c.Origem,
            Destino = c.Destino,
            Status = c.Status,
            DataRegistro = c.DataRegistro,
            TotalContainers = c.Containers.Count // N+1: Containers não foi carregado via Include
        }).ToList();

        return new PagedResult<CargoDto>
        {
            Items = dtos,
            TotalCount = totalCount,
            Page = page,
            PageSize = pageSize
        };
    }

    public async Task<Cargo?> GetByIdAsync(int id)
    {
        return await _cargoRepository.GetByIdAsync(id);
    }

    public async Task<Cargo> CreateAsync(CreateCargoDto dto)
    {
        var cargo = new Cargo
        {
            Numero = dto.Numero,
            Tipo = dto.Tipo,
            Peso = dto.Peso,
            Origem = dto.Origem,
            Destino = dto.Destino,
            Status = dto.Status,
            DataRegistro = DateTime.UtcNow
        };

        return await _cargoRepository.CreateAsync(cargo);
    }

    public async Task<Cargo?> UpdateAsync(int id, CreateCargoDto dto)
    {
        var cargo = await _cargoRepository.GetByIdAsync(id);
        if (cargo is null) return null;

        cargo.Numero = dto.Numero;
        cargo.Tipo = dto.Tipo;
        cargo.Peso = dto.Peso;
        cargo.Origem = dto.Origem;
        cargo.Destino = dto.Destino;
        cargo.Status = dto.Status;

        return await _cargoRepository.UpdateAsync(cargo);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _cargoRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<CargoDto>> GetByPeriodAsync(DateTime startDate, DateTime endDate)
    {
        return await _cargoQueryRepository.GetByPeriodAsync(startDate, endDate);
    }
}
