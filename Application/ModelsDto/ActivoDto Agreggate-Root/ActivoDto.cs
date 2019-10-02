using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ModelsDto.ActivoDto_Agreggate_Root
{
    public class ActivoDto
    {
        public Guid Id { get; set; }
        public int NumeroInterno { get; set; } 
        public string Dominio { get;  set; }
        public string Año { get;  set; }
        public int TipoModeloId { get;  set; }
        public int TipoActivoId { get;  set; } 
        public Nullable<Guid> EmpleadoResponsableID { get;  set; }
        public string Chasis { get;  set; }
        public string Motor { get;  set; }
        public string Ubicacion { get;  set; }
        public DateTime FechaCompra { get;  set; }
        
    }
}
