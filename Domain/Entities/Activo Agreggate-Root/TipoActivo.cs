using Domain.Core;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class TipoActivo : EntityTipo<int>
    {
        public bool DominioObligatorio { get; private set; }
        public TipoActivo() { }
        public TipoActivo(int id, string descripcion,bool dominioObligatorio)
        {
            this.Id = id;
            this.Descripcion = descripcion;
            this.DominioObligatorio = dominioObligatorio;
        }
    }
}
