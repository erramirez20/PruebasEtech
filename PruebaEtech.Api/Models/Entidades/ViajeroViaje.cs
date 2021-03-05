using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaEtech.Api.Models.Entidades
{
    public class ViajeroViaje
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdViajeroViaje { get; set; }
        [Required]
        public int IdViaje { get; set; }
        [Required]
        public int IdViajero { get; set; }
        [Required]
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        [Required]
        public virtual ICollection<Viaje> Viaje { get; set; }
        public virtual ICollection<Viajero> Viajero { get; set; }
    }
}
