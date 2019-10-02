using Domain.Entities; 
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Persistance.PostgresSQL.EntityConfig
{
 
    public class ItemControlConfiguration : IEntityTypeConfiguration<ItemControl>
    {
        public void Configure(EntityTypeBuilder<ItemControl> builder)
        {
            // Mapeo a la tabla ItemsControl (en plural)            
            builder.ToTable("ItemsControl");
            // set Id como primaryKey
            builder.HasKey(a => a.Id);
            // setear tamaño maximo de 300
            builder.Property(a => a.Nombre).HasMaxLength(300);
            // set ForeignKey 
            builder.HasOne(u => u.TipoRubroItemControl).WithMany().HasForeignKey(x => x.TipoRubroItemControlId).IsRequired();
        }
    }
}
