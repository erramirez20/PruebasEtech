using System;
using Microsoft.EntityFrameworkCore;

namespace PruebaEtech.Api.Models.Contexto
{
    public class PruebaEtechContexto : DbContext
    {
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
        }
    }
}
