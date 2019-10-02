using Domain.Entities; 
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Persistance.PostgresSQL.EntityConfig
{
    class ListadoInspeccionConfiguration : IEntityTypeConfiguration<ListadoInspeccion>
    {
        public void Configure(EntityTypeBuilder<ListadoInspeccion> builder)
        {
            // Mapeo a la tabla ListadosInspeccion (en plural)            
            builder.ToTable("ListadosInspeccion");
            // set Id como primaryKey
            builder.HasKey(a => a.Id);
            // set FK
            builder.HasOne(u => u.TipoMedidaPeriodicidad).WithMany().HasForeignKey(x => x.TipoMedidaPeriodicidadId).IsRequired();
        }
    }
}
