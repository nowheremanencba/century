using Domain.Core;
using Domain.Core.Specifications;
using Domain.Entities.Inspeccion_Agreggate_Root.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Entities.ListadoInspeccion_Agreggate_Root.Validator
{
    public class InspeccionEstadoValidator : IValidator<InspeccionEstado>
    {
        protected List<Specification<InspeccionEstado>> Rules
        {
            get
            {
                return new List<Specification<InspeccionEstado>>
                {
                    new InspeccionEstadoSpecification.InspeccionIdSpecification(),
                    new InspeccionEstadoSpecification.TipoEstadoInspeccionIdSpecification()
                };
            }
        }
        public bool IsValid(InspeccionEstado inspeccion)
        {
            return (BrokenRules(inspeccion).Count() == 0);
        }

        public IEnumerable<CenturyError> BrokenRules(InspeccionEstado inspeccion)
        {
            return Rules.Where(rule => !rule.IsSatisfiedBy(inspeccion))
                        .Select(rule => GetErrorsForBrokenRule(rule));
        }

        protected CenturyError GetErrorsForBrokenRule(Specification<InspeccionEstado> specInspeccion)
        {
            switch (specInspeccion.GetType().Name)
            {
                case nameof(InspeccionEstadoSpecification.InspeccionIdSpecification):
                    return new CenturyError(CenturyError.TipoError.ValorIncorrecto, "El Inspeccion Id es requerido", "Inspeccion");
                case nameof(InspeccionEstadoSpecification.TipoEstadoInspeccionIdSpecification):
                    return new CenturyError(CenturyError.TipoError.ValorIncorrecto, "El Tipo Estado Inspeccion Id es requerido", "TipoEstadoInspeccion");                default:
                    break;
            }
            return null;
        }
    }
}
