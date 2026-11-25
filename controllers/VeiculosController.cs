using LocadoraVeiculos.Api.Data; using LocadoraVeiculos.Api.Models; using Microsoft.AspNetCore.Mvc; using Microsoft.EntityFrameworkCore;
namespace LocadoraVeiculos.Api.Controllers;
[ApiController,Route("api/[controller]")] public class VeiculosController:ControllerBase { private readonly LocadoraContext _db; public VeiculosController(LocadoraContext db)=>_db=db;
 [HttpGet] public async Task<IActionResult> Get()=>Ok(await _db.Veiculos.AsNoTracking().Include(x=>x.Fabricante).Include(x=>x.Categoria).ToListAsync());
 [HttpGet("{id:int}")] public async Task<IActionResult> Get(int id){var x=await _db.Veiculos.Include(v=>v.Fabricante).Include(v=>v.Categoria).FirstOrDefaultAsync(v=>v.Id==id);return x is null?NotFound():Ok(x);}
 [HttpPost] public async Task<IActionResult> Post(Veiculo x){if(!await _db.Fabricantes.AnyAsync(f=>f.Id==x.FabricanteId)||!await _db.Categorias.AnyAsync(c=>c.Id==x.CategoriaId))return BadRequest(new{erro="Fabricante ou categoria inexistente."});_db.Veiculos.Add(x);await _db.SaveChangesAsync();return CreatedAtAction(nameof(Get),new{id=x.Id},x);}
 [HttpPut("{id:int}")] public async Task<IActionResult> Put(int id,Veiculo x){if(id!=x.Id)return BadRequest();if(!await _db.Veiculos.AnyAsync(v=>v.Id==id))return NotFound();_db.Entry(x).State=EntityState.Modified;await _db.SaveChangesAsync();return NoContent();}
 [HttpDelete("{id:int}")] public async Task<IActionResult> Delete(int id){var x=await _db.Veiculos.FindAsync(id);if(x is null)return NotFound();_db.Remove(x);await _db.SaveChangesAsync();return NoContent();}
}
