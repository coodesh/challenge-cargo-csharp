namespace CargoManagement.Api.Models;

public class Container
{
    public int Id { get; set; }
    public string Codigo { get; set; } = string.Empty;
    public int CargoId { get; set; }
    public string Tamanho { get; set; } = string.Empty;
    public string Conteudo { get; set; } = string.Empty;
    public bool Lacrado { get; set; }

    public Cargo Cargo { get; set; } = null!;
}
