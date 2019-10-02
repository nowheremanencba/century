using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ModelsDto
{
    public class InspeccionDTO
    {
        public string Observacion { get; set; }
        public Guid ActivoId { get;  set; }
        public string TipoInspeccionId { get;  set; }
        public Guid ListadoInspeccionId { get;  set; }

    }
}
