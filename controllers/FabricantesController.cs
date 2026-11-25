using LocadoraVeiculos.Api.Data;
using LocadoraVeiculos.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace LocadoraVeiculos.Api.Controllers;
[ApiController, Route("api/[controller]")]
public class FabricantesController : ControllerBase {
 private readonly LocadoraContext _db; public FabricantesController(LocadoraContext db)=>_db=db;
 [HttpGet] public async Task<ActionResult<IEnumerable<Fabricante>>> Get()=>await _db.Fabricantes.AsNoTracking().ToListAsync();
 [HttpGet("{id:int}")] public async Task<ActionResult<Fabricante>> Get(int id) { var x=await _db.Fabricantes.FindAsync(id); return x is null?NotFound():Ok(x); }
 [HttpPost] public async Task<ActionResult<Fabricante>> Post(Fabricante x) { if(!ModelState.IsValid)return ValidationProblem(ModelState); _db.Fabricantes.Add(x); await _db.SaveChangesAsync(); return CreatedAtAction(nameof(Get),new{id=x.Id},x); }
 [HttpPut("{id:int}")] public async Task<IActionResult> Put(int id,Fabricante x) { if(id!=x.Id)return BadRequest(new{erro="Id da rota difere do objeto."}); if(!await _db.Fabricantes.AnyAsync(e=>e.Id==id))return NotFound(); _db.Entry(x).State=EntityState.Modified; await _db.SaveChangesAsync(); return NoContent(); }
 [HttpDelete("{id:int}")] public async Task<IActionResult> Delete(int id) { var x=await _db.Fabricantes.FindAsync(id); if(x is null)return NotFound(); _db.Fabricantes.Remove(x); await _db.SaveChangesAsync(); return NoContent(); }
}