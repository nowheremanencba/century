using System;
using System.Collections.Generic;
using Domain.Core;

namespace Domain.Entities
{
    public class DocumentacionActivo : Entity<Guid> 
    {
        public DateTime FechaVencimiento { get; private set; }
        public string TipoDocumentacionActivoId { get; private set; }
        public virtual TipoDocumentacionActivo TipoDocumentacionActivo { get; private set; }
        public Guid ActivoId { get; private set; }

        public DocumentacionActivo()
        { }

        public DocumentacionActivo(Guid id, DateTime fechaVencimiento, string tipoDocumentacionActivoId, Guid activoId)
        {
            this.Id = id;
            this.FechaVencimiento = fechaVencimiento;
            this.TipoDocumentacionActivoId = TipoDocumentacionActivoId;
            this.ActivoId = activoId;
        }

        public void CambiarFechaVencimiento(DateTime fechaVencimiento)
        {
            this.FechaVencimiento = fechaVencimiento;
        }

        public void CambiarTipoDocumentacionActivoId(string tipoDocumentacionActivoId)
        {
            this.TipoDocumentacionActivoId = tipoDocumentacionActivoId;
        }

    }
}
