using Microsoft.EntityFrameworkCore;
namespace LocadoraVeiculos.Api.Middleware;
public class ExceptionMiddleware {
 private readonly RequestDelegate _next;
 public ExceptionMiddleware(RequestDelegate next) => _next = next;
 public async Task InvokeAsync(HttpContext context) {
  try { await _next(context); }
  catch (DbUpdateException) { context.Response.StatusCode=400; await context.Response.WriteAsJsonAsync(new { erro="Não foi possível salvar. Verifique dados duplicados ou relacionamentos." }); }
  catch (Exception) { context.Response.StatusCode=500; await context.Response.WriteAsJsonAsync(new { erro="Erro interno ao processar a solicitação." }); }
 }
}
