using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Persistance.PostgresSQL.EntityConfig
{ 
    public class TipoLecturaItemInspeccionConfiguration : IEntityTypeConfiguration<TipoLecturaItemInspeccion>
    {
        public void Configure(EntityTypeBuilder<TipoLecturaItemInspeccion> builder)
        {
            // Mapeo a la tabla TiposLecturaItemInspeccion            
            builder.ToTable("TiposLecturaItemInspeccion");
            // set Id como primaryKey
            builder.HasKey(a => a.Id);
            // setear  tamaño maximo de 300
            builder.Property(a => a.Descripcion).HasMaxLength(300);

        }
    }
}
