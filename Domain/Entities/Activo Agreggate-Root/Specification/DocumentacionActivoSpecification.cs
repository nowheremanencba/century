using Domain.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Domain.Entities.Activo_Agreggate_Root.Specification
{
    public class DocumentacionActivoSpecification
    {  
        public sealed class TipoDocumentacionActivoIdSpecification : Specification<DocumentacionActivo>
        {
            #region Public Methods
            /// <summary>
            /// Gets the LINQ expression which represents the current specification.
            /// </summary>
            /// <returns>The LINQ expression.</returns>
            public override Expression<Func<DocumentacionActivo, bool>> Expression => docactivo => docactivo.TipoDocumentacionActivoId.All(char.IsDigit)  ;
            #endregion
        }

 
    }
}
 