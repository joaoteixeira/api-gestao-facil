using ApiGestaoFacil.DataContexts;
using ApiGestaoFacil.Dtos;
using ApiGestaoFacil.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiGestaoFacil.Controllers
{
    [ApiController]
    [Route("servidores")]
    public class ServidorController : Controller
    {
        private readonly AppDbContext _context;

        private readonly IMapper _mappper;

        public ServidorController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mappper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var listaServidores = await _context.Servidores.ToListAsync();

                return Ok(listaServidores);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var servidor = await _context.Servidores.Where(s => s.Id == id).FirstOrDefaultAsync();

                if(servidor == null)
                {
                    return NotFound($"Servidor #{id} não encontrado");
                }

                return Ok(servidor);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ServidorDto item)
        {
            try
            {
                var servidor = _mappper.Map<Servidor>(item);

                await _context.Servidores.AddAsync(servidor);
                await _context.SaveChangesAsync();

                return Created("", servidor);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ServidorDto item)
        {
            try
            {
                var servidor = await _context.Servidores.FindAsync(id);

                if(servidor is null)
                {
                    return NotFound();
                }

                servidor.Nome = item.Nome;
                servidor.CPF = item.CPF;
                servidor.Siape = item.Siape;

                _context.Servidores.Update(servidor);
                await _context.SaveChangesAsync();

                return Ok(servidor);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var servidor = await _context.Servidores.FindAsync(id);

                if (servidor is null)
                {
                    return NotFound();
                }

                _context.Servidores.Remove(servidor);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }
    }
}
