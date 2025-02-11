using ApiGestaoFacil.DataContexts;
using ApiGestaoFacil.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiGestaoFacil.Controllers
{
    [Route("portarias")]
    [ApiController]
    public class PortariaController(AppDbContext context) : Controller
    {
        private readonly AppDbContext _context = context;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var list1 = await _context.Portarias
                    .Include(c => c.Campus)
                    .Include(ps => ps.PortariaServidores)
                    .ThenInclude(ps => ps.Servidor)
                    .ToListAsync();

                var list2 = await _context.Portarias
                    .Include(c => c.Campus)
                    .Include(ps => ps.PortariaServidores)
                    .Select(static p => new
                    {
                        p.Id,
                        p.Titulo,
                        p.Descricao,
                        p.Numero,
                        p.Ano,
                        Campus = new { p.Campus.Id, p.Campus.Nome },
                        servidores = p.PortariaServidores.Select(ps =>
                            new { ps.Servidor.Id, ps.Servidor.Nome, ps.Presidente })
                            .ToList()
                    })
                    .ToListAsync();

                return Ok(list2);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }
    }
}
