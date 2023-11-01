using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P1ProyectoAPI.Datos;
using P1ProyectoAPI.Models;

namespace P1ProyectoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MesaController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public MesaController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetMesas()
        {
            try
            {
                List<Mesa> mesas = _db.Mesas.ToList();
                return Ok(mesas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPut("idMesa/{idPMesa}")]
        public async Task<IActionResult> CambiarEstadoMesa(int idMesa)
        {
            try
            {
                Mesa mesa = _db.Mesas.FirstOrDefault(m => m.idMesa == idMesa);
                if (mesa == null)
                {
                    return NoContent();
                }
                mesa.estado = false;
                _db.Mesas.Update(mesa);
                await _db.SaveChangesAsync();
                return Ok(mesa);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
