using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class ListadoInspeccion_TipoActivo
    {
        public Guid ListadoInspeccionId { get; set; }        
        public int TipoActivoId { get; set; }
    }
}
