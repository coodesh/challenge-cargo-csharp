namespace CargoManagement.Api.Models;

public class Manifest
{
    public int Id { get; set; }
    public int CargoId { get; set; }
    public string Numero { get; set; } = string.Empty;
    public DateTime DataEmissao { get; set; }
    public string Despachante { get; set; } = string.Empty;
    public string? Observacoes { get; set; }

    public Cargo Cargo { get; set; } = null!;
}
