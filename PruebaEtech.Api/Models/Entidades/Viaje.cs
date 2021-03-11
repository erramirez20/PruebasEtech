using System;
using System.Collections.Generic;

namespace PruebaEtech.Api.Models.Entidades
{
    public class Viaje
    {
        public int IdViaje { get; set; }
        public string CodigoViaje { get; set; }
        public int LugaresDisponibles { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }
        public int Precio { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public virtual ICollection<Reservacion> Reservacion { get; set; }
    }
}
