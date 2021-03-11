using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PruebaEtech.Api.Models.Entidades;

namespace PruebaEtech.Api.Models.Mapeos
{
    public class ViajeMap
    {
        public ViajeMap(EntityTypeBuilder<Viaje> entityBuilder)
        {
            entityBuilder.HasKey(e => e.IdViaje);

            entityBuilder.Property(e => e.CodigoViaje).IsRequired().HasMaxLength(50);

            entityBuilder.Property(e => e.LugaresDisponibles).IsRequired().HasColumnType("int");

            entityBuilder.Property(e => e.Origen).IsRequired().HasMaxLength(100);

            entityBuilder.Property(e => e.Destino).IsRequired().HasMaxLength(100);

            entityBuilder.Property(e => e.FechaCreacion).IsRequired().HasColumnType("datetime");

            entityBuilder.Property(e => e.FechaModificacion).IsRequired().HasColumnType("datetime");
        }
    }
}
