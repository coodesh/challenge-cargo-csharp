using CargoManagement.Api.Controllers;
using CargoManagement.Api.DTOs;
using CargoManagement.Api.Models;
using CargoManagement.Api.Services.Interfaces;
using FluentAssertions;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Xunit;

namespace CargoManagement.Tests.Controllers;

/// <summary>
/// Testes de referência para o CargosController.
/// Use como exemplo de padrão para escrever outros testes.
/// </summary>
public class CargosControllerTests
{
    private readonly ICargoService _cargoService;
    private readonly IValidator<CreateCargoDto> _validator;
    private readonly ILogger<CargosController> _logger;
    private readonly CargosController _controller;

    public CargosControllerTests()
    {
        _cargoService = Substitute.For<ICargoService>();
        _validator = Substitute.For<IValidator<CreateCargoDto>>();
        _logger = Substitute.For<ILogger<CargosController>>();
        _controller = new CargosController(_cargoService, _validator, _logger);
    }

    [Fact]
    public async Task GetAll_ReturnsOkResult_WithPagedData()
    {
        // Arrange
        var pagedResult = new PagedResult<CargoDto>
        {
            Items = new List<CargoDto>
            {
                new() { Id = 1, Numero = "CRG-001", Tipo = "Container", Peso = 1000, Origem = "Santos", Destino = "Roterdã", Status = "Pendente" },
                new() { Id = 2, Numero = "CRG-002", Tipo = "Granel", Peso = 5000, Origem = "Paranaguá", Destino = "Xangai", Status = "Liberada" }
            },
            TotalCount = 2,
            Page = 1,
            PageSize = 10
        };

        // Nota: O controller tem um bug na paginação (page * pageSize ao invés de page).
        // Este teste verifica o comportamento atual (com bug).
        _cargoService.GetAllAsync(Arg.Any<int>(), Arg.Any<int>()).Returns(pagedResult);

        // Act
        var result = await _controller.GetAll(page: 1, pageSize: 10);

        // Assert
        var okResult = result.Result.Should().BeOfType<OkObjectResult>().Subject;
        var returnedData = okResult.Value.Should().BeOfType<PagedResult<CargoDto>>().Subject;
        returnedData.Items.Should().HaveCount(2);
        returnedData.TotalCount.Should().Be(2);
    }

    [Fact]
    public async Task GetById_ExistingId_ReturnsOkResult()
    {
        // Arrange
        var cargo = new Cargo
        {
            Id = 1,
            Numero = "CRG-001",
            Tipo = "Container",
            Peso = 1000,
            Origem = "Santos",
            Destino = "Roterdã",
            Status = "Pendente",
            DataRegistro = DateTime.UtcNow
        };

        _cargoService.GetByIdAsync(1).Returns(cargo);

        // Act
        var result = await _controller.GetById(1);

        // Assert
        result.Should().BeOfType<OkObjectResult>();
    }

    [Fact]
    public async Task GetById_NonExistingId_ReturnsNotFound()
    {
        // Arrange
        _cargoService.GetByIdAsync(999).Returns((Cargo?)null);

        // Act
        var result = await _controller.GetById(999);

        // Assert
        result.Should().BeOfType<NotFoundObjectResult>();
    }

    [Fact]
    public async Task Create_ValidDto_ReturnsCreatedAtAction()
    {
        // Arrange
        var dto = new CreateCargoDto
        {
            Numero = "CRG-NEW",
            Tipo = "Container",
            Peso = 2000,
            Origem = "Santos",
            Destino = "Hamburgo",
            Status = "Pendente"
        };

        var cargo = new Cargo
        {
            Id = 10,
            Numero = dto.Numero,
            Tipo = dto.Tipo,
            Peso = dto.Peso,
            Origem = dto.Origem,
            Destino = dto.Destino,
            Status = dto.Status,
            DataRegistro = DateTime.UtcNow
        };

        _validator.ValidateAsync(dto, Arg.Any<CancellationToken>())
            .Returns(new ValidationResult());
        _cargoService.CreateAsync(dto).Returns(cargo);

        // Act
        var result = await _controller.Create(dto);

        // Assert
        var createdResult = result.Should().BeOfType<CreatedAtActionResult>().Subject;
        createdResult.StatusCode.Should().Be(201);
    }

    [Fact]
    public async Task Create_InvalidDto_ReturnsBadRequest()
    {
        // Arrange
        var dto = new CreateCargoDto { Numero = "" }; // inválido

        var validationResult = new ValidationResult(new[]
        {
            new ValidationFailure("Numero", "Número da carga é obrigatório.")
        });

        _validator.ValidateAsync(dto, Arg.Any<CancellationToken>())
            .Returns(validationResult);

        // Act
        var result = await _controller.Create(dto);

        // Assert
        result.Should().BeOfType<BadRequestObjectResult>();
    }

    [Fact]
    public async Task Delete_ExistingId_ReturnsNoContent()
    {
        // Arrange
        _cargoService.DeleteAsync(1).Returns(true);

        // Act
        var result = await _controller.Delete(1);

        // Assert
        result.Should().BeOfType<NoContentResult>();
    }

    [Fact]
    public async Task Delete_NonExistingId_ReturnsNotFound()
    {
        // Arrange
        _cargoService.DeleteAsync(999).Returns(false);

        // Act
        var result = await _controller.Delete(999);

        // Assert
        result.Should().BeOfType<NotFoundObjectResult>();
    }

    [Fact]
    public async Task GetByPeriod_ValidDates_ReturnsOk()
    {
        // Arrange
        var startDate = new DateTime(2024, 1, 1);
        var endDate = new DateTime(2024, 12, 31);
        var cargos = new List<CargoDto>
        {
            new() { Id = 1, Numero = "CRG-001", DataRegistro = new DateTime(2024, 6, 15) }
        };

        _cargoService.GetByPeriodAsync(startDate, endDate).Returns(cargos);

        // Act
        var result = await _controller.GetByPeriod(startDate, endDate);

        // Assert
        result.Should().BeOfType<OkObjectResult>();
    }

    [Fact]
    public async Task GetByPeriod_InvalidDates_ReturnsBadRequest()
    {
        // Arrange
        var startDate = new DateTime(2024, 12, 31);
        var endDate = new DateTime(2024, 1, 1); // anterior ao início

        // Act
        var result = await _controller.GetByPeriod(startDate, endDate);

        // Assert
        result.Should().BeOfType<BadRequestObjectResult>();
    }
}
