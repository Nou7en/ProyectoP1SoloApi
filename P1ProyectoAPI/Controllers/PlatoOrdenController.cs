using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P1ProyectoAPI.Datos;
using P1ProyectoAPI.Models;

namespace P1ProyectoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatoOrdenController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public PlatoOrdenController(ApplicationDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<IActionResult> GetPlatosOrdenes()
        {
            try
            {
                List<PlatoOrden> platosOrdenes = await _db.Pedidos.ToListAsync();
                return Ok(platosOrdenes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }
        [HttpGet("idPlatoOrden/{idPlatoOrden}")]
        public async Task<IActionResult> GetPlatoOrden(int idPlatoOrden)
        {
            try
            {
                PlatoOrden platoOrden = await _db.Pedidos.FirstOrDefaultAsync(po => po.idPlatoOrden == idPlatoOrden);
                if (platoOrden == null)
                {
                    return NoContent();
                }
                return Ok(platoOrden);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]()
    }
}
