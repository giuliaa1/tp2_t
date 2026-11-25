using System.ComponentModel.DataAnnotations;
namespace LocadoraVeiculos.Api.Models;
public class Veiculo {
 public int Id { get; set; }
 [Required, StringLength(80)] public string Modelo { get; set; } = string.Empty;
 [Required, StringLength(8)] public string Placa { get; set; } = string.Empty;
 [Range(1900, 2100)] public int AnoFabricacao { get; set; }
 [Range(0, int.MaxValue)] public int Quilometragem { get; set; }
 public bool Disponivel { get; set; } = true;
 [Range(1, int.MaxValue)] public int FabricanteId { get; set; }
 public Fabricante? Fabricante { get; set; }
 [Range(1, int.MaxValue)] public int CategoriaId { get; set; }
 public Categoria? Categoria { get; set; }
 public ICollection<Aluguel> Alugueis { get; set; } = new List<Aluguel>();
}
