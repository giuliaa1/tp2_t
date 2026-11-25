using System.ComponentModel.DataAnnotations;
namespace LocadoraVeiculos.Api.Models;
public class Categoria {
 public int Id { get; set; }
 [Required, StringLength(60)] public string Nome { get; set; } = string.Empty;
 [Range(0, 99999)] public decimal ValorDiariaSugerido { get; set; }
 public ICollection<Veiculo> Veiculos { get; set; } = new List<Veiculo>();
}
