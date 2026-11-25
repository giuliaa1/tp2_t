using LocadoraVeiculos.Api.Data;
using LocadoraVeiculos.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace LocadoraVeiculos.Api.Controllers;
[ApiController, Route("api/[controller]")]
public class ClientesController : ControllerBase {
 private readonly LocadoraContext _db; public ClientesController(LocadoraContext db)=>_db=db;
 [HttpGet] public async Task<ActionResult<IEnumerable<Cliente>>> Get()=>await _db.Clientes.AsNoTracking().ToListAsync();
 [HttpGet("{id:int}")] public async Task<ActionResult<Cliente>> Get(int id) { var x=await _db.Clientes.FindAsync(id); return x is null?NotFound():Ok(x); }
 [HttpPost] public async Task<ActionResult<Cliente>> Post(Cliente x) { if(!ModelState.IsValid)return ValidationProblem(ModelState); _db.Clientes.Add(x); await _db.SaveChangesAsync(); return CreatedAtAction(nameof(Get),new{id=x.Id},x); }
 [HttpPut("{id:int}")] public async Task<IActionResult> Put(int id,Cliente x) { if(id!=x.Id)return BadRequest(new{erro="Id da rota difere do objeto."}); if(!await _db.Clientes.AnyAsync(e=>e.Id==id))return NotFound(); _db.Entry(x).State=EntityState.Modified; await _db.SaveChangesAsync(); return NoContent(); }
 [HttpDelete("{id:int}")] public async Task<IActionResult> Delete(int id) { var x=await _db.Clientes.FindAsync(id); if(x is null)return NotFound(); _db.Clientes.Remove(x); await _db.SaveChangesAsync(); return NoContent(); }
}