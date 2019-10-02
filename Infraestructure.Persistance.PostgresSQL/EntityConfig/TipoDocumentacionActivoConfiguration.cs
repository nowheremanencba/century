using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Persistance.PostgresSQL.EntityConfig
{ 
    public class TipoDocumentacionActivoConfiguration : IEntityTypeConfiguration<TipoDocumentacionActivo>
    {
        public void Configure(EntityTypeBuilder<TipoDocumentacionActivo> builder)
        {
            // Mapeo a la tabla TiposActivo (en plural)            
            builder.ToTable("TiposDocumentacionActivo");
            // set Id como primaryKey
            builder.HasKey(a => a.Id);
            // setear como no permitir null y tamaño maximo de 150
            builder.Property(a => a.Descripcion).HasMaxLength(300);

        }
    }
}
