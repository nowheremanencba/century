using Domain.Core;
using Domain.Core.Specifications;
using Domain.Entities.Activo_Agreggate_Root.Specification;
using Domain.Entities.ListadoInspeccion_Agreggate_Root.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Entities.ListadoInspeccion_Agreggate_Root.Validator
{
    public class ListadoInspeccionValidator : IValidator<ListadoInspeccion>
    {
        protected List<Specification<ListadoInspeccion>> Rules
        {
            get
            {
                return new List<Specification<ListadoInspeccion>>
                {
                    new ListadoInspeccionSpecification.TipoMedidaPeriodicidadIdSpecification(),
                    new ListadoInspeccionSpecification.TipoActivoCountSpecification(),
                    new ListadoInspeccionSpecification.TipoActivoNullSpecification()
                };
            }
        }
        public bool IsValid(ListadoInspeccion listadoInspeccion)
        {
            return (BrokenRules(listadoInspeccion).Count() == 0);
        }

        public IEnumerable<CenturyError> BrokenRules(ListadoInspeccion listadoInspeccion)
        {
            return Rules.Where(rule => !rule.IsSatisfiedBy(listadoInspeccion))
                        .Select(rule => GetErrorsForBrokenRule(rule));
        }

        protected CenturyError GetErrorsForBrokenRule(Specification<ListadoInspeccion> specListadoInspeccion)
        {
            switch (specListadoInspeccion.GetType().Name)
            {
                case nameof(ListadoInspeccionSpecification.TipoMedidaPeriodicidadIdSpecification):
                    return new CenturyError(CenturyError.TipoError.ValorIncorrecto, "El TipoMedidaPeriodicidadId Id es requerido", "TipoMedidaPeriodicidad");
                case nameof(ListadoInspeccionSpecification.TipoActivoCountSpecification):
                    return new CenturyError(CenturyError.TipoError.ValorIncorrecto, "El TipoActivoId Id es requerido", "TipoActivo");
                case nameof(ListadoInspeccionSpecification.TipoActivoNullSpecification):
                    return new CenturyError(CenturyError.TipoError.ValorIncorrecto, "El TipoActivoId no debe ser cero o nulo", "TipoActivo");
 
                default:
                    break;
            }
            return null;
        } 
    }
}
