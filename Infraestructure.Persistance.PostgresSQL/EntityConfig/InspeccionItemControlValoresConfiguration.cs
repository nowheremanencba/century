using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Persistance.PostgresSQL.EntityConfig
{ 
    public class InspeccionItemControlValoresConfiguration : IEntityTypeConfiguration<Inspeccion_ItemControl_Valores>
    {
        public void Configure(EntityTypeBuilder<Inspeccion_ItemControl_Valores> builder)
        {
            // Mapeo a la tabla Inspecciones_ItemsControl_Valores (en plural)            
            builder.ToTable("Inspecciones_ItemsControl_Valores"); 
            // set PrimaryKeys
            builder.HasKey(a => new { a.InspeccionId , a.ItemControlId });
            // Relationships
           builder.HasOne(u => u.TipoAccionRecomendada ).WithMany().HasForeignKey(x => x.TipoAccionRecomendadaId).IsRequired();
           //builder.HasOne(u => u.TipoLecturaItemInspeccion).WithMany().HasForeignKey(x => x.TipoLecturaItemInspeccion).IsRequired();
        }
    }
}
