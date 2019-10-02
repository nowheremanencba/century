using Domain.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Domain.Entities.Persona_Raiz_Agregada
{
    public class ActivoSpecification
    {

        public sealed class DominioOkSpecification : Specification<Activo>
        {
            private bool esDominioRequerido;

            public DominioOkSpecification(bool esDominioRequerido)
            {
                this.esDominioRequerido = esDominioRequerido;
            }
            #region Public Methods
            /// <summary>
            /// Obtiene la expresion LINQ que representa a la especificación.
            /// </summary>
            /// <returns>Expresión LINQ.</returns>
            public override Expression<Func<Activo, bool>> Expression => a => (esDominioRequerido && string.IsNullOrEmpty(a.Dominio))==false ;
            #endregion  
        }
        public sealed class UbicacionSpecification : Specification<Activo>
        {
            #region Public Methods
            /// <summary>
            /// Gets the LINQ expression which represents the current specification.
            /// </summary>
            /// <returns>The LINQ expression.</returns>
            public override Expression<Func<Activo, bool>> Expression => activo => !string.IsNullOrEmpty(activo.Ubicacion);
            #endregion
        }
        public sealed class TipoModeloSpecification : Specification<Activo>
        {
            #region Public Methods
            /// <summary>
            /// Gets the LINQ expression which represents the current specification.
            /// </summary>
            /// <returns>The LINQ expression.</returns>
            public override Expression<Func<Activo, bool>> Expression => activo =>  activo.TipoModeloId > 0;
            #endregion
        }
        public sealed class TipoActivoSpecification : Specification<Activo>
        {
            #region Public Methods
            /// <summary>
            /// Gets the LINQ expression which represents the current specification.
            /// </summary>
            /// <returns>The LINQ expression.</returns>
            public override Expression<Func<Activo, bool>> Expression => activo =>  activo.TipoActivoId > 0; 
            #endregion
        }
        public sealed class FechaCompraSpecification : Specification<Activo>
        {
            #region Public Methods
            /// <summary>
            /// Gets the LINQ expression which represents the current specification.
            /// </summary>
            /// <returns>The LINQ expression.</returns>
            public override Expression<Func<Activo, bool>> Expression => activo => activo.FechaCompra <= DateTime.Now ;
            #endregion
        }
    }
}
