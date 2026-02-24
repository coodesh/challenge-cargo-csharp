using CargoManagement.Api.DTOs;
using CargoManagement.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CargoManagement.Api.Controllers;

// TODO: Candidato deve implementar este controller.
// Use CargosController.cs e ContainersController.cs como referência de padrão.
//
// Endpoints esperados:
//   GET    /api/manifests           - Listar todos
//   GET    /api/manifests/{id}      - Buscar por ID
//   GET    /api/manifests/por-carga/{cargoId} - Buscar por carga
//   POST   /api/manifests           - Criar novo (com validação FluentValidation)
//   PUT    /api/manifests/{id}      - Atualizar
//   DELETE /api/manifests/{id}      - Remover

[ApiController]
[Route("api/[controller]")]
public class ManifestsController : ControllerBase
{
    private readonly IManifestService _manifestService;
    private readonly ILogger<ManifestsController> _logger;

    public ManifestsController(
        IManifestService manifestService,
        ILogger<ManifestsController> logger)
    {
        _manifestService = manifestService;
        _logger = logger;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        // TODO: Implementar
        return StatusCode(501, new { message = "Endpoint não implementado. Candidato deve implementar." });
    }

    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        // TODO: Implementar
        return StatusCode(501, new { message = "Endpoint não implementado. Candidato deve implementar." });
    }

    [HttpGet("por-carga/{cargoId:int}")]
    public IActionResult GetByCargoId(int cargoId)
    {
        // TODO: Implementar
        return StatusCode(501, new { message = "Endpoint não implementado. Candidato deve implementar." });
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateManifestDto dto)
    {
        // TODO: Implementar com validação FluentValidation
        return StatusCode(501, new { message = "Endpoint não implementado. Candidato deve implementar." });
    }

    [HttpPut("{id:int}")]
    public IActionResult Update(int id, [FromBody] CreateManifestDto dto)
    {
        // TODO: Implementar
        return StatusCode(501, new { message = "Endpoint não implementado. Candidato deve implementar." });
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        // TODO: Implementar
        return StatusCode(501, new { message = "Endpoint não implementado. Candidato deve implementar." });
    }
}
