using Domain.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Domain.Entities.Inspeccion_Agreggate_Root.Specification
{
    public class InspeccionItemControlValoresSpecification
    {
        public sealed class TipoLecturaItemInspeccionIdSpecification : Specification<Inspeccion_ItemControl_Valores>
        { 
            #region Public Methods
            /// <summary>
            /// Gets the LINQ expression which represents the current specification.
            /// </summary>
            /// <returns>The LINQ expression.</returns>
            public override Expression<Func<Inspeccion_ItemControl_Valores, bool>> Expression => inspeccionICV => inspeccionICV.TipoLecturaItemInspeccionId > 0;
            #endregion
        }
        public sealed class TipoAccionRecomendadaIdSpecification : Specification<Inspeccion_ItemControl_Valores>
        {
            #region Public Methods
            /// <summary>
            /// Gets the LINQ expression which represents the current specification.
            /// </summary>
            /// <returns>The LINQ expression.</returns>
            public override Expression<Func<Inspeccion_ItemControl_Valores, bool>> Expression => inspeccionICV => !string.IsNullOrEmpty(inspeccionICV.TipoAccionRecomendadaId);
            #endregion
        } 

        public sealed class RequireLecturaItemControlSpecification : Specification<Inspeccion_ItemControl_Valores>
        {
            private readonly bool lecturaItemControl;

            public RequireLecturaItemControlSpecification(bool lecturaItemControl)
            {
                this.lecturaItemControl = lecturaItemControl;
            }
            #region Public Methods
            /// <summary>
            /// Gets the LINQ expression which represents the current specification.
            /// </summary>
            /// <returns>The LINQ expression.</returns>
            public override Expression<Func<Inspeccion_ItemControl_Valores, bool>> Expression => inspeccionICV => (lecturaItemControl && inspeccionICV.ValorLectura <= 0) ==false;
            #endregion
        }
    }
}
