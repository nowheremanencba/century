using Domain.Core;

namespace Domain.Entities
{
    public class TipoMarca : EntityTipo<int>
    {
        public TipoMarca(int id, string descripcion)
        {
            this.Id = id;
            this.Descripcion = descripcion;
        }
    }
}
