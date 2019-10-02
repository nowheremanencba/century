using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Persistance.PostgresSQL.EntityConfig
{ 
    public class InspeccionEstadoConfiguration : IEntityTypeConfiguration<InspeccionEstado>
    {
        public void Configure(EntityTypeBuilder<InspeccionEstado> builder)
        {
            // Mapeo a la tabla InspeccionesEstados (en plural)            
            builder.ToTable("Inspecciones_Estados");
            // set Id como primaryKey
            builder.HasKey(a => a.Id);
            // Relationships
            builder.HasOne(u => u.Inspeccion).WithMany().HasForeignKey(x => x.InspeccionId ).IsRequired();
            builder.HasOne(u => u.TipoEstadoInspeccion).WithMany().HasForeignKey(x => x.TipoEstadoInspeccionId).IsRequired();
        }
    }
}
