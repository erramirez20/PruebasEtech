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
    public class ViajeroController : ControllerBase
    {
        private readonly PruebaEtechContexto Contexto;

        public ViajeroController(PruebaEtechContexto _Contexto)
        {
            Contexto = _Contexto;
        }

        [HttpPost]
        [EnableCors("AllowOrigin")]
        public async Task<ActionResult<Viajero>> Post(Viajero viajero)
        {
            viajero.FechaCreacion = DateTime.Now;
            viajero.FechaModificacion = DateTime.Now;

            Contexto.Viajero.Add(viajero);
            await Contexto.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = viajero.IdViajero }, viajero);
        }

        [HttpGet]
        [EnableCors("AllowOrigin")]
        public async Task<IEnumerable<Viajero>> Get()
        {
            return await Contexto.Viajero.ToListAsync();
        }


        [HttpGet("{id}")]
        [EnableCors("AllowOrigin")]
        public async Task<ActionResult<Viajero>> GetViajero(int id)
        {
            var viajero = await Contexto.Viajero.FindAsync(id);

            if (viajero == null)
            {
                return NotFound();
            }

            return viajero;
        }

        [HttpPut("{id}")]
        [EnableCors("AllowOrigin")]
        public async Task<ActionResult<Viajero>> PutViajero(int id, Viajero viajero)
        {
            Viajero tmpViajero = await Contexto.Viajero.FindAsync(id);

            if(tmpViajero == null)
            {
                return NotFound();
            }
            else
            {
                tmpViajero.Cedula = viajero.Cedula;
                tmpViajero.Nombre = viajero.Nombre;
                tmpViajero.Direccion = viajero.Direccion;
                tmpViajero.Telefono = viajero.Telefono;
                tmpViajero.FechaModificacion = DateTime.Now;
                Contexto.Entry(tmpViajero).State = EntityState.Modified;

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
        public async Task<IActionResult> DeleteViajero(int id)
        {
            var tmpViajero = await Contexto.Viajero.FindAsync(id);

            if (tmpViajero == null)
            {
                return NotFound();
            }
            else
            {
                Contexto.Viajero.Remove(tmpViajero);

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
