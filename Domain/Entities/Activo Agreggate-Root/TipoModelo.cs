using Domain.Core;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class TipoModelo : EntityTipo<int>
    { 
        public int TipoMarcaId { get; private set; }
        public virtual TipoMarca TipoMarca { get; private set; }

        public TipoModelo(int id, string descripcion, int tipoMarcaId)
        {
            this.Id = id;
            this.Descripcion = descripcion;
            this.TipoMarcaId = tipoMarcaId;
        }
    }
}
