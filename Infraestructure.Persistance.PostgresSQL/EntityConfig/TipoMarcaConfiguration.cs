using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Persistance.PostgresSQL.EntityConfig
{
    public class TipoMarcaConfiguration : IEntityTypeConfiguration<TipoMarca>
    {
        public void Configure(EntityTypeBuilder<TipoMarca> builder)
        {
            // Mapeo a la tabla TiposMarca            
            builder.ToTable("TiposMarca");
            // set Id como primaryKey
            builder.HasKey(a => a.Id);
            // setear  tamaño maximo de 300
            builder.Property(a => a.Descripcion).HasMaxLength(300);

        }
    }
}
