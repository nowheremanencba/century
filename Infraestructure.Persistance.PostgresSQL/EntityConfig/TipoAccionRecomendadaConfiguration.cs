using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Persistance.PostgresSQL.EntityConfig
{ 
    class TipoAccionRecomendadaConfiguration : IEntityTypeConfiguration<TipoAccionRecomendada>
    {
        public void Configure(EntityTypeBuilder<TipoAccionRecomendada> builder)
        {
            // Mapeo a la tabla TiposAccionesRecomendada (en plural)            
            builder.ToTable("TiposAccionesRecomendada");
            // set Id como primaryKey
            builder.HasKey(a => a.Id);
            // setear  tamaño maximo de 300
            builder.Property(a => a.Descripcion).HasMaxLength(300);

        }
    }
}
