using Domain.Core;
using Domain.Core.Specifications;
using Domain.Entities.Inspeccion_Agreggate_Root.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Entities.Inspeccion_Agreggate_Root.Validator
{
    public class InspeccionValidator : IValidator<Inspeccion>
    {
        private readonly bool _isTipoActivoInListaInspeccion;

        public InspeccionValidator(bool isTipoActivoInListaInspeccion)
        {
            this._isTipoActivoInListaInspeccion = isTipoActivoInListaInspeccion;
        }

        protected List<Specification<Inspeccion>> Rules
        {
            get
            { 
                return new List<Specification<Inspeccion>>
                {
                    new InspeccionSpecification.ActivoIdSpecification(),
                    new InspeccionSpecification.TipoInspeccionSpecification(),
                    new InspeccionSpecification.ListadoInspeccionIdSpecification(), 
                    new InspeccionSpecification.IsTipoActivoInListaInspeccionSpecification(this._isTipoActivoInListaInspeccion),
                };
            }
        }
        public bool IsValid(Inspeccion inspeccion)
        {
            return (BrokenRules(inspeccion).Count() == 0);
        }

        public IEnumerable<CenturyError> BrokenRules(Inspeccion inspeccion)
        {
            return Rules.Where(rule => !rule.IsSatisfiedBy(inspeccion))
                        .Select(rule => GetErrorsForBrokenRule(rule));
        }

        protected CenturyError GetErrorsForBrokenRule(Specification<Inspeccion> specInspeccion)
        {
            switch (specInspeccion.GetType().Name)
            {
                case nameof(InspeccionSpecification.ActivoIdSpecification):
                    return new CenturyError(CenturyError.TipoError.ValorIncorrecto, "El Activo Id es requerido", "Activo");
                case nameof(InspeccionSpecification.TipoInspeccionSpecification):
                    return new CenturyError(CenturyError.TipoError.ValorIncorrecto, "El Tipo Inspeccion Id es requerido", "TipoInspeccion");
                case nameof(InspeccionSpecification.ListadoInspeccionIdSpecification):
                    return new CenturyError(CenturyError.TipoError.ValorIncorrecto, "El Listado Inspeccion Id es requerido", "ListadoInspeccion ");
                case nameof(InspeccionSpecification.IsTipoActivoInListaInspeccionSpecification):
                    return new CenturyError(CenturyError.TipoError.ValorIncorrecto, "El TipoActivo del Activo en la Inspeccion no existe en el ListadoInspeccion asociado", "TipoActivo");
                default:
                    break;
            }
            return null;
        }
         
    }
}
