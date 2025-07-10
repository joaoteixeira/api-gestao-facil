using ApiGestaoFacil.DataContexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiGestaoFacil.Controllers
{
    [ApiController]
    [Route("campus")]
    public class CampusController : Controller
    {
        private readonly AppDbContext _context;

        public CampusController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var list = await _context.Campus.ToListAsync();

                return Ok(list);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }
    }
}
