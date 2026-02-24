using CargoManagement.Api.Data;
using CargoManagement.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CargoManagement.Api.Controllers;

/// <summary>
/// Controller de referência - CRUD completo e funcional.
/// Use como exemplo de padrão para implementar o ManifestsController.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class ContainersController : ControllerBase
{
    private readonly CargoDbContext _context;
    private readonly ILogger<ContainersController> _logger;

    public ContainersController(CargoDbContext context, ILogger<ContainersController> logger)
    {
        _context = context;
        _logger = logger;
    }

    /// <summary>
    /// Lista todos os containers.
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Container>>> GetAll()
    {
        var containers = await _context.Containers
            .Include(c => c.Cargo)
            .OrderBy(c => c.Codigo)
            .ToListAsync();

        return Ok(containers);
    }

    /// <summary>
    /// Obtém um container pelo ID.
    /// </summary>
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Container>> GetById(int id)
    {
        var container = await _context.Containers
            .Include(c => c.Cargo)
            .FirstOrDefaultAsync(c => c.Id == id);

        if (container is null)
            return NotFound(new { message = $"Container com ID {id} não encontrado." });

        return Ok(container);
    }

    /// <summary>
    /// Lista containers de uma carga específica.
    /// </summary>
    [HttpGet("por-carga/{cargoId:int}")]
    public async Task<ActionResult<IEnumerable<Container>>> GetByCargoId(int cargoId)
    {
        var containers = await _context.Containers
            .Where(c => c.CargoId == cargoId)
            .OrderBy(c => c.Codigo)
            .ToListAsync();

        return Ok(containers);
    }

    /// <summary>
    /// Cria um novo container.
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<Container>> Create([FromBody] Container container)
    {
        var cargoExists = await _context.Cargos.AnyAsync(c => c.Id == container.CargoId);
        if (!cargoExists)
            return BadRequest(new { message = $"Carga com ID {container.CargoId} não encontrada." });

        _context.Containers.Add(container);
        await _context.SaveChangesAsync();

        _logger.LogInformation("Container {Codigo} criado com ID {Id}", container.Codigo, container.Id);

        return CreatedAtAction(nameof(GetById), new { id = container.Id }, container);
    }

    /// <summary>
    /// Atualiza um container existente.
    /// </summary>
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] Container container)
    {
        var existing = await _context.Containers.FindAsync(id);
        if (existing is null)
            return NotFound(new { message = $"Container com ID {id} não encontrado." });

        existing.Codigo = container.Codigo;
        existing.Tamanho = container.Tamanho;
        existing.Conteudo = container.Conteudo;
        existing.Lacrado = container.Lacrado;

        await _context.SaveChangesAsync();

        return Ok(existing);
    }

    /// <summary>
    /// Remove um container.
    /// </summary>
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var container = await _context.Containers.FindAsync(id);
        if (container is null)
            return NotFound(new { message = $"Container com ID {id} não encontrado." });

        _context.Containers.Remove(container);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
