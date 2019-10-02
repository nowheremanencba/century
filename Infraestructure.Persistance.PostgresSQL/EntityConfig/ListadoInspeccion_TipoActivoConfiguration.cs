using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Persistance.PostgresSQL.EntityConfig
{ 
    class ListadoInspeccion_TipoActivoConfiguration : IEntityTypeConfiguration<ListadoInspeccion_TipoActivo>
    {
        public void Configure(EntityTypeBuilder<ListadoInspeccion_TipoActivo> builder)
        {
            // Mapeo a la tabla ListadosInspeccion_TipoActivo (en plural)            
            builder.ToTable("ListadosInspeccion_TipoActivo");
            // set PrimaryKeys
            builder.HasKey(a => new { a.ListadoInspeccionId, a.TipoActivoId });            
        }
    }
}
