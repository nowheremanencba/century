using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Persistance.PostgresSQL.EntityConfig
{
 
    public class TipoMedidaPeriodicidadConfiguration : IEntityTypeConfiguration<TipoMedidaPeriodicidad>
    {
        public void Configure(EntityTypeBuilder<TipoMedidaPeriodicidad> builder)
        {
            // Mapeo a la tabla TiposModelo (en plural)            
            builder.ToTable("TiposMedidaPeriodicidad");
            // set Id como primaryKey
            builder.HasKey(a => a.Id);
            // setear  no permitir tamaño maximo de 300
            builder.Property(a => a.Descripcion).HasMaxLength(300);
             
        }
    }
}
