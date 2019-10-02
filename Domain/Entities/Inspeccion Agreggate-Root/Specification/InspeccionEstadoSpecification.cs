using Domain.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Domain.Entities.Inspeccion_Agreggate_Root.Specification
{
    public class InspeccionEstadoSpecification
    {
        public sealed class InspeccionIdSpecification : Specification<InspeccionEstado>
        {
            private Guid guidOutput;
            #region Public Methods
            /// <summary>
            /// Gets the LINQ expression which represents the current specification.
            /// </summary>
            /// <returns>The LINQ expression.</returns>
            public override Expression<Func<InspeccionEstado, bool>> Expression => inspeccionEstado => (Guid.TryParse(inspeccionEstado.InspeccionId.ToString(), out guidOutput)) && (inspeccionEstado.InspeccionId == Guid.Empty ? false : true);
             
            #endregion
        }
        public sealed class TipoEstadoInspeccionIdSpecification : Specification<InspeccionEstado>
        { 
            #region Public Methods
            /// <summary>
            /// Gets the LINQ expression which represents the current specification.
            /// </summary>
            /// <returns>The LINQ expression.</returns>
            public override Expression<Func<InspeccionEstado, bool>> Expression => inspeccionEstado => inspeccionEstado.TipoEstadoInspeccionId > 0;

            #endregion
        }
    }
}
