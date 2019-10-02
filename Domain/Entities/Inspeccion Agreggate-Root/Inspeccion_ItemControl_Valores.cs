using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Inspeccion_ItemControl_Valores
    {
        public int ItemControlId { get; private set; }
        public ItemControl ItemControl { get; private set; }
        public Guid InspeccionId { get; private set; }
        public virtual Inspeccion Inspeccion { get; private set; }
        public string Observacion { get; private set; }
        public int Orden { get; private set; }
        public int ValorLectura { get; private set; }
        public string TipoAccionRecomendadaId { get; private set; }
        public virtual TipoAccionRecomendada TipoAccionRecomendada { get; private set; }
        public int TipoLecturaItemInspeccionId { get; private set; }
        public virtual TipoLecturaItemInspeccion TipoLecturaItemInspeccion { get; private set; }

        public void SetItemControlId(int itemControlId)
        {
            this.ItemControlId = itemControlId;
        }
        public void SetInspeccionId(Guid inspeccionId)
        {
            this.InspeccionId = inspeccionId;
        }
        public void SetObservacion(string observacion)
        {
            this.Observacion = observacion;
        }
        public void SetOrden(int orden)
        {
            this.Orden = orden;
        }
        public void SetValorLectura(int ValorLectura)
        {
            this.ValorLectura = ValorLectura;
        }
        public void SetTipoAccionRecomendadaId(string tipoAccionRecomendadaId)
        {
            this.TipoAccionRecomendadaId = tipoAccionRecomendadaId;
        }
        public void SettipoLecturaItemInspeccionId(int tipoLecturaItemInspeccionId)
        {
            this.TipoLecturaItemInspeccionId = tipoLecturaItemInspeccionId;
        }

    }
}
