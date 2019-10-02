using Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class TipoEstadoInspeccion : EntityTipo<int>
    {
        public TipoEstadoInspeccion(int id, string descripcion)
        {
            this.Id = id;
            this.Descripcion = descripcion;
        }
    }
}
