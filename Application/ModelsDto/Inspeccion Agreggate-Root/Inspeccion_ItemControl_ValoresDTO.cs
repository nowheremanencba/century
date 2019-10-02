using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ModelsDto
{
    public class Inspeccion_ItemControl_ValoresDTO
    {
        public int ItemControlId { get; set; }
        public string Observacion { get; set; }
        public int Orden { get; set; }
        public int ValorLectura { get; set; }
        public string TipoAccionRecomendadaId { get; set; }
        public string TipoLecturaItemInspeccionId { get; set; }
    }
}
