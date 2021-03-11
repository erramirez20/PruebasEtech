using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaEtech.Api.Models.Contexto;
using PruebaEtech.Api.Models.Entidades;

namespace PruebaEtech.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ViajeController : Controller
    {
        private readonly PruebaEtechContexto Contexto;

        public ViajeController(PruebaEtechContexto _Contexto)
        {
            Contexto = _Contexto;
        }

        [HttpPost]
        [EnableCors("AllowOrigin")]
        public async Task<ActionResult<Viaje>> Post(Viaje viaje)
        {
            viaje.FechaCreacion = DateTime.Now;
            viaje.FechaModificacion = DateTime.Now;

            Contexto.Viaje.Add(viaje);
            await Contexto.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = viaje.IdViaje }, viaje);
        }

        [HttpGet]
        [EnableCors("AllowOrigin")]
        public async Task<IEnumerable<Viaje>> Get()
        {
            return await Contexto.Viaje.ToListAsync();
        }


        [HttpGet("{id}")]
        [EnableCors("AllowOrigin")]
        public async Task<ActionResult<Viaje>> GetViaje(int id)
        {
            var viaje = await Contexto.Viaje.FindAsync(id);

            if (viaje == null)
            {
                return NotFound();
            }

            return viaje;
        }

        [HttpGet]
        [Route("[action]/{destino}")]
        [EnableCors("AllowOrigin")]
        public async Task<IEnumerable<Viaje>> GetViajePorDestino(string destino)
        {
            var viaje = await Contexto.Viaje.Where(v => v.Destino.ToUpper().Contains(destino.ToUpper())).ToListAsync();

            return viaje;
        }

        [HttpPut("{id}")]
        [EnableCors("AllowOrigin")]
        public async Task<ActionResult<Viaje>> PutViaje(int id, Viaje viaje)
        {
            Viaje tmpViaje = await Contexto.Viaje.FindAsync(id);

            if (tmpViaje == null)
            {
                return NotFound();
            }
            else
            {
                tmpViaje.CodigoViaje = viaje.CodigoViaje;
                tmpViaje.LugaresDisponibles = viaje.LugaresDisponibles;
                tmpViaje.Origen = viaje.Origen;
                tmpViaje.Destino = viaje.Destino;
                tmpViaje.Precio = viaje.Precio;
                tmpViaje.FechaModificacion = DateTime.Now;
                Contexto.Entry(tmpViaje).State = EntityState.Modified;

                try
                {
                    await Contexto.SaveChangesAsync();
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> DeleteViaje(int id)
        {
            var tmpViaje = await Contexto.Viaje.FindAsync(id);

            if (tmpViaje == null)
            {
                return NotFound();
            }
            else
            {
                Contexto.Viaje.Remove(tmpViaje);

                try
                {
                    await Contexto.SaveChangesAsync();
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }

            return NoContent();
        }
    }
}
