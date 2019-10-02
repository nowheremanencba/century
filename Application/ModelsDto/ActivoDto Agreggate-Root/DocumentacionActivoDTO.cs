using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ModelsDto.ActivoDto_Agreggate_Root
{
    public class DocumentacionActivoDTO
    {
        public Guid Id { get; set; }
        public DateTime FechaVencimiento { get; set; } 
        public string TipoDocumentacionActivoId { get; set; }

    }
}
