using System;
using System.Collections.Generic;

namespace Domain.Core
{
    /// <summary>
    /// Representa que la clase implementada es del tipo EntityTipo que son entidades con un campo Id y un campo Descripción (este ultimo del tipo string).
    /// </summary>
    /// <typeparam name="TId">The type of the entity key.</typeparam>
    public abstract class EntityTipo<TId> : Entity<TId>
         where TId : IEquatable<TId>
    {
        public string Descripcion { get; set; }

        public EntityTipo()
        {}

        public EntityTipo(TId id, string descripcion)
        {
            this.Id = id;
            this.Descripcion = descripcion;
        }

    }
}
