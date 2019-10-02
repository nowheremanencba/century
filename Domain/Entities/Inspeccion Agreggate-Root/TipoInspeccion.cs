using Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class TipoInspeccion : EntityTipo<string>
    { 
        public TipoInspeccion(string id, string descripcion)
        {
            this.Id = id;
            this.Descripcion = descripcion;
        }
    }
}
