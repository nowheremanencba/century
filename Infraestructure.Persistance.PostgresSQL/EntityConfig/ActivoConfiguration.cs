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
    public class ActivoConfiguration : IEntityTypeConfiguration<Activo>
    {
        public void Configure(EntityTypeBuilder<Activo> builder)
        {
            // Mapeo a la tabla Activos (en plural)            
            builder.ToTable("Activos");
            // set Id como primaryKey
            builder.HasKey(a => a.Id);
            // set Dominio como Index
            builder.HasIndex(a => a.Dominio).IsUnique();
            // set NumeroInterno como Index
            builder.HasIndex(a => a.NumeroInterno).IsUnique();
            // setear como no permitir null y tamaño maximo de 150
            builder.Property(a => a.Dominio).IsRequired().HasMaxLength(150);

            // setear como no permitir null y tamaño maximo de 300
            builder.Property(p => p.Ubicacion).IsRequired().HasMaxLength(300);

            builder.HasOne(u => u.TipoModelo).WithMany().HasForeignKey(x => x.TipoModeloId).IsRequired();
            builder.HasOne(u => u.TipoActivo).WithMany().HasForeignKey(x => x.TipoActivoId).IsRequired();

        }
    }
}
