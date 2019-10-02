using Domain.Core;
using Domain.Entities;
using Domain.Entities.ListadoInspeccion_Agreggate_Root;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Inspeccion : Entity<Guid>, IAggregateRoot
    {
        public string Observacion { get; private set; }
        public Guid ActivoId { get; private set; }
        public virtual Activo Activo { get; private set; }
        public string TipoInspeccionId { get; private set; }
        public virtual TipoInspeccion TipoInspeccion { get; private set; }
        public Guid ListadoInspeccionId { get; private set; }
        public virtual ListadoInspeccion ListadoInspeccion { get; private set; }

        public Inspeccion()
        { }
        public void SetObservacion(string observacion)
        {
            this.Observacion = observacion;
        }
        public void SetActivoId(Guid activoId)
        {
            this.ActivoId = activoId;
        }
        public void SetTipoInspeccionId(string tipoInspeccionId)
        {
            this.TipoInspeccionId = tipoInspeccionId;
        }
        public void SetListadoInspeccionId(Guid listadoInspeccionId)
        {
            this.ListadoInspeccionId = listadoInspeccionId;
        }
    }
}
