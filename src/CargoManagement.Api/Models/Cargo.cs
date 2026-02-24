namespace CargoManagement.Api.Models;

public class Cargo
{
    public int Id { get; set; }
    public string Numero { get; set; } = string.Empty;
    public string Tipo { get; set; } = string.Empty;
    public decimal Peso { get; set; }
    public string Origem { get; set; } = string.Empty;
    public string Destino { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public DateTime DataRegistro { get; set; }

    public List<Container> Containers { get; set; } = new();
    public List<Manifest> Manifests { get; set; } = new();
}
