using System;
namespace PruebaEtech.Api.Models.Dto
{
    public class ReservacionDto
    {
        public int IdReservacion { get; set; }
        public int IdViaje { get; set; }
        public int IdViajero { get; set; }
        public string Codigo { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }
        public int Asientos { get; set; }
    }
}
