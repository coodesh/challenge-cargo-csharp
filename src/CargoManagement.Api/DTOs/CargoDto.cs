namespace CargoManagement.Api.DTOs;

public class CargoDto
{
    public int Id { get; set; }
    public string Numero { get; set; } = string.Empty;
    public string Tipo { get; set; } = string.Empty;
    public decimal Peso { get; set; }
    public string Origem { get; set; } = string.Empty;
    public string Destino { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public DateTime DataRegistro { get; set; }
    public int TotalContainers { get; set; }
}

public class CreateCargoDto
{
    public string Numero { get; set; } = string.Empty;
    public string Tipo { get; set; } = string.Empty;
    public decimal Peso { get; set; }
    public string Origem { get; set; } = string.Empty;
    public string Destino { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
}
