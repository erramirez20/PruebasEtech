using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaEtech.Api.Models.Entidades
{
    public class Reservacion
    {
        public int IdReservacion { get; set; }
        public int IdViaje { get; set; }
        public int IdViajero { get; set; }
        public int Asientos { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public virtual Viaje Viaje { get; set; }
        public virtual Viajero Viajero { get; set; }
    }
}
