using Domain.Entities;
using Infraestructure.Persistance.PostgresSQL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Persistance.PostgresSQL.EntityConfig
{ 
    class ListadoInspeccion_ItemControlConfiguration : IEntityTypeConfiguration<ListadoInspeccion_ItemControl>
    {
        public void Configure(EntityTypeBuilder<ListadoInspeccion_ItemControl> builder)
        {
            // Mapeo a la tabla ListadosInspeccion_ItemsControl (en plural)            
            builder.ToTable("ListadosInspeccion_ItemsControl");
            // set PrimaryKeys
            builder.HasKey(a => new { a.ListadoInspeccionId, a.ItemControlId } );            
        }
    }
}
