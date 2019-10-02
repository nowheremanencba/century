using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Persistance.PostgresSQL.SeedData
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TipoMarca>().HasData(
            new TipoMarca(1, "Ford"));

            modelBuilder.Entity<TipoModelo>().HasData(
            new TipoModelo(1, "Mustang", 1),
            new TipoModelo(2, "F-100", 1));

            modelBuilder.Entity<TipoActivo>().HasData(
              new TipoActivo(1, "Camioneta", true),
              new TipoActivo(2, "Perfodaora", false));

            modelBuilder.Entity<TipoMedidaPeriodicidad>().HasData(
                new TipoMedidaPeriodicidad("1", "Horas"),
                new TipoMedidaPeriodicidad("2", "Semanas"));
             
            modelBuilder.Entity<TipoRubroItemControl>().HasData(
                new TipoRubroItemControl("1", "Estado General"),
                new TipoRubroItemControl("2", "Motor"),
                new TipoRubroItemControl("3", "Seguridad"));

            modelBuilder.Entity<ItemControl>().HasData(
                new ItemControl(1, "Nivel Aceite Motor", true, "1"),
                new ItemControl(2, "Carga de la bateria", true, "2"));

            modelBuilder.Entity<TipoInspeccion>().HasData(
                new TipoInspeccion("1", "Inspeccion de ingreso"),
                new TipoInspeccion("2", "Inspeccion de egreso"),
                new TipoInspeccion("3", "Inspeccion de rutina"));

            modelBuilder.Entity<TipoEstadoInspeccion>().HasData(
                new TipoEstadoInspeccion(1, "Realizado"),
                new TipoEstadoInspeccion(2, "Controlado"),
                new TipoEstadoInspeccion(3, "Supervisado"));

            modelBuilder.Entity<TipoAccionRecomendada>().HasData(
                new TipoAccionRecomendada("1", "Reparar"),
                new TipoAccionRecomendada("2", "Cambiar"),
                new TipoAccionRecomendada("3", "Proveer"),
                new TipoAccionRecomendada("4", "No Aplica"),
                new TipoAccionRecomendada("5", "Ninguna"));

            modelBuilder.Entity<TipoLecturaItemInspeccion>().HasData(
                new TipoLecturaItemInspeccion(1, "Bien"),
                new TipoLecturaItemInspeccion(2, "Mal"));

        }
    }
}
