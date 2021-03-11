using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PruebaEtech.Api.Models.Entidades;

namespace PruebaEtech.Api.Models.Mapeos
{
    public class ViajeroMap
    {
        public ViajeroMap(EntityTypeBuilder<Viajero> entityBuilder)
        {
            entityBuilder.HasKey(e => e.IdViajero);

            entityBuilder.Property(e => e.Cedula).IsRequired().HasMaxLength(20);

            entityBuilder.Property(e => e.Nombre).IsRequired().HasMaxLength(50);

            entityBuilder.Property(e => e.Direccion).IsRequired().HasMaxLength(80);

            entityBuilder.Property(e => e.Telefono).IsRequired().HasMaxLength(20);

            entityBuilder.Property(e => e.FechaCreacion).IsRequired().HasColumnType("datetime");

            entityBuilder.Property(e => e.FechaModificacion).IsRequired().HasColumnType("datetime");
        }
    }
}
