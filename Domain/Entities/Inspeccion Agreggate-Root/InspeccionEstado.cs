using Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class InspeccionEstado : Entity<Guid>
    {
        public string UsuarioId { get; private set; }
        public string Observacion { get; private set; }
        public DateTime Fecha { get; private set; }
        public string Ubicacion { get; private set; }
        public Guid InspeccionId { get; private set; }
        public Inspeccion Inspeccion { get; private set; }
        public int TipoEstadoInspeccionId { get; private set; }
        public TipoEstadoInspeccion TipoEstadoInspeccion { get; private set; }
         
        public void SetObservacion(string observacion)
        {
            this.Observacion = observacion;
        }
        public void SetFecha(DateTime fecha)
        {
            this.Fecha = fecha;
        }
        public void SetUbicacion(string ubicacion)
        {
            this.Ubicacion = ubicacion;
        }
        public void SetInspeccionId(Guid inspeccionId)
        {
            this.InspeccionId= inspeccionId;
        }
        public void SetTipoEstadoInspeccionId(int tipoEstadoInspeccionId)
        {
            this.TipoEstadoInspeccionId = tipoEstadoInspeccionId;
        }
    }
}
