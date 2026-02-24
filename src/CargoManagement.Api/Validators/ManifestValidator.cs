using CargoManagement.Api.DTOs;
using FluentValidation;

namespace CargoManagement.Api.Validators;

// TODO: Candidato deve implementar este validator.
// Use CargoValidator.cs como referência de padrão.
//
// Regras esperadas:
//   - CargoId: obrigatório, maior que zero
//   - Numero: obrigatório, máximo 50 caracteres
//   - Despachante: obrigatório, máximo 100 caracteres
//   - Observacoes: opcional, máximo 500 caracteres
public class ManifestValidator : AbstractValidator<CreateManifestDto>
{
    public ManifestValidator()
    {
        // TODO: Implementar regras de validação
    }
}
