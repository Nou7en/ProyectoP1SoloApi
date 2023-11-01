using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P1ProyectoAPI.Datos;
using P1ProyectoAPI.Models;

namespace P1ProyectoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatoController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public PlatoController(ApplicationDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPlatos()
        {
            try
            {
                List<Plato> platos = await _db.Menu.ToListAsync();
                return Ok(platos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("idPlato/{idPlato}")]
        public async Task<IActionResult> GetPlato(int idPlato)
        {
            try
            {
                Plato plato = await _db.Menu.SingleOrDefaultAsync(p => p.idPlato == idPlato);
                if (plato == null)
                {
                    return NoContent();
                }
                return Ok(plato);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }


        }
        [HttpPost]
        public async Task<IActionResult> CrearPlato([FromBody] Plato nplato)
        {
            try
            {
                Plato plato = await _db.Menu.FirstOrDefaultAsync(p => p.nombre.ToLower() == nplato.nombre.ToLower());
                if (plato == null)
                {
                    return BadRequest("El nombre ya existe");
                }
                if (nplato == null)
                {
                    return BadRequest();
                }
                Plato modelo = new()
                {
                    nombre = nplato.nombre,
                    precio = nplato.precio,
                };
                await _db.Menu.AddAsync(modelo);
                await _db.SaveChangesAsync();
                return Ok(modelo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("idPlato/{idPlato}")]
        public async Task<IActionResult> EditarPlato([FromBody] Plato ePlato, int idPlato)
        {
            try
            {
                if (ePlato == null || idPlato != ePlato.idPlato)
                {
                    return BadRequest();
                }

                Plato modelo = new()
                {
                    idPlato = ePlato.idPlato,
                    nombre = ePlato.nombre,
                    precio = ePlato.precio,
                };
                _db.Menu.Update(modelo);
                await _db.SaveChangesAsync();

                return Ok(modelo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("idPlato/{idPlato}")]
        public async Task<IActionResult> DeletePlato(int idPlato)
        {
            try
            {
                Plato plato = _db.Menu.FirstOrDefault(p => p.idPlato == idPlato);
                if (plato == null)
                {
                    return NoContent();
                }
                _db.Menu.Remove(plato);
                await _db.SaveChangesAsync();
                return Ok(plato);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
