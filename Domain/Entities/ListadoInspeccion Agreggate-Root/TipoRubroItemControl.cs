using Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class TipoRubroItemControl : EntityTipo<string>
    {
        public TipoRubroItemControl(string id, string descripcion)
        {
            this.Id = id;
            this.Descripcion = descripcion;
        }
    }
}
