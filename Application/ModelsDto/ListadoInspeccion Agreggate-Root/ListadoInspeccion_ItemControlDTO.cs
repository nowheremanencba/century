using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ModelsDto
{
    public class ListadoInspeccion_ItemControlDTO
    {
        public int Orden { get; set; }
        public Guid ListadoInspeccionId { get; set; } 
        public int ItemControlId { get; set; } 
    }
}
