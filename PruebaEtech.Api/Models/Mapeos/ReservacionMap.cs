using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PruebaEtech.Api.Models.Entidades;

namespace PruebaEtech.Api.Models.Mapeos
{
    public class ReservacionMap
    {
        public ReservacionMap(EntityTypeBuilder<Reservacion> entityBuilder)
        {
            entityBuilder.HasKey(e => e.IdReservacion);

            entityBuilder.Property(e => e.Asientos).IsRequired().HasColumnType("int");

            entityBuilder.Property(e => e.FechaCreacion).IsRequired().HasColumnType("datetime");

            entityBuilder.Property(e => e.FechaModificacion).IsRequired().HasColumnType("datetime");

            entityBuilder.HasOne(d => d.Viaje)
                .WithMany(p => p.Reservacion)
                .HasForeignKey(d => d.IdViaje)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reservacion_Viaje");

            entityBuilder.HasOne(d => d.Viajero)
                .WithMany(p => p.Reservacion)
                .HasForeignKey(d => d.IdViajero)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reservacion_Viajero");
        }
    }
}
