using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Persistance.PostgresSQL.EntityConfig
{
    public class TipoActivoConfiguration : IEntityTypeConfiguration<TipoActivo>
    {
        public void Configure(EntityTypeBuilder<TipoActivo> builder)
        {
            // Mapeo a la tabla TiposActivo (en plural)            
            builder.ToTable("TiposActivo");
            // set Id como primaryKey
            builder.HasKey(a => a.Id);
            // setear como no permitir null y tamaño maximo de 150
            builder.Property(a => a.Descripcion ).HasMaxLength(300); 

        }
    }
}
