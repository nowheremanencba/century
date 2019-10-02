using Domain.Entities;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;
using Infraestructure.Persistance.PostgresSQL.EntityConfig;
using Infraestructure.Persistance.PostgresSQL.SeedData;
using Infraestructure.Persistance.PostgresSQL.Models;

namespace Infraestructure.Persistance.PostgresSQL
{
    public class CenturyContext : DbContext
    {
        public CenturyContext() : base()
        {
            //"Server=defti-dev.westus2.cloudapp.azure.com;Database=prueba;User Id=sa;Password = Nahueldipaolo2018;Timeout=5 "
            // "RicardoModeloDB debe estar configurado en el config de la aplicacion.
            // Ej...
            // <add name="RicardoModeloDB" connectionString="Data Source=LUISFERNANDO-NO;Initial Catalog=ProjetoModeloDB;Integrated Security=True;MultipleActiveResultSets=True" providerName="System.Data.SqlClient" />
        }

        public DbSet<Activo> Activos { get; set; }
        public DbSet<TipoActivo> TipoActivo { get; set; }
        public DbSet<TipoModelo> TipoModelo { get; set; }
        public DbSet<TipoMarca> TipoMarca { get; set; }
        public DbSet<DocumentacionActivo> DocumentacionActivo{ get; set; }
        public DbSet<TipoDocumentacionActivo> TipoDocumentacion { get; set; }

        public DbSet<ItemControl> ItemControl { get; set; }
        public DbSet<ListadoInspeccion> ListadoInspeccion { get; set; }
        public DbSet<TipoMedidaPeriodicidad> TipoMedidaPeriodicidad { get; set; }
        public DbSet<TipoRubroItemControl> TipoRubroItemControl { get; set; }
        public DbSet<ListadoInspeccion_ItemControl> ListadoInspeccion_ItemControl { get; set; }

        public DbSet<Inspeccion> Inspeccion { get; set; }
        public DbSet<InspeccionEstado> InspeccionEstado { get; set; }
        public DbSet<Inspeccion_ItemControl_Valores> InspeccionItemControlValores { get; set; }
        public DbSet<TipoAccionRecomendada> TipoAccionRecomendada { get; set; }
        public DbSet<TipoEstadoInspeccion> TipoEstadoInspeccion { get; set; }
        public DbSet<TipoInspeccion> TipoInspeccion { get; set; }
        public DbSet<TipoLecturaItemInspeccion> TipoLecturaItemInspeccion { get; set; }
        public DbSet<ListadoInspeccion_TipoActivo> ListadoInspeccion_TipoActivo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=defti-dev.westus2.cloudapp.azure.com; Database = prueba; User Id = sa; Password = Nahueldipaolo2018; Timeout = 5 ");         
            //"Server=.\;Database=EFCoreWebDemo;Trusted_Connection=True;MultipleActiveResultSets=true");

            // Conexion Nahuel
            //optionsBuilder.UseNpgsql(@"Server=127.0.0.1;Port=5433;Database=Century-MCP;User Id=postgres;Password = 1234;CommandTimeout=10;;Timeout=10 ");

            // Conexion Nahuel
            //optionsBuilder.UseNpgsql(@"Server=127.0.0.1;Port=5433;Database=Century-MMV;User Id=postgres;Password = 1234;CommandTimeout=10;;Timeout=10 ");

            // Conexion Cristian
            optionsBuilder.UseNpgsql(@"Server=127.0.0.1;Port=5432;Database=Century-MCP;User Id=postgres;Password = 123456;CommandTimeout=10;;Timeout=10 ");

            //optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            modelBuilder.ApplyConfiguration(new ActivoConfiguration());
            modelBuilder.ApplyConfiguration(new TipoDocumentacionActivoConfiguration());
            modelBuilder.ApplyConfiguration(new TipoModeloConfiguration());
            modelBuilder.ApplyConfiguration(new TipoActivoConfiguration());
            modelBuilder.ApplyConfiguration(new TipoMarcaConfiguration());
            modelBuilder.ApplyConfiguration(new DocumentacionActivoConfiguration());

            modelBuilder.ApplyConfiguration(new ListadoInspeccionConfiguration());
            modelBuilder.ApplyConfiguration(new ListadoInspeccion_ItemControlConfiguration());
            modelBuilder.ApplyConfiguration(new ItemControlConfiguration());
            modelBuilder.ApplyConfiguration(new TipoRubroItemControlConfiguration());
            modelBuilder.ApplyConfiguration(new TipoMedidaPeriodicidadConfiguration());

            modelBuilder.ApplyConfiguration(new InspeccionConfiguration());
            modelBuilder.ApplyConfiguration(new InspeccionEstadoConfiguration());
            modelBuilder.ApplyConfiguration(new InspeccionItemControlValoresConfiguration());
            modelBuilder.ApplyConfiguration(new TipoAccionRecomendadaConfiguration());
            modelBuilder.ApplyConfiguration(new TipoInspeccionConfiguration());
            modelBuilder.ApplyConfiguration(new TipoLecturaItemInspeccionConfiguration());
            modelBuilder.ApplyConfiguration(new ListadoInspeccion_TipoActivoConfiguration());
            modelBuilder.Seed();
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("FechaRegistro") != null))
            {
                if(entry.State == EntityState.Added)
                {
                    entry.Property("FechaRegistro").CurrentValue = DateTime.Now;
                }
                if(entry.State == EntityState.Modified)
                {
                    entry.Property("FechaRegistro").IsModified = false;
                }
            }

            return base.SaveChanges();
        }
    }
}
