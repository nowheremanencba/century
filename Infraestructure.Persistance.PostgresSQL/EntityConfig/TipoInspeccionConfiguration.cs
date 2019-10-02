using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Persistance.PostgresSQL.EntityConfig
{ 
    public class TipoInspeccionConfiguration : IEntityTypeConfiguration<TipoInspeccion>
    {
        public void Configure(EntityTypeBuilder<TipoInspeccion> builder)
        {
            // Mapeo a la tabla TiposInspeccion            
            builder.ToTable("TiposInspeccion");
            // set Id como primaryKey
            builder.HasKey(a => a.Id); 
           
        }
    }
}
