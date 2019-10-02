using Domain.Core;
using Domain.Core.Specifications;
using Domain.Entities.Activo_Agreggate_Root.Specification;
using Domain.Entities.Persona_Raiz_Agregada;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Entities.Activo_Agreggate_Root.Validator
{
    class DocumentacionActivoValidator : IValidator<DocumentacionActivo>
    { 
        protected List<Specification<DocumentacionActivo>> Rules
        {
            get
            {
                return new List<Specification<DocumentacionActivo>>
                { 
                    new DocumentacionActivoSpecification.TipoDocumentacionActivoIdSpecification() 
                };
            }
        }
        public DocumentacionActivoValidator()
        { 
        }

    public bool IsValid(DocumentacionActivo DocActivo)
        {
            return (BrokenRules(DocActivo).Count() == 0);
        }

        public IEnumerable<CenturyError> BrokenRules(DocumentacionActivo DocActivo)
        {
            return Rules.Where(rule => !rule.IsSatisfiedBy(DocActivo))
                        .Select(rule => GetErrorsForBrokenRule(rule));
        }

        protected CenturyError GetErrorsForBrokenRule(Specification<DocumentacionActivo> specActivo)
        {
            switch (specActivo.GetType().Name)
            {
                case nameof(DocumentacionActivoSpecification.TipoDocumentacionActivoIdSpecification):
                    return new CenturyError(CenturyError.TipoError.ValorIncorrecto, "TipoDocumentacionActivoId debe ser un valor numerico", "Documentacion");
                 
                default:
                    break;
            }
            return null;
        }
    }
}
