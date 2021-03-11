using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaEtech.Api.Models.Contexto;
using PruebaEtech.Api.Models.Dto;
using PruebaEtech.Api.Models.Entidades;

namespace PruebaEtech.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReservacionController : Controller
    {
        private readonly PruebaEtechContexto Contexto;

        public ReservacionController(PruebaEtechContexto _Contexto)
        {
            Contexto = _Contexto;
        }

        [HttpPost]
        [EnableCors("AllowOrigin")]
        public async Task<ActionResult<Reservacion>> Post(Reservacion reservacion)
        {
            reservacion.FechaCreacion = DateTime.Now;
            reservacion.FechaModificacion = DateTime.Now;
            Contexto.Reservacion.Add(reservacion);
            await Contexto.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = reservacion.IdReservacion }, reservacion);
        }

        [HttpGet]
        [EnableCors("AllowOrigin")]
        public async Task<IEnumerable<Reservacion>> Get()
        {
            return await Contexto.Reservacion.ToListAsync();
        }


        [HttpGet("{id}")]
        [EnableCors("AllowOrigin")]
        public async Task<ActionResult<Reservacion>> GetReservacion(int id)
        {
            var reservacion = await Contexto.Reservacion.FindAsync(id);

            if (reservacion == null)
            {
                return NotFound();
            }

            return reservacion;
        }

        [HttpGet]
        [Route("[action]/{id}")]
        [EnableCors("AllowOrigin")]
        public async Task<IEnumerable<ReservacionDto>> GetReservacionPorIdViajero(int id)
        {
            var viaje = await Contexto.Reservacion.Include(v => v.Viaje)
                .Select(x => new ReservacionDto()
                {
                    IdReservacion = x.IdReservacion,
                    IdViaje = x.IdViaje,
                    IdViajero = x.IdViajero,
                    Codigo = x.Viaje.CodigoViaje,
                    Origen = x.Viaje.Origen,
                    Destino = x.Viaje.Destino,
                    Asientos = x.Asientos
                })
                .Where(v => v.IdViajero == id).ToListAsync();

            return viaje;
        }

        [HttpPut("{id}")]
        [EnableCors("AllowOrigin")]
        public async Task<ActionResult<Reservacion>> PutReservacion(int id, Reservacion reservacion)
        {
            Reservacion tmpReservacion = await Contexto.Reservacion.FindAsync(id);

            if (tmpReservacion == null)
            {
                return NotFound();
            }
            else
            {
                tmpReservacion.IdViaje = reservacion.IdViaje;
                tmpReservacion.IdViajero = reservacion.IdViajero;
                tmpReservacion.Asientos = reservacion.Asientos;
                tmpReservacion.FechaModificacion = DateTime.Now;
                Contexto.Entry(tmpReservacion).State = EntityState.Modified;

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
        public async Task<IActionResult> DeleteReservacion(int id)
        {
            var tmpReservacion = await Contexto.Reservacion.FindAsync(id);

            if (tmpReservacion == null)
            {
                return NotFound();
            }
            else
            {
                Contexto.Reservacion.Remove(tmpReservacion);

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
