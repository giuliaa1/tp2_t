using System.ComponentModel.DataAnnotations;
namespace LocadoraVeiculos.Api.Models;
public class Aluguel {
 public int Id { get; set; }
 [Range(1,int.MaxValue)] public int ClienteId { get; set; }
 public Cliente? Cliente { get; set; }
 [Range(1,int.MaxValue)] public int VeiculoId { get; set; }
 public Veiculo? Veiculo { get; set; }
 public DateTime DataInicio { get; set; }
 public DateTime DataFimPrevista { get; set; }
 public DateTime? DataDevolucao { get; set; }
 [Range(0,int.MaxValue)] public int QuilometragemInicial { get; set; }
 [Range(0,int.MaxValue)] public int? QuilometragemFinal { get; set; }
 [Range(0.01,999999)] public decimal ValorDiaria { get; set; }
 [Range(0,9999999)] public decimal ValorTotal { get; set; }
}
