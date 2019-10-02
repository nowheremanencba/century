using Domain.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Domain.Entities.Inspeccion_Agreggate_Root.Specification
{
    public class InspeccionSpecification
    {
        public sealed class ActivoIdSpecification : Specification<Inspeccion>
        {
            private Guid guidOutput;
            #region Public Methods
            /// <summary>
            /// Gets the LINQ expression which represents the current specification.
            /// </summary>
            /// <returns>The LINQ expression.</returns>
            public override Expression<Func<Inspeccion, bool>> Expression => inspeccion => (Guid.TryParse(inspeccion.ActivoId.ToString(), out guidOutput)) && (inspeccion.ActivoId == Guid.Empty ? false : true);
            #endregion
        }
        public sealed class TipoInspeccionSpecification : Specification<Inspeccion>
        {
            #region Public Methods
            /// <summary>
            /// Gets the LINQ expression which represents the current specification.
            /// </summary>
            /// <returns>The LINQ expression.</returns>
            public override Expression<Func<Inspeccion, bool>> Expression => inspeccion => !string.IsNullOrEmpty(inspeccion.TipoInspeccionId);
            #endregion
        }
        public sealed class ListadoInspeccionIdSpecification : Specification<Inspeccion>
        {
            private Guid guidOutput;
            #region Public Methods
            /// <summary>
            /// Gets the LINQ expression which represents the current specification.
            /// </summary>
            /// <returns>The LINQ expression.</returns>
            public override Expression<Func<Inspeccion, bool>> Expression => inspeccion => (Guid.TryParse(inspeccion.ListadoInspeccionId.ToString(), out guidOutput)) && (inspeccion.ListadoInspeccionId == Guid.Empty ? false : true);
            #endregion
        }
 
        public sealed class IsTipoActivoInListaInspeccionSpecification : Specification<Inspeccion>
        {
            private readonly bool existeListadoInspeccion;

            public IsTipoActivoInListaInspeccionSpecification(bool ExisteListadoInspeccion)
            {
                this.existeListadoInspeccion = ExisteListadoInspeccion;
            }
            #region Public Methods
            /// <summary>
            /// Obtiene la expresion LINQ que representa a la especificación.
            /// </summary>
            /// <returns>Expresión LINQ.</returns>
            public override Expression<Func<Inspeccion, bool>> Expression => a => existeListadoInspeccion;
            #endregion
        }

      
    }
}
