using System;
using Microsoft.EntityFrameworkCore;
using PruebaEtech.Api.Models.Entidades;
using PruebaEtech.Api.Models.Mapeos;

namespace PruebaEtech.Api.Models.Contexto
{
    public class PruebaEtechContexto : DbContext
    {
        public virtual DbSet<Viaje> Viaje { get; set; }
        public virtual DbSet<Viajero> Viajero { get; set; }
        public virtual DbSet<Reservacion> Reservacion { get; set; }

        public PruebaEtechContexto()
        {
        }

        public PruebaEtechContexto(DbContextOptions<PruebaEtechContexto> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            new ViajeroMap(modelBuilder.Entity<Viajero>());
            new ViajeMap(modelBuilder.Entity<Viaje>());
            new ReservacionMap(modelBuilder.Entity<Reservacion>());
        }
    }
}
