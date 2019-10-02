using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ModelsDto
{
    public class ListadoInspeccionDTO
    {
        public string Descripcion { get; set; }
        public int UnidadPeriodicidad { get; set; }
        public int TipoMedidaPeriodicidadId { get; set; }
        public List<TipoActivoDTO> TipoActivo { get; set; }
    }
}
