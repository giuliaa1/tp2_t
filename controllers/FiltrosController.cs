using LocadoraVeiculos.Api.Data; using Microsoft.AspNetCore.Mvc; using Microsoft.EntityFrameworkCore;
namespace LocadoraVeiculos.Api.Controllers;
[ApiController,Route("api/filtros")] public class FiltrosController:ControllerBase {private readonly LocadoraContext _db; public FiltrosController(LocadoraContext db)=>_db=db;
 // 1 - INNER JOIN Veiculo + Fabricante
 [HttpGet("veiculos-por-fabricante/{fabricanteId:int}")] public async Task<IActionResult> VeiculosFabricante(int fabricanteId)=>Ok(await (from v in _db.Veiculos join f in _db.Fabricantes on v.FabricanteId equals f.Id where f.Id==fabricanteId select new{v.Id,v.Modelo,v.Placa,Fabricante=f.Nome}).ToListAsync());
 // 2 - INNER JOIN Aluguel + Cliente + Veiculo
 [HttpGet("alugueis-por-cliente/{clienteId:int}")] public async Task<IActionResult> AlugueisCliente(int clienteId)=>Ok(await (from a in _db.Alugueis join c in _db.Clientes on a.ClienteId equals c.Id join v in _db.Veiculos on a.VeiculoId equals v.Id where c.Id==clienteId select new{a.Id,Cliente=c.Nome,Veiculo=v.Modelo,a.DataInicio,a.DataDevolucao,a.ValorTotal}).ToListAsync());
 // 3 - INNER JOIN Veiculo + Categoria + Fabricante
 [HttpGet("veiculos-disponiveis")] public async Task<IActionResult> Disponiveis()=>Ok(await (from v in _db.Veiculos join c in _db.Categorias on v.CategoriaId equals c.Id join f in _db.Fabricantes on v.FabricanteId equals f.Id where v.Disponivel select new{v.Id,v.Modelo,v.Placa,Fabricante=f.Nome,Categoria=c.Nome,c.ValorDiariaSugerido}).ToListAsync());
 // 4 - LEFT JOIN Cliente + Aluguel (inclui clientes sem aluguel)
 [HttpGet("clientes-com-quantidade-alugueis")] public async Task<IActionResult> ClientesQuantidade()=>Ok(await (from c in _db.Clientes join a in _db.Alugueis on c.Id equals a.ClienteId into grupo select new{c.Id,c.Nome,c.Email,QuantidadeAlugueis=grupo.Count()}).ToListAsync());
 // 5 - LEFT JOIN Veiculo + Aluguel (inclui veículos nunca alugados)
 [HttpGet("veiculos-com-ultimo-aluguel")] public async Task<IActionResult> UltimoAluguel()=>Ok(await (from v in _db.Veiculos join a in _db.Alugueis on v.Id equals a.VeiculoId into ga from a in ga.OrderByDescending(x=>x.DataInicio).Take(1).DefaultIfEmpty() select new{v.Id,v.Modelo,v.Placa,UltimoAluguel=a==null?(DateTime?)null:a.DataInicio,UltimaDevolucao=a==null?null:a.DataDevolucao}).ToListAsync());
}
