using Domain.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Domain.Entities.ListadoInspeccion_Agreggate_Root.Specification
{
    public class ListadoInspeccionSpecification
    { 
        public sealed class TipoMedidaPeriodicidadIdSpecification : Specification<ListadoInspeccion>
        {
            #region Public Methods
            /// <summary>
            /// Gets the LINQ expression which represents the current specification.
            /// </summary>
            /// <returns>The LINQ expression.</returns>
            public override Expression<Func<ListadoInspeccion, bool>> Expression => listadoinspeccion => !string.IsNullOrEmpty(listadoinspeccion.TipoMedidaPeriodicidadId) && listadoinspeccion.TipoMedidaPeriodicidadId != "0";
            #endregion
        }
        public sealed class TipoActivoCountSpecification : Specification<ListadoInspeccion>
        {
            #region Public Methods
            /// <summary>
            /// Gets the LINQ expression which represents the current specification.
            /// </summary>
            /// <returns>The LINQ expression.</returns>
            public override Expression<Func<ListadoInspeccion, bool>> Expression => listadoinspeccion => listadoinspeccion.TipoActivo.Count > 0 ;
            #endregion
        } 
        public sealed class TipoActivoNullSpecification : Specification<ListadoInspeccion>
        {
            #region Public Methods
            /// <summary>
            /// Gets the LINQ expression which represents the current specification.
            /// </summary>
            /// <returns>The LINQ expression.</returns>
           public override Expression<Func<ListadoInspeccion, bool>> Expression => listadoinspeccion => !listadoinspeccion.TipoActivo.Exists(x=> x.Id == 0);
            #endregion
        }
    }
}
