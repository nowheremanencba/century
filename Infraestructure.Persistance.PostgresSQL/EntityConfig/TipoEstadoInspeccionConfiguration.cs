using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Persistance.PostgresSQL
{ 
    public class TipoEstadoInspeccionConfiguration : IEntityTypeConfiguration<TipoEstadoInspeccion>
    {
        public void Configure(EntityTypeBuilder<TipoEstadoInspeccion> builder)
        {
            // Mapeo a la tabla TiposEstadosInspeccion (en plural)            
            builder.ToTable("TiposEstadosInspeccion");
            // set Id como primaryKey
            builder.HasKey(a => a.Id);
        }
    }
}
