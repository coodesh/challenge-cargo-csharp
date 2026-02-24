using CargoManagement.Api.DTOs;
using FluentValidation;

namespace CargoManagement.Api.Validators;

/// <summary>
/// Validator de referência - use como exemplo para implementar ManifestValidator.
/// </summary>
public class CargoValidator : AbstractValidator<CreateCargoDto>
{
    private static readonly string[] TiposValidos = { "Granel", "Container", "Carga Geral", "Líquido" };
    private static readonly string[] StatusValidos = { "Pendente", "Em Trânsito", "No Porto", "Liberada", "Retida" };

    public CargoValidator()
    {
        RuleFor(x => x.Numero)
            .NotEmpty().WithMessage("Número da carga é obrigatório.")
            .MaximumLength(50).WithMessage("Número deve ter no máximo 50 caracteres.");

        RuleFor(x => x.Tipo)
            .NotEmpty().WithMessage("Tipo da carga é obrigatório.")
            .Must(t => TiposValidos.Contains(t))
            .WithMessage($"Tipo deve ser um dos seguintes: {string.Join(", ", TiposValidos)}.");

        RuleFor(x => x.Peso)
            .GreaterThan(0).WithMessage("Peso deve ser maior que zero.")
            .LessThanOrEqualTo(100000).WithMessage("Peso máximo é 100.000 toneladas.");

        RuleFor(x => x.Origem)
            .NotEmpty().WithMessage("Origem é obrigatória.")
            .MaximumLength(100).WithMessage("Origem deve ter no máximo 100 caracteres.");

        RuleFor(x => x.Destino)
            .NotEmpty().WithMessage("Destino é obrigatório.")
            .MaximumLength(100).WithMessage("Destino deve ter no máximo 100 caracteres.");

        RuleFor(x => x.Status)
            .NotEmpty().WithMessage("Status é obrigatório.")
            .Must(s => StatusValidos.Contains(s))
            .WithMessage($"Status deve ser um dos seguintes: {string.Join(", ", StatusValidos)}.");
    }
}
