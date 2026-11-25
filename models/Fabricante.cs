using System.ComponentModel.DataAnnotations;
namespace LocadoraVeiculos.Api.Models;
public class Fabricante {
 public int Id { get; set; }
 [Required, StringLength(80)] public string Nome { get; set; } = string.Empty;
 [StringLength(50)] public string? PaisOrigem { get; set; }
 public ICollection<Veiculo> Veiculos { get; set; } = new List<Veiculo>();
}
