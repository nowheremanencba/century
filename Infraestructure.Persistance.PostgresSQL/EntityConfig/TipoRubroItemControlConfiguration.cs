using Domain.Entities; 
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Persistance.PostgresSQL.EntityConfig
{
    
    public class TipoRubroItemControlConfiguration : IEntityTypeConfiguration<TipoRubroItemControl>
    {
        public void Configure(EntityTypeBuilder<TipoRubroItemControl> builder)
        {
            // Mapeo a la tabla TiposRubrosItemControl (en plural)            
            builder.ToTable("TiposRubroItemsControl");
            // set Id como primaryKey
            builder.HasKey(a => a.Id);
            // setear como no permitir null y tamaño maximo de 300
            builder.Property(a => a.Descripcion).HasMaxLength(300);
        }
    }
}
