using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Persistance.PostgresSQL.EntityConfig
{
    public class InspeccionConfiguration : IEntityTypeConfiguration<Inspeccion>
    {
        public void Configure(EntityTypeBuilder<Inspeccion> builder)
        {
            // Mapeo a la tabla Inspecciones (en plural)            
            builder.ToTable("Inspecciones");
            // set Id como primaryKey
            builder.HasKey(a => a.Id);
            // Relationships
            builder.HasOne(u => u.Activo ).WithMany().HasForeignKey(x => x.ActivoId).IsRequired();
            builder.HasOne(u => u.ListadoInspeccion).WithMany().HasForeignKey(x => x.ListadoInspeccionId).IsRequired();
            builder.HasOne(u => u.TipoInspeccion).WithMany().HasForeignKey(x => x.TipoInspeccionId).IsRequired();
        }
    } 
}
