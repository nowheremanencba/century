using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Persistance.PostgresSQL.EntityConfig
{
    public class DocumentacionActivoConfiguration : IEntityTypeConfiguration<DocumentacionActivo>
    {
        public void Configure(EntityTypeBuilder<DocumentacionActivo> builder)
        {
            // Mapeo a la tabla TiposActivo (en plural)            
            builder.ToTable("DocumentacionesActivo");
            // set Id como primaryKey
            builder.HasKey(a => a.Id);
            // set ForeignKey 
            builder.HasOne(u => u.TipoDocumentacionActivo).WithMany().HasForeignKey(x => x.TipoDocumentacionActivoId).IsRequired();
            // Set index on FechaVencimiento, ActivoId
            builder.HasIndex(d => new { d.FechaVencimiento, d.ActivoId });
        }
    }
}
