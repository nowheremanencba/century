using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders ;


namespace Infraestructure.Persistance.PostgresSQL.EntityConfig
{
    public class TipoModeloConfiguration : IEntityTypeConfiguration<TipoModelo>
    {
        public void Configure(EntityTypeBuilder<TipoModelo> builder)
           {
            // Mapeo a la tabla TiposModelo (en plural)            
            builder.ToTable("TiposModelo");            
            // set Id como primaryKey
            builder.HasKey(a => a.Id);
            // setear como no permitir  tamaño maximo de 300
            builder.Property(a => a.Descripcion ).HasMaxLength(300);

            builder.HasOne(u => u.TipoMarca).WithMany().HasForeignKey(x => x.TipoMarcaId);
        }
    }
}
