using System;
using System.Collections.Generic;

namespace PruebaEtech.Api.Models.Entidades
{
    public class Viajero
    {
        public int IdViajero { get; set; }
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public virtual ICollection<Reservacion> Reservacion { get; set; }
    }
}
