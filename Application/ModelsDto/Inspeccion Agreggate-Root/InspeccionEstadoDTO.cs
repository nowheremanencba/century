using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ModelsDto
{
    public class InspeccionEstadoDTO
    {
        public string UsuarioId { get;  set; }
        public string Observacion { get; set; }
        public DateTime Fecha { get; set; }
        public string Ubicacion { get; set; }
        public int TipoEstadoInspeccionId { get; set; } 
    }
}
